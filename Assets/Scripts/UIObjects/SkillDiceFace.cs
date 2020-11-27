using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDiceFace : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    public void SetIcon(Sprite s)
    {
        icon.sprite = s;
    }
}
