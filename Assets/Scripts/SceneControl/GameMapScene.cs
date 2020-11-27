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
    public void ConfirmDismiss() {


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

        //隐藏确认界面
        dismissConfirmPanel.SetActive(false);

    }

    public void CancelDismiss()
    {
        dismissConfirmPanel.SetActive(false);
    }

    public void PressDismissButton()
    {
        if (selectedCharacter == null) return;

        if (characters.Count <= 1) return;

        //显示确认界面
        dismissConfirmPanel.SetActive(true);
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

    [SerializeField]
    Scrollbar teamScroll;

    GameObject characterViewPrefab; //单个角色预览的预制体
    List<CharacterView> characterViewList = new List<CharacterView>();

    private static int teamMaxCount = 5;

    //***************************队伍编辑面板
    [SerializeField]
    TeamEditPanel teamEditPanel;

    [SerializeField]
    CharacterInfo characterInfo;

    //[SerializeField]
    //Button upgradeButton, dismissButton;

    [SerializeField]
    GameObject dismissConfirmPanel;

    [SerializeField]
    Text skillPointTotal, skillPointUpgrade;


    //****************************地图面板

    GameObject mapViewPrefab, mapRoadPrefab; //地图上一个关卡的预制体

    [SerializeField]
    Transform mapViewField;

    float fieldWidth, fieldHeight;

    List<MapEventView> mapViewList = new List<MapEventView>();

    //****************************顶部UI

    [SerializeField]
    StatusBar status;

    [SerializeField]
    GameObject teamSizeWarning;

    bool teamSizeOut = false;

    
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

    /*
    internal void StartEvent(EventDataBase data)
    {
        GameController.Instance.gameData.progress.nextEventData = data;

        GameController.Instance.LoadScene("GameEvent");
        AudioManager.Instance.PlaySoundEffect("SE_Beep1");
    }

    internal void StartEvent(Stage s)
    {
        GameController.Instance.gameData.progress.playerPos = s.pos;

        StartEvent(s.data);
    }

    public void StartBattle(EventDataBase data)
    {
        GameController.Instance.gameData.progress.nextEventData = data;

        GameController.Instance.LoadScene("GameBattle");
        AudioManager.Instance.PlaySoundEffect("SE_Beep1");
    }

    internal void StartBattle(Stage s)
    {
        GameController.Instance.gameData.progress.playerPos = s.pos;

        StartBattle(s.data);
    }*/


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

        Debug.Log("Creating map panel...");

        mapPanel.SetActive(true);

        Stage[,] stages = GameController.Instance.gameData.progress.stages;

        fieldWidth = mapViewField.GetComponent<RectTransform>().sizeDelta.x;
        fieldHeight = mapViewField.GetComponent<RectTransform>().sizeDelta.y;

        int maxX = GameController.Instance.gameData.progress.width;
        int maxY = GameController.Instance.gameData.progress.height;

        float width = fieldWidth / maxX;
        float height = fieldHeight / maxY;

        //根据关卡生成地图
        for(int i = 0; i < maxX; i++)
        {
            for(int j = 0; j < maxY; j++)
            {
                Stage stage = stages[i, j];

                if (stage != null)
                {
                    
                    //生成道路
                    if(j < maxY-1 && stages[i, j + 1] != null)
                    {
                        GameObject road = Instantiate(mapRoadPrefab, mapViewField);
                        road.GetComponent<RectTransform>().sizeDelta = new Vector2(width, width / 10);
                        road.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
                        road.transform.localPosition = new Vector2(i * width - fieldWidth / 2 + width / 2, j * height - fieldHeight / 2 + height / 2);
                    }

                    if(i < maxX-1 && stages[i + 1, j]!= null)
                    {
                        GameObject road = Instantiate(mapRoadPrefab, mapViewField);
                        road.GetComponent<RectTransform>().sizeDelta = new Vector2(width, width / 10);
                        road.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
                        road.transform.localPosition = new Vector2(i * width - fieldWidth / 2 + width / 2, j * height - fieldHeight / 2 + height / 2);
                    }

                    //生成地图图标

                    GameObject obj = Instantiate(mapViewPrefab, mapViewField);
                    obj.name = stage.pos+"";

                    obj.transform.localPosition = new Vector2(i*width - fieldWidth/2 + width/2 , j*height - fieldHeight/2 + height/2);

                    MapEventView view = obj.GetComponent<MapEventView>();

                    mapViewList.Add(view);

                    string mapInfo = "";
                    if (stage.isBossStage) mapInfo = "BOSS关卡";
                    else if (stage.IsBattle()) mapInfo = "战斗！";
                    else mapInfo = "随机事件";
                    view.SetDescription(mapInfo);

                    view.GetButton().onClick.AddListener(delegate
                    {
                        if (!teamSizeOut)
                        {
                            GameController.Instance.StartStage(stage);

                        }

                    });


                    //根据关卡状态修改图标
                    int[] status = GameController.Instance.gameData.progress.GetStageStatus(stage);
                    view.SetStatus(status[0],status[1]);


                }
            }
        }

        Debug.Log("Map panel created!");
        
        //加载队伍数据
        team = GameController.Instance.gameData.playerTeamData;
        characters = team.characters;

        Debug.Log("Creating team preview...");
        //生成左侧队伍预览
        for(int i = 0; i < Mathf.Max(5, characters.Count); i++)
        {
            GameObject obj = Instantiate(characterViewPrefab, characterViewField);
            obj.name = "角色预览" + (i + 1);

            CharacterView view = obj.GetComponent<CharacterView>();
            
            characterViewList.Add(view);
        }
        Debug.Log("Team preview created!");

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
        //pausePanel.Resume();

        pauseButton = status.pauseButton;
        pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });

        pausePanel.gameObject.SetActive(false);

    }

    protected override void RefreshUIObjects()
    {

        //刷新队伍预览
        skillPointTotal.text = "技能点数：" + GameController.Instance.gameData.skillPoint;

        if (selectedCharacter != null)
            skillPointUpgrade.text = "技能点：" + selectedCharacter.UpgradeCost();

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

                    skillPointTotal.text = "技能点数：" + GameController.Instance.gameData.skillPoint;

                    if (selectedCharacter != null)
                        skillPointUpgrade.text = "技能点：" + selectedCharacter.UpgradeCost();

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

        if (characterViewList.Count > teamMaxCount)
        {
            CharacterView view = characterViewList[teamMaxCount];
            if (!view.GetInteractive())
            {
                characterViewList.Remove(view);
                Destroy(view.gameObject);
            }

        }

        if(characterViewList.Count > teamMaxCount)
        {
            teamScroll.gameObject.SetActive(true);

            teamSizeOut = true;
            teamSizeWarning.SetActive(true);
        }
        else
        {
            teamScroll.gameObject.SetActive(false);

            teamSizeOut = false;
            teamSizeWarning.SetActive(false);
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
        mapRoadPrefab = (GameObject)Resources.Load("Prefabs/MapRoadPrefab");
    }
}
