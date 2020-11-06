using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 展示一个骰子六个面的信息
/// </summary>
public class DiceView : MonoBehaviour
{
    Transform diceLayout;

    //T[] contents = new T[6];

    public Sprite[] sprites;

    public Image[] images;

    public void AddDiceFace(/**/) { }

    public void Show()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].sprite = sprites[i];
        }
    }

    private void Awake()
    {
        

        sprites = Resources.LoadAll<Sprite>("Dice");
        images = GetComponentsInChildren<Image>();

        if(sprites.Length!= images.Length)
        {
            Debug.LogError("dice resources error!");
        }
    }

    private void Start()
    {
        Show();
    }

    public void SetSize(float totalWidth)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(totalWidth, (totalWidth-40)/6);
    }

}
