using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    [SerializeField]
    MySlider bgm, se;

    [SerializeField]
    Dropdown dropdown;

    [SerializeField]
    Vector2Int[] resolutions;

    [SerializeField]
    Toggle fullScreenToggle;

    public void Confirm()
    {
        SaveSettings();
        SetActive(false);
    }

    public void Cancel()
    {
        SetActive(false);
    }

    public void SetActive(bool b)
    {
        if (b)
        {
            LoadSettings();
        }
        panel.SetActive(b);


    }

    private void LoadSettings()
    {
        //Screen.resolutions

        bgm.SetValue(AudioManager.Instance.GetBGMVolumeInt(), 100);
        se.SetValue(AudioManager.Instance.GetSEVolumeInt(), 100);

        fullScreenToggle.isOn = Screen.fullScreen;

        for(int i = 0; i < Screen.resolutions.Length; i++)
        {
            if(Screen.currentResolution.width  == resolutions[i].x)
            {
                dropdown.value = i;
                break;
            }
        }
    }

    private void SaveSettings()
    {
        AudioManager.Instance.SetBGMVolume(bgm.value);
        AudioManager.Instance.SetSEVolume(se.value);

        
        int rIndex = dropdown.value;
        int width = resolutions[rIndex].x;
        int height = resolutions[rIndex].y;

        Screen.SetResolution(width, height, fullScreenToggle.isOn);
        //Screen.fullScreen = fullScreenToggle.isOn;

    }

    private void Awake()
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            dropdown.AddOptions(new List<Dropdown.OptionData> { new Dropdown.OptionData(resolutions[i].x + "×" + (resolutions[i].y)) });
        }
    }
}
