using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MySlider : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    //Image frame, fill;
    
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

        slider.value = value;
    }

    public void SetValue(int value, int max)
    {
        SetRange(0, max);
        SetValue(value);
    }

    public int GetValue()
    {
        return (int)slider.value;
    }
}
