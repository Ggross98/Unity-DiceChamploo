using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Text goldText, timeText, levelText;

    public Button pauseButton;

    //public Transform buttonField;

    private void SetGold(int g)
    {
        goldText.text = "$" + g;

    }

    private void SetTime(float seconds)
    {
        timeText.text = Utils.FormatTime(seconds);

    }

    private void SetLevel(string s)
    {
        levelText.text = "level "+s;
    }

    private void Update()
    {
        GameData gd = GameController.Instance.gameData;

        SetGold(gd.gold);
        SetTime(gd.time);
        //TODO: 显示关卡
        SetLevel("1-1");
    }



}
