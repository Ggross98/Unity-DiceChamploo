using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBattleScene : SceneStateBase
{

    
    PausePanel pausePanel;

    [SerializeField]
    Button pauseButton;

    //****************************玩家、敌人角色显示
    private GameObject characterEventViewPrefab;

    private List<CharacterEventView> playerCharacterViewList = new List<CharacterEventView>();
    private List<CharacterEventView> enemyCharacterViewList = new List<CharacterEventView>();


    [SerializeField]
    Transform playerCharacterViewField; //显示玩家角色的区域，使用水平网格布局

    [SerializeField]
    CharacterInfo playerCharacterInfo; //鼠标点击玩家角色时，在上方显示具体信息


    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

    

    public override void LoadUIObjects()
    {
        //生成暂停面板
        pausePanel = Instantiate(Resources.Load<GameObject>("Prefabs/PausePanel"),GameObject.Find("Canvas").transform).GetComponent<PausePanel>();

        pausePanel.quitButton.onClick.AddListener(delegate { BackToMenu(); });
        pausePanel.Resume();

        pauseButton.onClick.AddListener(delegate { pausePanel.Pause(); });
    }

    public override void RefreshUIObjects()
    {
        throw new System.NotImplementedException();
    }

    public override void LoadPrefabs()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        LoadUIObjects();
    }


}
