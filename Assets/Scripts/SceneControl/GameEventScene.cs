using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件场景
/// </summary>
public class GameEventScene : SceneStateBase<GameEventScene>
{

    #region 与中介类交互

    //1、玩家队伍数据。从中介类读取、向其写入
    TeamData team;
    List<CharacterData> characters;

    //2、事件数据，只从中介类读取
    //EventData event;

    //事件中所有选项的列表，由此显示文字和选项按钮
    //List<OptionData> optionList; 

    //3、事件结束时的操作，如根据事件结果进行结算等


    #endregion


    #region UI组件
    [SerializeField]
    Image background; //背景图片



    //****************************事件显示
    [SerializeField]
    Text eventTitle, eventDescription; //显示事件标题和描述的文本框

    [SerializeField]
    Transform optionField; //显示选项按钮的区域

    private GameObject optionPrefab; //选项预制体，包括文字说明和按钮
    //List<GameObject> optionObjects;




    //****************************骰子显示
    [SerializeField]
    DiceObjectPanel diceObjectPanel;


    //****************************玩家角色显示

    [SerializeField]
    TeamEventView playerTeamView;
    

    //****************************顶部UI

    [SerializeField]
    StatusBar status;


    //****************************暂停面板
    
    PausePanel pausePanel;
    //[SerializeField]
    Button pauseButton;

    #endregion

    protected override void LoadUIObjects()
    {
        //1、从中介类读取数据，包括事件及选项、玩家的队伍数据等
        team = GameController.Instance.gameData.playerTeamData;
        characters = team.characters;

        //2、改变背景图
        //background.sprite = null;

        //3、创建角色UI

        playerTeamView.CreateCharacterObjects(characters);
        playerTeamView.HideCharacterInfo();
  


        //4、创建事件信息UI
        eventTitle.text = "事件标题";
        eventDescription.text = "事件描述";
        

        GameObject obj1 = Instantiate(optionPrefab, optionField);
        OptionView view1 = obj1.GetComponent<OptionView>();
        view1.SetName("事件结束");
        view1.SetButtonText("返回地图");

        view1.GetButton().onClick.AddListener(delegate {

            BackToMap();
        });

        GameObject obj3 = Instantiate(optionPrefab, optionField);
        OptionView view3 = obj3.GetComponent<OptionView>();
        view3.SetName("投掷骰子");
        view3.SetButtonText("投掷骰子");

        view3.GetButton().onClick.AddListener(delegate {

            RollAllDices();
        });

        GameObject obj2 = Instantiate(optionPrefab, optionField);
        OptionView view2 = obj2.GetComponent<OptionView>();
        view2.SetName("游戏结束");
        view2.SetButtonText("前往结算");

        view2.GetButton().onClick.AddListener(delegate {

            GameOver();
        });

        //状态栏数据
        /*status.SetGold(0);
        status.SetTime(61f);
        status.SetLevel("1-1");*/


        //生成骰子对象
        
        //diceObjectPanel.CreateDiceObjects();

        //生成暂停面板
        pausePanel = Instantiate(Resources.Load<GameObject>("Prefabs/PausePanel"), GameObject.Find("Canvas").transform).GetComponent<PausePanel>();

        pausePanel.quitButton.onClick.AddListener(delegate { BackToMenu(); });
        pausePanel.Resume();

        pauseButton = status.pauseButton;
        pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });

    }

    
    public List<DiceFaceData> RollAllDices()
    {
        if (diceObjectPanel.IsEmpty())
        {
            diceObjectPanel.CreateDiceObjects(characters);
        }

        return diceObjectPanel.RollAllDices();
    }


    private void Update()
    {
        if (!GameController.Instance.pause)
        {
            

            //单击R键投骰子（测试用）
            if (Input.GetKeyUp(KeyCode.R))
            {
                RollAllDices();
            }
        }
    }

    private void Start()
    {
        base.Start();
    }

    private void Awake()
    {
        base.Awake();
    }

    public void BackToMap()
    {
        GameController.Instance.LoadScene("GameMap");
    }

    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        GameController.Instance.LoadScene("GameSettlement");
    }

    protected override void LoadPrefabs()
    {
        
        //characterEventViewPrefab = (GameObject)Resources.Load("Prefabs/CharacterEventViewPrefab");
        optionPrefab = (GameObject)Resources.Load("Prefabs/OptionPrefab");
        //diceObjectPrefab = (GameObject)Resources.Load("Prefabs/DiceObjectPrefab");
    }

    protected override void RefreshUIObjects()
    {

    }

}
