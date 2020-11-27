using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件或战斗的奖励
/// </summary>
public class EventReward
{
    public enum Type { Gold, SkillPoint, Teammate, RandomMainCharacter, Heal, Damage};

    public Type type;

    public int value;

    public int valueType;

    private EventReward(Type tp, int v)
    {
        type = tp;

        value = v;
    }

    public override string ToString()
    {
        switch (type)
        {
            case Type.Gold:
                return "金钱" + ((value > 0) ? "+" : "" )+ value+"。";
            case Type.SkillPoint:
                return "技能点+" + value + "。";
            case Type.Teammate:
                return "获得新队员。";
            case Type.Heal:
                return (valueType == 0) ? "生命最低队员" : "全体队员" + "回复" + value + "生命。";
            case Type.Damage:
                return "全体队员收到" + value + "伤害。";
        }

        return "";
    }

    public static EventReward GoldReward(int value)
    {
        return new EventReward(Type.Gold, value);
    }

    public static EventReward SkillPointReward(int value)
    {
        return new EventReward(Type.SkillPoint, value);
    } 

    public static EventReward TeammateReward(int value)
    {
        return new EventReward(Type.Teammate, value);
    }

    public static EventReward RandomMainCharacterReward()
    {
        return new EventReward(Type.RandomMainCharacter, 0);
    }

    public static EventReward DamageReward(int value)
    {
        return new EventReward(Type.Damage, value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    /// <param name="vType">0:治疗生命最低角色；1：治疗全部角色</param>
    /// <returns></returns>
    public static EventReward HealReward(int v, int vType)
    {
        var er = new EventReward(Type.Heal, v);
        er.valueType = vType;

        return er;
    }
}
