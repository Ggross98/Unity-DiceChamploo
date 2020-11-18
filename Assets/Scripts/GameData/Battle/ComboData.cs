using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboData
{
    public string name;

    public List<ComboEffect> effects;

    public string se;

    //List<DiceFaceData> request;

    public ComboData() { }

    public ComboData(string str, List<ComboEffect> eff, string se = null) {

        name = str;
        effects = eff;
        this.se = se;
    }

    private static Dictionary<List<DiceFaceData>, ComboData> comboDataDictionary = new Dictionary<List<DiceFaceData>, ComboData>() {

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack")},
            //组合效果
            new ComboData(
                "攻击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 1, true, false)},
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Attack")},
            //组合效果
            new ComboData(
                "二连击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 2, true, false)},
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Attack")},
            //组合效果
            new ComboData(
                "三连击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 4, true, false)},
                "SE_Punch"
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

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Defense"), DiceFaceData.GetDiceFaceModel("Defense"), DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "极限防御",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Shield, 4, false, true)}
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "防守反击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Shield, 2, false, true), new ComboEffect(ComboEffect.EffectType.Damage, 2, true, false) },
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Handle")},
            //组合效果
            new ComboData(
                "招架",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Shield, 3, false, true) }
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Observation")},
            //组合效果
            new ComboData(
                "精确攻击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 3, true, false) },
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Observation"), DiceFaceData.GetDiceFaceModel("Observation")},
            //组合效果
            new ComboData(
                "要害攻击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 5, true, false) },
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Handle")},
            //组合效果
            new ComboData(
                "脚踢",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 3, true, false) },
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "闪避",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 3, false, true) }
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Think"), DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "战术优势",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 3, false, true) }
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Think")},
            //组合效果
            new ComboData(
                "两翼夹击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 5, true, false) },
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Attack"), DiceFaceData.GetDiceFaceModel("Think"), DiceFaceData.GetDiceFaceModel("Handle")},
            //组合效果
            new ComboData(
                "回旋斩",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 4, true, true) },
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Observation"), DiceFaceData.GetDiceFaceModel("Defense")},
            //组合效果
            new ComboData(
                "完美阵型",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 8, false, true) }
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Punch")},
            //组合效果
            new ComboData(
                "拳击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 2, true, false)},
                "SE_Punch"
            )
        },




        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Pistol")},
            //组合效果
            new ComboData(
                "手枪射击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 4, true, false)},
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Rifle")},
            //组合效果
            new ComboData(
                "步枪射击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 6, true, false)},
                "SE_Punch"
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
