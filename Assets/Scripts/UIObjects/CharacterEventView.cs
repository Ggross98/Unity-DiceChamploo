using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 事件及战斗场景中角色对象
/// 包括图片
/// </summary>
public class CharacterEventView : MonoBehaviour
{
    public Image portrait;

    public Button button;

    public void SetImage(Sprite s)
    {
        portrait.sprite = s;
    }

    public Button GetButton()
    {
        return button;
    }

}
