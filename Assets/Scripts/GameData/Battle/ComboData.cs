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

    public static Dictionary<List<DiceFaceData>, ComboData> comboDataDictionary = new Dictionary<List<DiceFaceData>, ComboData>() {

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
        /*
        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Think")},
            //组合效果
            new ComboData(
                "头槌",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Damage, 1, true, false), new ComboEffect(ComboEffect.EffectType.Stun, 1, true, false) }
            )
        },*/

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
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Move")},
            //组合效果
            new ComboData(
                "躲避",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 1, false, true) }
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Handle"), DiceFaceData.GetDiceFaceModel("Handle")},
            //组合效果
            new ComboData(
                "巴掌",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Damage, 1, true, false) }
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Observation"), DiceFaceData.GetDiceFaceModel("Observation")},
            //组合效果
            new ComboData(
                "观察",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 1, false, true) }
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
        /*
        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Observation"), DiceFaceData.GetDiceFaceModel("Think")},
            //组合效果
            new ComboData(
                "声东击西",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Stun, 1, true, true) }
            )
        },*/

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Observation")},
            //组合效果
            new ComboData(
                "佯攻",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.ShieldDamage, 6, true, true) },
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
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Move"), DiceFaceData.GetDiceFaceModel("Think"), DiceFaceData.GetDiceFaceModel("Defense")},
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
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("DoublePunch")},
            //组合效果
            new ComboData(
                "组合拳",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 4, true, false)},
                "SE_Punch"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Shield")},
            //组合效果
            new ComboData(
                "护盾",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 2, false, true) }
            )
        },

         {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("DoubleShield")},
            //组合效果
            new ComboData(
                "强护盾",
                new List<ComboEffect>(){ new ComboEffect(ComboEffect.EffectType.Shield, 4, false, true) }
            )
        },


        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Pistol")},
            //组合效果
            new ComboData(
                "手枪射击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 4, true, false)},
                "SE_Pistol"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Observation"), DiceFaceData.GetDiceFaceModel("Pistol")},
            //组合效果
            new ComboData(
                "精准射击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 6, true, false)},
                "SE_Pistol"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Rifle")},
            //组合效果
            new ComboData(
                "步枪射击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 6, true, false)},
                "SE_Pistol"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Shotgun")},
            //组合效果
            new ComboData(
                "霰弹枪射击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 4, true, true)},
                "SE_Pistol"
            )
        },
        /*
        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Tesla")},
            //组合效果
            new ComboData(
                "电击枪攻击",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 1, true, false), new ComboEffect(ComboEffect.EffectType.Stun, 1, true, false)},
                "SE_Tesla"
            )
        },*/

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Bomb")},
            //组合效果
            new ComboData(
                "爆破",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 6, true, true),new ComboEffect(ComboEffect.EffectType.Damage, 3, false, true)},
                "SE_Bomb"
            )
        },

        {
            //骰子需求
            new List<DiceFaceData> (){ DiceFaceData.GetDiceFaceModel("Think"), DiceFaceData.GetDiceFaceModel("Bomb")},
            //组合效果
            new ComboData(
                "定向爆破",
                new List<ComboEffect>(){new ComboEffect(ComboEffect.EffectType.Damage, 6, true, true), new ComboEffect(ComboEffect.EffectType.Damage, 1, false, true)},
                "SE_Bomb"
            )
        },
    };


    /// <summary>
    /// 传入的骰子是否能与字典中的一种combo完全匹配，并返回该combo数据
    /// </summary>
    /// <param name="list"></param>
    /// <returns>如果能匹配，返回一个非空的ComboData，否则返回Null</returns>
    public static ComboData MatchCombo(List<DiceFaceData> list)
    {
        for(int i = 0; i < list.Count-1; i++)
        {
            for(int j = i; j < list.Count-1; j++)
            {
                if(list[j].index > list[j + 1].index)
                {
                    var temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        foreach (List<DiceFaceData> request in comboDataDictionary.Keys)
        {
            if (list.Count != request.Count) continue;

            bool matched = true;

            for(int i = 0; i < list.Count; i++)
            {
                //Debug.Log("list:" + list[i] + "\trequest:" + request[i]);

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

    /*
    public static bool Match( List<DiceFaceData> _a, List<DiceFaceData> _b)
    {
        if (_a == null && _b == null) return true;
        if (_a == null || _b == null) return false;
        if (_a.Count != _b.Count) return false;

        foreach(DiceFaceData dfd in _a)
        {
            if (!ContainsDiceFace(_b, dfd)) return false;
        }
        return true;
    }*/

    /// <summary>
    /// 列表中是否含有与传入骰子index相同的骰子
    /// </summary>
    /// <param name="list"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool ContainsDiceFace(List<DiceFaceData> list, DiceFaceData data)
    {
        if (list == null || data.index == 0 || list.Count == 0) return false;
        foreach(DiceFaceData d in list)
        {
            if (d.Equals(data)) return true;
        }
        return false;
    }

    /// <summary>
    /// 判断列表是否含有传入列表中的所有骰子
    /// </summary>
    /// <param name="list"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private static bool ContainsDiceFaceList(List<DiceFaceData> list, List<DiceFaceData> data)
    {
        if (list == null || data == null || list.Count == 0 || list.Count < data.Count) return false;
        if (data.Count == 0) return true;

        foreach(DiceFaceData dfd in data)
        {
            if (!ContainsDiceFace(list, dfd)) return false;
        }
        return true;
    }

    /// <summary>
    /// 返回包含传入骰子列表的所有combo需求的骰子列表
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private static List<List<DiceFaceData>> GetPossibleComboList(List<DiceFaceData> list)
    {
        var result = new List<List<DiceFaceData>>();

        foreach (List<DiceFaceData> dList in comboDataDictionary.Keys)
        {
            if(ContainsDiceFaceList(dList, list))
            {
                result.Add(dList);
            }
        }

        return result;
    }

    /// <summary>
    /// 找到需要抖动显示的未被选中的骰子对象
    /// </summary>
    /// <param name="selectedObjects">已经选中的骰子</param>
    /// <param name="otherObjects">未被选中的骰子</param>
    /// <returns></returns>
    public static List<DiceObject> GetShakingObjects(List<DiceObject> selectedObjects, List<DiceObject> otherObjects)
    {
        return new List<DiceObject>();
    }

    
}
