using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Text goldText, timeText, levelText;

    //public Transform buttonField;

    public void SetGold(int g)
    {
        goldText.text = "$" + g;

    }

    public void SetTime(float seconds)
    {
        timeText.text = Utils.FormatTime(seconds);

    }

    public void SetLevel(string s)
    {
        levelText.text = "level "+s;
    }

    

}
