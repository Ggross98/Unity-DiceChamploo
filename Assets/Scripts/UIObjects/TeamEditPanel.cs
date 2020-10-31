using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 队伍编辑面板
/// </summary>
public class TeamEditPanel : MonoBehaviour
{
    public Text nameText;

    public void SetName(string s)
    {
        nameText.text = "姓名："+s;
    }

    public void SetActive(bool a)
    {
        gameObject.SetActive(a);
    }
}
