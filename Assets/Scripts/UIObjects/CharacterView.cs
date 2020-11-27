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

    //public Image healthBar;

    public Image lockIcon;

    public Text nameText, healthText;

    public Button button;

    //public CharacterData data;


    public void SetInteractive(bool a)
    {
        button.interactable = a;

        lockIcon.gameObject.SetActive(!a);
    }

    public bool GetInteractive()
    {
        return button.interactable;
    }

    public void ShowCharacter(CharacterData cd)
    {
        if(cd == null)
        {
            nameText.text = "";
            healthText.text = "";
            portrait.gameObject.SetActive(false);

        }
        else
        {
            SetName(cd.name);
            SetHealth(cd.hp, cd.maxHp);
            SetPortrait(cd.portrait);

            portrait.sprite = cd.portrait;
            portrait.gameObject.SetActive(true);
        }
    }



    private void SetName(string s)
    {
        nameText.text = s;
    }

    private void SetPortrait(Sprite s)
    {

        portrait.sprite = s;

    }

    private void SetHealth(int hp, int maxHp)
    {
        healthText.text = hp + "/" + maxHp;

    }

    public Button GetButton()
    {
        return button;
    }

}
