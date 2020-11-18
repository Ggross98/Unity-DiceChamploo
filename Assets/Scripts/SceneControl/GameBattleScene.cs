using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBattleScene : SceneStateBase<GameBattleScene>
{

    #region 与中介类交互

    [SerializeField]
    BattleSystem battleSystem;

    public void EnemyAction() { }

    public void WinBattle()
    {
        wonRewards.text = battleSystem.GetRewardsInfo();

        wonPanel.SetActive(true);



        //Debug.Log("Battle Won!");
    }

    public void BattleSettlement()
    {
        battleSystem.Settlement();

        GameController.Instance.FinishStage();
    }

    //5、结束事件时调用的内容
    private void EndBattle() { }

    #endregion

    #region UI组件


    PausePanel pausePanel;

    //****************************骰子和战斗区域
    /*
    [SerializeField]
    DiceObjectPanel dicePanel;

    [SerializeField]
    Button rollButton, endTurnButton;

    [SerializeField]
    Text turnText;*/

    //****************************玩家、敌人角色显示
   
    [SerializeField]
    TeamEventView playerTeamView;


    [SerializeField]
    TeamEventView enemyTeamView;

    //****************************状态栏



    [SerializeField]
    StatusBar status;

    //****************************战斗胜利
    [SerializeField]
    GameObject wonPanel;

    [SerializeField]
    Text wonRewards;

    #endregion

    
    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

    public void BackToMap()
    {
        GameController.Instance.LoadScene("GameMap");
        EndBattle();
    }

    /*
    public void PlayerRollDice()
    {
        dicePanel.RollAllDices();
    }*/

    

    protected override void LoadUIObjects()
    {
        //读取玩家队伍数据
        /*team = GameController.Instance.gameData.playerTeamData;
        playerCharacters = team.characters;*/

        BattleData battleData = (BattleData)GameController.Instance.gameData.progress.nextEventData;

        //TODO: 从事件中读取敌人数据 

        /*
        TeamData enemyTeam = new TeamData();

        List<CharacterData> enemyCharacters = new List<CharacterData>() {

            CharacterData.MainCharacter_1.Model()

        };

        enemyTeam.characters = enemyCharacters;*/

        
        //生成玩家角色UI
        playerTeamView.CreateCharacterObjects(GameController.Instance.gameData.playerTeamData);
        playerTeamView.HideCharacterInfo();


        //生成敌人角色UI
        enemyTeamView.CreateCharacterObjects(battleData.enemyTeam.Model());
        enemyTeamView.SetEnemy(true);
        enemyTeamView.HideCharacterInfo();


        

        //生成暂停面板
        pausePanel = Instantiate(Resources.Load<GameObject>("Prefabs/PausePanel"),GameObject.Find("Canvas").transform).GetComponent<PausePanel>();

        pausePanel.quitButton.onClick.AddListener(delegate { BackToMenu(); });
        pausePanel.Resume();

        status.pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });


        //启动战斗系统

        battleSystem.Init(playerTeamView, enemyTeamView);
        battleSystem.StartBattle(battleData);

    }

    protected override void RefreshUIObjects()
    {
        //throw new System.NotImplementedException();
    }

    protected override void LoadPrefabs()
    {
        //characterEventViewPrefab = (GameObject)Resources.Load("Prefabs/CharacterEventViewPrefab");
    }

    private void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        base.Start();

        //StartPlayerTurn();
    }

    private void Update()
    {
        if (!GameController.Instance.pause)
        {
            
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                BackToMap();
            }
        
        }
    }


}
