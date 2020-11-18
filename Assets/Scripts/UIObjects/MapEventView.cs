using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 地图场景中，每关对应的图标
/// 鼠标经过时显示文字说明；鼠标单击时进入对应关卡
/// 分为可选择、锁定、已通过几种状态
/// </summary>
public class MapEventView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button image;
        
    public Image icon;

    public Text description;

    public GameObject textBar;

    [SerializeField]
    private Sprite lockIcon, skeleton, flag, sword, question;

    public void OnPointerEnter(PointerEventData eventData)
    {
        textBar.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBar.SetActive(false);
    }

    public void SetImage(Sprite s)
    {
        image.GetComponent<Image>().sprite = s;
    }

    public void SetIcon(Sprite s)
    {
        if (s == null) icon.gameObject.SetActive(false);
        else
        {
            icon.sprite = s;
            icon.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type">0：事件；1：战斗；2：Boss战</param>
    /// <param name="accessable">0：锁定；1：可到达；2：已完成</param>
    public void SetStatus(int type, int accessable)
    {
        switch (type)
        {
            case 0:
                //SetIcon(lockIcon);
                SetIcon(question);
                //image.interactable = false;
                break;
            case 1:
                SetIcon(sword);
                
                break;
            case 2:
                SetIcon(skeleton);
                break;
        }

        switch (accessable)
        {
            case 0:
                //SetIcon(lockIcon);
                image.interactable = false;
                break;
            case 1:
                image.interactable = true;
                break;
            case 2:
                SetIcon(flag);
                image.interactable = false;
                break;
        }
    }

    
    public void SetDescription(string s)
    {
        description.text = s;
    }

    public Button GetButton()
    {
        return image;
    }
}
