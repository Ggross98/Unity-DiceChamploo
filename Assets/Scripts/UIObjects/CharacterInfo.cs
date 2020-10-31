using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件、战斗场景中，查看人物信息的面板
/// 信息包括头像、姓名、生命及生命上限、骰子图标
/// </summary>
public class CharacterInfo : MonoBehaviour
{
    public Image portrait;

    public Text nameText;

    public Text healthText;

    //显示骰子信息
    //public List<CharacterDiceView> dices;

    public void SetName(string s)
    {
        nameText.text = s;
    }

    public void SetHealth(int hp, int max)
    {
        healthText.text = hp + "/" + max;
    }

    public void SetActive(bool a)
    {
        gameObject.SetActive(a);
    }

}
