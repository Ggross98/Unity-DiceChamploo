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

    private void SetImage(Sprite s)
    {
        portrait.sprite = s;
    }

    public Button GetButton()
    {
        return button;
    }

    /// <summary>
    /// 设置是否为敌人角色，若为敌人角色则将图片水平翻转
    /// </summary>
    /// <param name="a"></param>
    public void SetEnemy(bool a)
    {
        portrait.rectTransform.rotation = new Quaternion(0,a ? 180 :0,0,0);
    }

<<<<<<< Updated upstream
=======
    public void ShowCharacter(CharacterData data)
    {
        SetImage(data.portrait);
    }

    public void SetSize(float height)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(0.47f*height, height);
    }
>>>>>>> Stashed changes
}
