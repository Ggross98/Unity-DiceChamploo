using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件场景中的一个选项
/// 显示信息包括选项名称和具体操作
/// </summary>
public class OptionView : MonoBehaviour
{
    public Text nameText;

    public Button button;

    public void SetName(string s)
    {
        nameText.text = s;
    }

    public void SetButtonText(string s)
    {
        button.GetComponentInChildren<Text>().text = s;
    }

    public Button GetButton()
    {
        return button;
    }

    /// <summary>
    /// 如果无法达成选项条件，则将按钮设置为不可互动
    /// </summary>
    /// <param name="a">按钮是否可互动</param>
    public void SetButtonActive(bool a)
    {
        button.interactable = a;
    }

    public void SetWidth(float width)
    {
        Vector2 _size = GetComponent<RectTransform>().sizeDelta;
        float _width = _size.x;
        transform.localScale = new Vector2(width / _width, width / _width);
    }

}
