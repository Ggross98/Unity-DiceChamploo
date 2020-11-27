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

    [SerializeField]
    MySlider bgm, se;

    public Button resumeButton, quitButton;


    public void Pause()
    {
        bgm.SetValue(AudioManager.Instance.GetBGMVolumeInt(), 100);
        se.SetValue(AudioManager.Instance.GetSEVolumeInt(), 100);


        pausePanel.SetActive(true);
        GameController.Instance.Pause();
    }

    public void Resume()
    {
        AudioManager.Instance.SetBGMVolume(bgm.value);
        AudioManager.Instance.SetSEVolume(se.value);

        pausePanel.SetActive(false);
        GameController.Instance.Resume();

    }


}
