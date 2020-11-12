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

    #endregion


    #region 回合战斗管理
    TeamData playerTeam, enemyTeam;

    //List<CharacterData> playerCharacters;
    //List<CharacterData> enemyCharacters;

    //CharacterData selectedPlayer, selectedEnemy;

    public bool playerTurn = true;
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
    /// 玩家回合，结算一个技能的所有效果
    /// </summary>
    /// <param name="combo"></param>
    public void PlayerExecute(ComboData combo)
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
                    return;
                }

            }


        }

        //执行所有效果
        foreach (ComboEffect effect in combo.effects)
        {
            Debug.Log(effect.type);


            switch (effect.type)
            {
                case ComboEffect.EffectType.Damage:

                    if (effect.toEnemy)
                    {
                        if (!effect.isAreaEffect)
                        {
                            enemyTeamView.selectedCharacter.Damage(effect.value);
                        }
                        else
                        {
                            foreach(CharacterData cd in enemyTeam.characters)
                            {
                                cd.Damage(effect.value);
                            }
                        }
                    }
                    else
                    {
                        if (!effect.isAreaEffect)
                        {
                            playerTeamView.selectedCharacter.Damage(effect.value);
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



                    break;

                case ComboEffect.EffectType.Heal:



                    break;
            }
        }


        //刷新显示
        playerTeamView.Refresh();
        enemyTeamView.Refresh();

        //检测胜负
        if (enemyTeamView.IsOver())
        {
            GameBattleScene.Instance.WinBattle();
        }

        if (playerTeamView.IsOver())
        {
            GameController.Instance.GameLose();
        }
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

            rollView.RollAllDices();

        });

        endTurnButton.onClick.AddListener(delegate {

            EndTurn();

        });

        comboView.ShowInfo(false);
    }

   
    public void StartBattle()
    {
        StartPlayerTurn();
    }

    public void EndTurn()
    {
        Debug.Log("结束回合！");
        rollView.ClearDiceObjects();
        comboView.ClearDiceObjects();

        Debug.Log("敌人数量："+enemyTeam.characters.Count);
        

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


        }

        ComboData cd = comboView.FindComboAndShow();

        Debug.Log(cd);

        if (cd== null)
        {
            comboView.ShowInfo(false);
        }
        else
        {
            comboView.GetButton().onClick.RemoveAllListeners();
            comboView.GetButton().onClick.AddListener(delegate {

                //Debug.Log("click combo button");

                PlayerExecute(cd);

            });
        }
    }

    /// <summary>
    /// 开始玩家回合
    /// </summary>
    private void StartPlayerTurn()
    {
        Debug.Log("Start Player Turn");
        playerTurn = true;
        //rollView.ClearDiceObjects();


        rollView.CreateDiceObjects(playerTeam.characters);

        foreach(DiceObject obj in rollView.GetDiceObjects())
        {
            obj.GetButton().onClick.AddListener(delegate {

                ClickDice(obj);

            });
        }

        rollButton.interactable = true;
        turnText.text = "玩家回合";
    }

    /// <summary>
    /// 开始敌方回合
    /// </summary>
    private void StartEnemyTurn()
    {
        playerTurn = false;
        //rollView.ClearDiceObjects();
        rollView .CreateDiceObjects(enemyTeam.characters);


        rollButton.interactable = false;
        turnText.text = "敌方回合";

    }

    



}
