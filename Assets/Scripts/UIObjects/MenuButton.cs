using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 菜单中按钮在鼠标经过、单击时音效的管理
/// </summary>
public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    private bool IsButtonActive()
    {
        Button button = GetComponent<Button>();
        return button!=null && button.interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //AudioManager.Instance.PlaySoundEffect("SE_Button1");

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(IsButtonActive())
            AudioManager.Instance.PlaySoundEffect("SE_Button1");

    }
}
