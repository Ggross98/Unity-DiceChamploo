using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MySlider : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    Text text;

    public int value;
    
    public void SetRange(int min, int max)
    {
        if(min>max)
        {
            Debug.LogError("slider range error!");
            return;
        }
        else
        {
            
            slider.maxValue = max;
            slider.minValue = min;
        }
    }

    public void SetValue(int v)
    {
        int value = v;
        if (value > slider.maxValue) value = (int)slider.maxValue;
        if (value < slider.minValue) value = (int)slider.minValue;

        this.value = value;
        slider.value = value;
    }

    public void OnValueChange()
    {
        this.value = (int)slider.value;
        SetText();
    }

    private void SetText()
    {
        text.text = value + "/" + slider.maxValue;
    }

    public void SetValue(int value, int max)
    {
        SetRange(0, max);
        SetValue(value);
        SetText();
    }

}
