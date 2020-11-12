using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboData
{
    public string name;

    public List<ComboEffect> effects;

    //List<DiceFaceData> request;

    public ComboData() { }

    public ComboData(string str, List<ComboEffect> eff) {

        name = str;
        effects = eff;

    }

    private static Dictionary<List<DiceFaceData>, ComboData> comboDataDictionary = new Dictionary<List<DiceFaceData>, ComboData>() {

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack")},
            //组合效果
            new ComboData(
                "攻击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 1, true, false)}            
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Attack")},
            //组合效果
            new ComboData(
                "二连击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 2, true, false)}
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "防御",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Shield, 1, false, true)}
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Defense"), DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "强防御",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Shield, 2, false, true)}
            )
        },



    };

    public static ComboData MatchCombo(List<DiceFaceData> list)
    {
        foreach (List<DiceFaceData> request in comboDataDictionary.Keys)
        {
            if (list.Count != request.Count) continue;

            bool matched = true;

            for(int i = 0; i < list.Count; i++)
            {
                Debug.Log("list:" + list[i] + "\trequest:" + request[i]);

                if(list[i].index != request[i].index)
                {
                    matched = false;
                    break;
                }
            }

            if (matched)
            {
                return comboDataDictionary[request];
            }
        }

        return null;
    }

}
