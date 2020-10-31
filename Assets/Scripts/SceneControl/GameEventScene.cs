using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventScene : SceneStateBase
{
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
    private GameObject dicePrefab; //骰子预制体
    //List<GameObject> diceObjects = new List<GameObject>();

    [SerializeField]
    Transform diceField; //投掷骰子的区域


    //****************************玩家角色显示
    private GameObject characterEventViewPrefab;

    private List<CharacterEventView> characterEventViewList = new List<CharacterEventView>();

    [SerializeField]
    Transform characterEventViewField; //显示玩家角色的区域，使用水平网格布局

    [SerializeField]
    CharacterInfo characterInfo; //鼠标点击玩家角色时，在上方显示具体信息


    //****************************顶部UI

    [SerializeField]
    StatusBar status;


    //****************************暂停面板
    
    PausePanel pausePanel;
    [SerializeField]
    Button pauseButton;

    public override void LoadUIObjects()
    {
        //1、从中介类读取数据，包括事件及选项、玩家的队伍数据等
        //EventData, OptionData, CharacterData

        //2、改变背景图
        //background.sprite = null;

        //3、创建角色UI
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = Instantiate(characterEventViewPrefab, characterEventViewField);

            obj.name = "玩家角色" + (i + 1);

            CharacterEventView view = obj.GetComponent<CharacterEventView>();
            characterEventViewList.Add(view);

            view.GetButton().onClick.AddListener(delegate 
            {
                characterInfo.SetName(obj.name);

                characterInfo.SetActive(true);
            });

        }

        characterInfo.SetActive(false);


        //4、创建事件信息UI
        eventTitle.text = "事件标题";
        eventDescription.text = "事件描述";
        /*
        for(int i = 0; i < 0; i++)
        {

            GameObject obj = Instantiate(optionPrefab, optionField);
            
            //...改变显示信息

            //添加点击事件
            obj.GetComponent<Button>().onClick.AddListener(
                delegate { });
        }*/
        GameObject obj1 = Instantiate(optionPrefab, optionField);
        OptionView view1 = obj1.GetComponent<OptionView>();
        view1.SetName("事件结束");
        view1.SetButtonText("返回地图");

        view1.GetButton().onClick.AddListener(delegate {

            BackToMap();
        });

        GameObject obj2 = Instantiate(optionPrefab, optionField);
        OptionView view2 = obj2.GetComponent<OptionView>();
        view2.SetName("游戏结束");
        view2.SetButtonText("前往结算");

        view2.GetButton().onClick.AddListener(delegate {

            GameOver();
        });

        //生成暂停面板
        pausePanel = Instantiate(Resources.Load<GameObject>("Prefabs/PausePanel"), GameObject.Find("Canvas").transform).GetComponent<PausePanel>();

        pausePanel.quitButton.onClick.AddListener(delegate { BackToMenu(); });
        pausePanel.Resume();

        pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });

    }

    public override void RefreshUIObjects()
    {
        
    }


    private void Update()
    {
        if (!GameController.Instance.pause)
        {
            //单击右键隐藏角色信息显示
            if (Input.GetMouseButtonUp(1))
            {
                characterInfo.SetActive(false);
            }
        }
    }

    private void Start()
    {

        LoadPrefabs();

        LoadUIObjects();
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

    public override void LoadPrefabs()
    {
        //dicePrefab = 
        characterEventViewPrefab = (GameObject)Resources.Load("Prefabs/CharacterEventViewPrefab");
        optionPrefab = (GameObject)Resources.Load("Prefabs/OptionPrefab");

    }
}
