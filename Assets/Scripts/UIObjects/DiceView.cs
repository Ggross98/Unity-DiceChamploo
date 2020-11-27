using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 展示一个骰子六个面的信息
/// </summary>
public class DiceView : MonoBehaviour
{
    //Transform diceLayout;

    //T[] contents = new T[6];

    private Sprite[] sprites;

    private Image[] images;

    //public void AddDiceFace(/**/) { }

    public void Show()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].sprite = sprites[i];
        }
    }

    public void Show(DiceData dice)
    {
        DiceFaceData[] faces = dice.faces;
        images = GetComponentsInChildren<Image>();



        for (int i = 0; i < faces.Length; i++)
        {
            images[i].sprite = faces[i].icon;
            //Debug.Log("i "+i);
            
        }
    }

    private void Awake()
    {
        
        
        //sprites = Resources.LoadAll<Sprite>("Dice");
        images = GetComponentsInChildren<Image>();
        

    }

    private void Start()
    {
        //Show();
    }

    public void SetSize(float totalWidth)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(totalWidth, (totalWidth-40)/6);
    }

}
