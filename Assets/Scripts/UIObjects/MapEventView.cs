using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 地图场景中，每关对应的图标
/// 鼠标经过时显示文字说明；鼠标单击时进入对应关卡
/// 如果该关已经通过，或与角色当前位置距离不为1，则不能互动
/// </summary>
public class MapEventView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button image;

    public Text description;

    public GameObject textBar;

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

    public void SetDescription(string s)
    {
        description.text = s;
    }

    public Button GetButton()
    {
        return image;
    }
}
