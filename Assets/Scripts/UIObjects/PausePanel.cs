using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制暂停面板的类
/// </summary>
public class PausePanel : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;

    public Button resumeButton, quitButton;



    public void Pause()
    {
        pausePanel.SetActive(true);
        GameController.Instance.Pause();
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        GameController.Instance.Resume();

    }


}
