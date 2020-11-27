using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    private Text buttonText;

    private Color colorNormal = Color.white, colorHighlighted = Color.gray, colorPressed = new Color(0.8f, 0.8f, 0.8f);

    public void OnPointerDown(PointerEventData eventData)
    {
        SetTextColor(colorPressed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetTextColor(colorHighlighted);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetTextColor(colorNormal);
    }

    public void SetTextColor(Color c)
    {
        buttonText.color = c;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
