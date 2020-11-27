using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主菜单ui管理类
/// 
/// </summary>
public class MainMenuScene : SceneStateBase<MainMenuScene>
{
    [SerializeField]
    private SettingPanel settingPanel;

    [SerializeField]
    private GameObject tutorialPanel;

    protected override void LoadPrefabs()
    {
        //throw new System.NotImplementedException();
    }

    protected override void LoadUIObjects()
    {
        //throw new System.NotImplementedException();
    }

    public void Quit()
    {
        GameController.Instance.QuitGame();
    }

    protected override void RefreshUIObjects()
    {
        //throw new System.NotImplementedException();
    }

    public void StartGame()
    {
        GameController.Instance.LoadScene("GameStart");
    }

    private void Start()
    {
        base.Start();

        AudioManager.Instance.PlayBGM("BGM_EveryDayIsNight");
    }

    private void Awake()
    {

        Screen.SetResolution(1920, 1080, true);
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
    }

    public void Tutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void HideTutorial()
    {
        tutorialPanel.SetActive(false);
    }


}
