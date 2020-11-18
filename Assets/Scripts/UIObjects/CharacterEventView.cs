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
    [SerializeField]
    Image portrait, aura;

    [SerializeField]
    MySlider slider;

    [SerializeField]
    Button button;

    private void SetImage(Sprite s)
    {
        portrait.sprite = s;
    }

    public Button GetButton()
    {
        return button;
    }

    public void ShowHP(int hp, int maxHp) {

        slider.SetValue(hp, maxHp);

    }

    public void ShowAura(bool b)
    {
        aura.gameObject.SetActive(b);
    }
    /// <summary>
    /// 设置是否为敌人角色，若为敌人角色则将图片水平翻转
    /// </summary>
    /// <param name="a"></param>
    public void SetEnemy(bool a)
    {
        portrait.rectTransform.rotation = new Quaternion(0,a ? 180 :0,0,0);
    }

    public void ShowCharacter(CharacterData data)
    {
        SetImage(data.portrait);
        slider.SetValue(data.hp, data.maxHp);
    }

    public void SetSize(float height)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(0.47f*height, height);
    }

    private void Start()
    {
        ShowAura(false);
    }
}
