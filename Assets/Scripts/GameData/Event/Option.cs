using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum Operation { none, Gold, SkillPoint, Battle };
//enum JudgeCondition { no, Dice, Gold };
class Option
{
    internal string description;
    internal int[] nextIndex;

    internal Operation operation;
    internal Condition condition;

    public Option()
    {
        description = "返回地图";
        operation = new Operation();
        condition = new Condition();
        nextIndex = null;
    }

    public Option(string d, int[] n = null, Condition c = null, Operation o = null)
    {
        description = d;
        nextIndex = n;
        if (o == null)
            operation = new Operation();
        else
            operation = o;

        if (c == null)
            condition = new Condition();
        else
            condition = c;
    }


    public virtual bool CheckOption(List<DiceFaceData> dices)//检查选项是否满足条件，结算并返回是否跳转
    {
        if (condition.CheckCondition(dices))
        {
            operation.ExecuteOperation();
            return true;
        }
        return false;
    }

    //********************************数据库***************   
    public static Option finalOption = new Option();

    public static Option battleOption = new Option(
        
        "战斗！"

        );

    public static Option option0_0_0 = new Option(
        "乖乖交钱",
        new int[] { 1 },
        new GoldCondition(50),
        new GoldOperation(50)
    );

    public static Option option0_0_1 = new Option(
        "说服放行",
        new int[] { 2, 3 },
        new DiceColorCondition(0, 0, 2)
    );

    public static Option option0_0_2 = new Option(
        "给他一拳",
        new int[] { 2, 3 },
        new DiceColorCondition(1, 0, 0)
    );

    public static Option option1_0_0 = new Option(
        "装没看见",
        new int[] { 1 }
    );

    public static Option option1_0_1 = new Option(
        "挺身而出",
        new int[] { 2 }
    );

    public static Option option1_2_0 = new Option(
        "威胁",
        new int[] { 3, 4 },
        new DiceColorCondition(1, 0, 2)
    );

    public static Option option1_2_1 = new Option(
        "战斗！",
        new int[] { 4 }
    );

    public static Option option1_2_2 = new Option(
        "转身离开",
        new int[] { 1 }
    );

    public static Option option2_0_0 = new Option(
        "走为上计",
        new int[] { 1, 2 },
        new DiceColorCondition(0, 1, 1)
    );

    public static Option option2_0_1 = new Option(
        "战斗！",
        new int[] { 2 }
    );

    public static Option option_e1_0_0 = new Option(
        "加油！",
        new int[] {1}
    );

    public static Option option_e1_1_0 = new Option(

        "下定决心！",
        new int[] { 2 }
    );

    public static Option option_e1_2_0 = new Option(

        "带上积蓄",
        new int[] { 3 }
    );
    public static Option option_e1_2_1 = new Option(

        "找个帮手",
        new int[] { 4 }
    );

    public static Option option_e3_0_0 = new Option(
        "保持戒备",
        new int[] { 1 }
    );

    public static Option option_e3_0_1 = new Option(

        "认真聆听",
        new int[] { 2 }
    );

    public static Option option_e3_1_0 = new Option(

        "革命军？",
        new int[] { 3 }
    );



}

