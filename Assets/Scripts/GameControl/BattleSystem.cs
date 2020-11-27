using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    #region ui组件
    
    //骰子组合面板
    [SerializeField]
    ComboView comboView;

    //骰子投掷面板
    [SerializeField]
    DiceObjectPanel rollView;

    [SerializeField]
    Button rollButton, endTurnButton;

    [SerializeField]
    Text turnText;

    TeamEventView playerTeamView, enemyTeamView;

    internal BattleData data;

    #endregion


    #region 回合战斗管理
    TeamData playerTeam, enemyTeam;

    List<CharacterData> deadPlayers;

    //List<CharacterData> playerCharacters;
    //List<CharacterData> enemyCharacters;

    //CharacterData selectedPlayer, selectedEnemy;

    internal bool playerTurn = true;
    internal bool rolled = false;
    internal int leftRollCount;

    internal int playerShield, enemyShield;

    public static int rollCount = 3;
    #endregion


    /// <summary>
    /// 从投掷面板选择骰子到组合面板
    /// </summary>
    /// <param name="obj"></param>
    void SelectDiceObject(DiceObject obj)
    {
        rollView.RemoveDiceObject(obj);
        comboView.AddDiceObject(obj);
    }

    /// <summary>
    /// 从组合面板把骰子放回投掷面板
    /// </summary>
    /// <param name="obj"></param>
    void ReturnDiceObject(DiceObject obj)
    {
        comboView.RemoveDiceObject(obj);
        rollView.AddDiceObject(obj);
    }

    /// <summary>
    /// 事件结算的方法
    /// </summary>
    public void Settlement()
    {

        List<EventReward> rewards = data.rewards;

        if (rewards != null && rewards.Count > 0)
        {
            foreach (var r in rewards)
            {
                switch (r.type)
                {
                    case EventReward.Type.Gold:

                        GameController.Instance.GainGold(r.value);
                        break;

                    case EventReward.Type.SkillPoint:
                        GameController.Instance.GainSkillPoint(r.value);
                        break;
                }
            }
        }


    }

    private bool CanExecute(ComboData combo)
    {
        //判断是否能执行所有效果
        foreach (ComboEffect effect in combo.effects)
        {
            //Debug.Log(effect.type);

            //如果是单体技能，但没有选中目标，则无法执行
            if (!effect.isAreaEffect)
            {
                if ((effect.toEnemy && enemyTeamView.selectedCharacter == null) || (!effect.toEnemy && playerTeamView.selectedCharacter == null))
                {
                    return false;
                }

            }


        }

        return true;
    }

    /// <summary>
    /// 玩家回合，结算一个技能的所有效果
    /// </summary>
    /// <param name="combo"></param>
    private void PlayerExecute(ComboData combo)
    {
        //判断是否能执行所有效果
        if (!CanExecute(combo)) return;

        //执行所有效果
        foreach (ComboEffect effect in combo.effects)
        {
            if (combo.se != null)
            {
                AudioManager.Instance.PlaySoundEffect(combo.se);
            }
            switch (effect.type)
            {
                case ComboEffect.EffectType.ShieldDamage:
                    if (!effect.toEnemy)
                    {
                        playerShield -= effect.value;
                        if (playerShield < 0) playerShield = 0;

                    }
                    else
                    {
                        enemyShield -= effect.value;
                        if (enemyShield < 0) enemyShield = 0;

                    }
                    break;

                case ComboEffect.EffectType.Damage:

                    if (effect.toEnemy)
                    {
                        int value = effect.value;
                        if (enemyShield > 0)
                        {
                            if (value > enemyShield)
                            {
                                
                                value -= enemyShield;
                                enemyShield = 0;
                            }
                            else
                            {
                                enemyShield -= value;
                                continue;
                            }
                        }

                        if (!effect.isAreaEffect)
                        {
                            enemyTeamView.selectedCharacter.Damage(value);
                        }
                        else
                        {
                            foreach(CharacterData cd in enemyTeam.characters)
                            {
                                cd.Damage(value);
                            }
                        }
                    }
                    else
                    {
                        if (!effect.isAreaEffect)
                        {
                            CharacterData toDamage = playerTeam.characters[Random.Range(0, playerTeam.characters.Count)];

                            toDamage.Damage(effect.value);
                        }
                        else
                        {
                            foreach (CharacterData cd in playerTeam.characters)
                            {
                                cd.Damage(effect.value);
                            }
                        }
                    }

                    break;

                case ComboEffect.EffectType.Shield:

                    playerShield += effect.value;

                    break;

                case ComboEffect.EffectType.Heal:



                    break;
            }
        }



        //管理角色死亡
        foreach(CharacterData cd in playerTeam.characters)
        {
            if (!cd.IsAlive())
            {
                deadPlayers.Add(cd);
            }
        }

        foreach(CharacterData cd in deadPlayers)
        {
            playerTeam.characters.Remove(cd);
        }

        for(int i = 0; i < enemyTeam.characters.Count; i++)
        {
            if (!enemyTeam.characters[i].IsAlive())
            {
                enemyTeam.characters.RemoveAt(i);
                i--;
            }
        }

        //刷新显示
        playerTeamView.Refresh();
        enemyTeamView.Refresh();
        ShowShield();

        
    }

    private void CheckWin()
    {
        //检测胜负
        if (enemyTeamView.IsOver())
        {
            //获胜时,死亡角色1hp复活
            foreach (CharacterData cd in deadPlayers) cd.ChangeHP(1);
            playerTeam.characters.AddRange(deadPlayers);

            GameBattleScene.Instance.WinBattle();
        }

        if (playerTeamView.IsOver())
        {
            GameController.Instance.GameLose();
        }
    }

    private void EnemyExecute(ComboData combo)
    {
        //执行所有效果
        if (combo!= null && combo.effects!= null && combo.effects.Count > 0)
        {
            if(combo.se!= null)
            {
                AudioManager.Instance.PlaySoundEffect(combo.se);
            }

            foreach (ComboEffect effect in combo.effects)
            {

                switch (effect.type)
                {
                    case ComboEffect.EffectType.ShieldDamage:
                        if (effect.toEnemy)
                        {
                            playerShield -= effect.value;
                            if (playerShield < 0) playerShield = 0;

                        }
                        else
                        {
                            enemyShield -= effect.value;
                            if (enemyShield < 0) enemyShield = 0;

                        }
                        break;

                    case ComboEffect.EffectType.Damage:

                        if (effect.toEnemy)
                        {
                            int value = effect.value;
                            if (playerShield > 0)
                            {
                                if(value > playerShield)
                                {
                                    value -= playerShield;
                                    playerShield = 0;
                                    
                                }
                                else
                                {
                                    playerShield -= value;
                                    continue;
                                }
                            }

                            //随机选择玩家角色
                            if (!effect.isAreaEffect)
                            {
                                CharacterData cd = playerTeam.characters[Random.Range(0, playerTeam.characters.Count)];

                                cd.Damage(value);
                            }
                            else
                            {
                                foreach (CharacterData cd in playerTeam.characters)
                                {
                                    cd.Damage(value);
                                }
                            }
                        }
                        else
                        {
                            
                            if (!effect.isAreaEffect)
                            {

                                int count = enemyTeamView.team.characters.Count;
                                CharacterData toDamage = enemyTeamView.team.characters[Random.Range(0, count)];

                                toDamage.Damage(effect.value);

                                /*
                                if (enemyTeamView.selectedCharacter == null)
                                {
                                    int count = enemyTeamView.team.characters.Count;
                                    enemyTeamView.selectedCharacter =
                                }
                                else
                                {

                                }
                                enemyTeamView.selectedCharacter.Damage(effect.value);*/
                            }
                            else
                            {
                                foreach (CharacterData cd in enemyTeam.characters)
                                {
                                    cd.Damage(effect.value);
                                }
                            }
                        }

                        break;

                    case ComboEffect.EffectType.Shield:

                        enemyShield += effect.value;

                        break;

                    case ComboEffect.EffectType.Heal:



                        break;
                }
            }
        }

        //管理角色死亡
        foreach (CharacterData cd in playerTeam.characters)
        {
            if (!cd.IsAlive())
            {
                deadPlayers.Add(cd);
            }
        }

        foreach (CharacterData cd in deadPlayers)
        {
            playerTeam.characters.Remove(cd);
        }

        for (int i = 0; i < enemyTeam.characters.Count; i++)
        {
            if (!enemyTeam.characters[i].IsAlive())
            {
                enemyTeam.characters.RemoveAt(i);
                i--;
            }
        }

        //刷新显示
        playerTeamView.Refresh();
        enemyTeamView.Refresh();
        ShowShield();
    }

    public string GetRewardsInfo()
    {
        string info = "  ";
        for (int i = 0; i < data.rewards.Count; i++)
        {
            info += data.rewards[i].ToString();
        }

        return info;
    }

    /// <summary>
    /// 进入战斗场景时载入队伍信息
    /// </summary>
    /// <param name="pl"></param>
    /// <param name="enemy"></param>
    public void Init(TeamEventView pl, TeamEventView enemy)
    {
        playerTeamView = pl;
        enemyTeamView = enemy;

        playerTeam = playerTeamView.team;
        enemyTeam = enemyTeamView.team;


        rollButton.onClick.AddListener(delegate {

            if(leftRollCount > 0)
            {
                leftRollCount--;

                if (!rolled)
                {
                    rollView.CreateDiceObjects(playerTeam.characters);

                    foreach (DiceObject obj in rollView.GetDiceObjects())
                    {
                        obj.GetButton().onClick.AddListener(delegate {

                            ClickDice(obj);

                        });
                    }
                }

                rolled = true;
                rollButton.GetComponentInChildren<Text>().text = "Roll(" + leftRollCount + ")";

                if (leftRollCount <= 0) rollButton.interactable = false;

                
                rollView.RollAllDices();
                //显示组合
                rollView.ShowComboHint(comboView.GetObjectList());

            }



        });

        endTurnButton.onClick.AddListener(delegate {

            EndTurn();

        });

        comboView.ShowInfo(false);

        deadPlayers = new List<CharacterData>();
    }

   
    public void StartBattle(BattleData bd)
    {
        data = bd;

        StartPlayerTurn();
    }

    public void EndTurn()
    {
        Debug.Log("结束回合！");
        rollView.ClearDiceObjects();
        comboView.ClearDiceObjects();

        //Debug.Log("敌人数量："+enemyTeam.characters.Count);
        

        if (playerTurn) StartEnemyTurn();
        else StartPlayerTurn();

        
    }

    /// <summary>
    /// 单击骰子对象。
    /// 若对象位于投掷面板，则将其加入组合面板；反之亦然
    /// 刷新组合面板的显示
    /// </summary>
    /// <param name="obj"></param>
    public void ClickDice(DiceObject obj)
    {
        if (!rolled || !playerTurn) return;

        if (rollView.ContainsDiceObject(obj))
        {
            rollView.RemoveDiceObject(obj);
            comboView.AddDiceObject(obj);
        }
        else if (comboView.ContainsDiceObject(obj))
        {
            
            comboView.RemoveDiceObject(obj);
            rollView.AddDiceObject(obj);
        }
        else {

            return;

        }

        rollView.ShowComboHint(comboView.GetObjectList());

        ComboData cd = comboView.FindComboAndShow();

        //Debug.Log(cd);

        if (cd== null)
        {
            comboView.ShowInfo(false);
        }
        //显示combo信息以及确定按钮
        else
        {
            comboView.GetButton().onClick.RemoveAllListeners();
            comboView.GetButton().onClick.AddListener(delegate {

                //Debug.Log("click combo button");

                if (CanExecute(cd))
                {
                    PlayerExecute(cd);

                    //清空comboView里的骰子对象
                    comboView.ClearDiceObjects();

                    //取消显示
                    comboView.ShowCombo(null);

                    //显示组合
                    rollView.ShowComboHint(comboView.GetObjectList());

                    //检测胜利
                    CheckWin();

                }
                else
                {

                }
            });
        }
    }

    /// <summary>
    /// 开始玩家回合
    /// </summary>
    private void StartPlayerTurn()
    {
        endTurnButton.interactable = true;
        rollButton.interactable = true;

        playerShield = 0;
        ShowShield();

        //Debug.Log("Start Player Turn");
        playerTurn = true;
        //rollView.ClearDiceObjects();

        /*
        rollView.CreateDiceObjects(playerTeam.characters);

        foreach(DiceObject obj in rollView.GetDiceObjects())
        {
            obj.GetButton().onClick.AddListener(delegate {

                ClickDice(obj);

            });
        }*/

        rolled = false;

        leftRollCount = rollCount;

        rollButton.GetComponentInChildren<Text>().text = "Roll(" + leftRollCount + ")";

        
        turnText.text = "玩家回合";
    }

    /// <summary>
    /// 开始敌方回合
    /// </summary>
    private void StartEnemyTurn()
    {
        rollButton.interactable = false;
        endTurnButton.interactable = false;

        enemyShield = 0;
        ShowShield();

        playerTurn = false;
        //rollView.ClearDiceObjects();
        rollView .CreateDiceObjects(enemyTeam.characters);


        //rollButton.interactable = false;
        turnText.text = "敌方回合";

        StartCoroutine(EnemyAction());

    }

    private IEnumerator EnemyAction()
    {

        //投一次骰子

        rollView.RollAllDices();
        List<DiceObject> list = rollView.GetDiceObjects();
        yield return new WaitForSeconds(1f);

        //依次使用技能，并判定胜负

        var toDestroy = new List<DiceObject>();

        while (list.Count > 0)
        {
            DiceObject obj = list[0];

            list.RemoveAt(0);

            if (ComboData.MatchCombo(new List<DiceFaceData> { obj.currentFace })==null)
            {
                //Destroy(obj.gameObject);
                toDestroy.Add(obj);
                continue;
            }

            rollView.RemoveDiceObject(obj);
            comboView.AddDiceObject(obj);

            yield return new WaitForSeconds(0.5f);


            ComboData cd = comboView.FindComboAndShow();

            yield return new WaitForSeconds(0.5f);


            //执行技能效果
            EnemyExecute(cd);

            //清空骰子对象
            comboView.ClearDiceObjects();

            //取消combo显示
            comboView.ShowCombo(null);

            //检测胜利
            CheckWin();


            
        }

        foreach (DiceObject obj in toDestroy) Destroy(obj.gameObject);

        //rollView.ClearDiceObjects();
        EndTurn();

        yield return null;
    }

    
    private void ShowShield()
    {
        enemyTeamView.ShowShield(enemyShield);
        playerTeamView.ShowShield(playerShield);
    }


}
