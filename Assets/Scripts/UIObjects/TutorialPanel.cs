using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField]
    Sprite[] imgs;

    [SerializeField]
    Image image;

    int index = 0;

    private void Awake()
    {
        ShowImage(0);
    }

    private void ShowImage(int index)
    {
        image.sprite = imgs[index];
    }

    public void Next()
    {
        index++;
        if (index >= imgs.Length) index = 0;
        ShowImage(index);
    }
    /*
    public void SetActive(bool a)
    {
        gameObject.SetActive(a);
    }*/
}
