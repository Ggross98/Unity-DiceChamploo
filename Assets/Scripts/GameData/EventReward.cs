using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件或战斗的奖励
/// </summary>
public class EventReward
{
    public enum Type { Gold, SkillPoint, Teammate};

    public Type type;

    public int value;

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
}
