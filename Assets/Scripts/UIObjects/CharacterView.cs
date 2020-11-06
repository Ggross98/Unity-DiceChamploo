using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Map界面中角色预览，包括头像、生命和姓名文字
/// </summary>
public class CharacterView : MonoBehaviour
{
    public Image portrait;

    public Image healthBar;

    public Image lockIcon;

    public Text nameText, healthText;

    public Button button;


    public void SetInteractive(bool a)
    {
        button.interactable = a;

        lockIcon.gameObject.SetActive(!a);
    }



    public void SetName(string s)
    {
        nameText.text = s;
    }

    public void SetPortrait(Sprite s)
    {

        portrait.sprite = s;

    }

    public void SetHealth(int hp, int maxHp)
    {
        healthText.text = hp + "/" + maxHp;

    }

    public Button GetButton()
    {
        return button;
    }

}
