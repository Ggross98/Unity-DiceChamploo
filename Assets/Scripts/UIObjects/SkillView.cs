using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillView : MonoBehaviour
{

    [SerializeField]
    Text nameText;

    [SerializeField]
    Transform diceFaceField;

    [SerializeField]
    GameObject diceFacePrefab;

    public void ShowCombo(List<DiceFaceData> list)
    {
        ComboData combo = ComboData.MatchCombo(list);
        if (combo == null) return;

        foreach(DiceFaceData dfd in list)
        {
            GameObject obj = Instantiate(diceFacePrefab, diceFaceField);
            SkillDiceFace sdf = obj.GetComponent<SkillDiceFace>();

            sdf.SetIcon(dfd.icon);
        }

        nameText.text = combo.name;
    }

}
