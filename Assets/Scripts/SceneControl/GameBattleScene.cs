using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBattleScene : SceneStateBase
{

    #region 与中介类交互

    //1、玩家队伍数据。从中介类读取、向其写入
    TeamData team;
    List<CharacterData> playerCharacters;

    //2、战斗事件数据。只读
    //BattleEventData battleEvent;

    //3、敌人列表
    List<CharacterData> enemyCharacters;

    //4、回合控制，AI等

    public bool playerTurn = true; //当前是否是玩家回合

    public void EndTurn()
    {
        if (playerTurn) StartEnemyTurn();
        else StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        playerTurn = true;
        dicePanel.ClearDiceObjects();
        dicePanel.CreateDiceObjects(playerCharacters);

        rollButton.interactable = true;
        turnText.text = "玩家回合";
    }

    private void StartEnemyTurn()
    {
        playerTurn = false;
        dicePanel.ClearDiceObjects();
        dicePanel.CreateDiceObjects(enemyCharacters);


        rollButton.interactable = false;
        turnText.text = "敌方回合";

    }

    public void EnemyAction() { }

    public void StartBattle() { }

    //5、结束事件时调用的内容
    private void EndBattle() { }

    #endregion

    #region UI组件
    PausePanel pausePanel;

    //****************************骰子和战斗区域
    [SerializeField]
    DiceObjectPanel dicePanel;

    [SerializeField]
    Button rollButton, endTurnButton;

    [SerializeField]
    Text turnText;

    //****************************玩家、敌人角色显示
   
    [SerializeField]
    TeamEventView playerTeamView;


    [SerializeField]
    TeamEventView enemyTeamView;

    //****************************状态栏

    [SerializeField]
    StatusBar status;

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

    public void PlayerRollDice()
    {
        dicePanel.RollAllDices();
    }

    

    protected override void LoadUIObjects()
    {
        //读取玩家队伍数据
        team = GameController.Instance.gameData.playerTeamData;
        playerCharacters = team.characters;

        //TODO: 从事件中读取敌人数据 

        enemyCharacters = new List<CharacterData>() {

            CharacterData.MainCharacter_1.Model()

        };


        //生成玩家角色UI
        playerTeamView.CreateCharacterObjects(playerCharacters);
        playerTeamView.HideCharacterInfo();
        

        //生成敌人角色UI
        enemyTeamView.CreateCharacterObjects(enemyCharacters);
        enemyTeamView.SetEnemy(true);
        enemyTeamView.HideCharacterInfo();


        //状态栏数据
        /*status.SetGold(0);
        status.SetTime(61f);
        status.SetLevel("1-1");*/



        //生成暂停面板
        pausePanel = Instantiate(Resources.Load<GameObject>("Prefabs/PausePanel"),GameObject.Find("Canvas").transform).GetComponent<PausePanel>();

        pausePanel.quitButton.onClick.AddListener(delegate { BackToMenu(); });
        pausePanel.Resume();

        status.pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });
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
        StartPlayerTurn();
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
