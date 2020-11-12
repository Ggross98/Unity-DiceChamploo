using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 地图场景，包括两个主要面板：地图和队伍编辑
/// </summary>
public class GameMapScene : SceneStateBase<GameMapScene>
{
    #region 数据交互部分

    //1、玩家队伍数据。从中介类读取、向其写入
    TeamData team;
    List<CharacterData> characters;

    //选中的角色
    CharacterData selectedCharacter;


    //2、事件数据，由此生成地图ui。只从中介类读取
    //List<EventData> events;

    //private void CreateMapEventView() { }

    
    /// <summary>
    /// 升级当前选中角色
    /// </summary>
    public void Upgrade() {

        if (selectedCharacter == null) return;

        if (GameController.Instance.UpgradeCharacter(selectedCharacter))
        {
            //刷新ui显示
            RefreshUIObjects();

            characterInfo.ShowCharacter(selectedCharacter);
        }
    }

    /// <summary>
    /// 解雇当前角色
    /// </summary>
    public void Dismiss() {

        if (selectedCharacter == null) return;

        //决定删除之后选定的角色
        int index = characters.FindIndex(a => a==selectedCharacter);
        if (index == characters.Count - 1) index--;

        if (GameController.Instance.DismissCharacter(selectedCharacter))
        {
            //刷新ui显示
            RefreshUIObjects();

            selectedCharacter = characters[index];
            characterInfo.ShowCharacter(selectedCharacter);
        }

        
    }

    



    #endregion

    #region UI Components

    public GameObject mapPanel;
    enum CurrentPanel { MAP, TEAM }

    private CurrentPanel panel = CurrentPanel.MAP;


    //****************************队伍预览
    [SerializeField]
    Transform characterViewField;

    [SerializeField]
    Text teamCountText;

    GameObject characterViewPrefab; //单个角色预览的预制体
    List<CharacterView> characterViewList = new List<CharacterView>();

    //***************************队伍编辑面板
    [SerializeField]
    TeamEditPanel teamEditPanel;

    [SerializeField]
    CharacterInfo characterInfo;

    [SerializeField]
    Button upgradeButton, dismissButton;


    //****************************地图面板

    GameObject mapViewPrefab; //地图上一个关卡的预制体

    [SerializeField]
    Transform mapViewField;

    List<MapEventView> mapViewList = new List<MapEventView>();

    //****************************顶部UI

    [SerializeField]
    StatusBar status;

    
    //****************************暂停面板
    PausePanel pausePanel;
    //[SerializeField]
    Button pauseButton;

    #endregion

    /// <summary>
    /// 退出游戏至主界面
    /// </summary>
    public void BackToMenu()
    {

        GameController.Instance.LoadScene("MainMenu");

    }


    public void StartEvent(/**/)
    {
        GameController.Instance.LoadScene("GameEvent");
        AudioManager.Instance.PlaySoundEffect("SE_Beep1");
    }

    public void StartBattle(/**/)
    {
        GameController.Instance.LoadScene("GameBattle");
        AudioManager.Instance.PlaySoundEffect("SE_Beep1");
    }


    /// <summary>
    /// 切换地图和队伍编辑界面
    /// </summary>
    public void SwtichPanel()
    {
        if (panel == CurrentPanel.MAP)
        {
            SwitchPanelTo(CurrentPanel.TEAM);
        }
        else
        {
            SwitchPanelTo(CurrentPanel.MAP);
        }
    }

    private void SwitchPanelTo(CurrentPanel cp)
    {
        if (cp == CurrentPanel.TEAM)
        {
            mapPanel.SetActive(false);
            teamEditPanel.SetActive(true);

            panel = CurrentPanel.TEAM;
        }
        else if (cp == CurrentPanel.MAP)
        {
            mapPanel.SetActive(true);
            teamEditPanel.SetActive(false);

            panel = CurrentPanel.MAP;
        }
    }


    protected override void LoadUIObjects()
    {
        //加载事件数据

        //生成地图面板
        mapPanel.SetActive(true);
        for(int i = 0; i < 1; i++)
        {
            GameObject obj = Instantiate(mapViewPrefab, mapViewField);
            obj.name = "关卡" + (i+1);

            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-200,0);

            MapEventView view = obj.GetComponent<MapEventView>();

            mapViewList.Add(view);

            view.SetDescription("事件说明。单击进入事件");

            view.GetButton().onClick.AddListener(delegate 
            {
                StartEvent();

            });
        }

        for(int i = 1; i < 2; i++)
        {
            GameObject obj = Instantiate(mapViewPrefab, mapViewField);
            obj.name = "关卡" + (i + 1);

            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(200,0);

            MapEventView view = obj.GetComponent<MapEventView>();

            mapViewList.Add(view);

            view.SetDescription("战斗说明。单击进入战斗");

            view.GetButton().onClick.AddListener(delegate
            {
                StartBattle();

            });
        }

        //加载队伍数据
        team = GameController.Instance.gameData.playerTeamData;
        characters = team.characters;

        //生成左侧队伍预览
        for(int i = 0; i < 5; i++)
        {
            GameObject obj = Instantiate(characterViewPrefab, characterViewField);
            obj.name = "角色预览" + (i + 1);

            CharacterView view = obj.GetComponent<CharacterView>();
            
            characterViewList.Add(view);
        }

        RefreshUIObjects();

        

        //characterInfo.ShowCharacter();

        //生成队伍编辑面板
        teamEditPanel.SetActive(false);

        //状态栏数据
        /*status.SetGold(0);
        status.SetTime(61f);
        status.SetLevel("1-1");*/

        //生成暂停面板
        pausePanel = Instantiate(Resources.Load<GameObject>("Prefabs/PausePanel"), GameObject.Find("Canvas").transform).GetComponent<PausePanel>();

        pausePanel.quitButton.onClick.AddListener(delegate { BackToMenu(); });
        pausePanel.Resume();

        pauseButton = status.pauseButton;
        pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });

    }

    protected override void RefreshUIObjects()
    {

        //刷新队伍预览

        teamCountText.text = team.Count() + "/5";

        for (int i = 0; i < characterViewList.Count; i++)
        {
            
            CharacterView view = characterViewList[i];

            view.GetButton().onClick.RemoveAllListeners();

            if (i < characters.Count)
            {
                view.SetInteractive(true);
                //view.data = characters[i];
                CharacterData cd = characters[i];

                view.ShowCharacter(cd);

                view.GetButton().onClick.AddListener(delegate
                {
                    selectedCharacter = cd;

                    characterInfo.ShowCharacter(selectedCharacter);

                    SwitchPanelTo(CurrentPanel.TEAM);

                });
            }
            else
            {
                view.ShowCharacter(null);
                view.SetInteractive(false);
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

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void LoadPrefabs()
    {
        characterViewPrefab = (GameObject)Resources.Load("Prefabs/CharacterViewPrefab");
        mapViewPrefab = (GameObject)Resources.Load("Prefabs/MapViewPrefab");

    }
}
