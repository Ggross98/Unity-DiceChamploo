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
        new DiceColorCondition(2, 0, 0)
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

    public static Option option52_0_0 = new Option(
        "走为上计",
        new int[] { 1, 2 },
        new DiceColorCondition(0, 1, 1)
    );

    public static Option option52_0_1 = new Option(
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

    public static Option option3_0_0 = new Option(
        
        "无视他们",
        new int[] {1}
        
    );

    public static Option option3_0_1 = new Option(

        "帮忙捉贼",
        new int[] { 3, 2 },
        new DiceColorCondition(2, 0, 0)

    );

    public static Option option3_3_0 = new Option(

        "捡起背包，放跑小偷",
        new int[] { 4 }
    );

    public static Option option3_3_1 = new Option(

        "无视背包，继续追逐",
        new int[] { 5, 2 },
        new DiceColorCondition(1,1,0)
    );

    public static Option option3_4_0 = new Option(

        "据为己有！",
        new int[] { 7 }
    );

    public static Option option3_4_1 = new Option(

        "物归原主",
        new int[] { 6 }
    );

    public static Option option4_0_0 = new Option(

        "给他一些钱",
        new int[] {1},
        new GoldCondition(15),
        new GoldOperation(15)

    );

    public static Option option4_0_1 = new Option(

        "无视他",
        new int[] { 2 }
    );

    public static Option option5_0_0 = new Option(

        "悄悄离开",
        new int[] { 1,2 },
        new DiceColorCondition(0,0,1)

    );

    public static Option option5_0_1 = new Option(
        
        "正面应对",
        new int[] {2}
    );

    public static Option option5_2_0 = new Option(
        
        "装作没看见",
        new int[] {3,4},
        new DiceColorCondition(0,0,2)
        
    );

    public static Option option5_2_1 = new Option(

        "发动攻击!",
        new int[] {4}

    );

    public static Option option6_0_0 = new Option(

        "乖乖交钱",
        new int[] {1},
        new GoldCondition(25),
        new GoldOperation(25)

    );

    public static Option option6_0_1 = new Option(

        "据理力争",
        new int[] {3, 2},
        new DiceColorCondition(0,0,2)

    );

    public static Option option6_0_2 = new Option(

        "话术威胁",
        new int[] {4,2},
        new DiceColorCondition(1,1,0)

    );

    public static Option option7_0_0 = new Option(
        "转身离开",
        new int[] {1}
        
     );

    public static Option option7_0_1 = new Option(
        
        "潜入搜索",
        new int[] {2,3},
        new DiceColorCondition(0,2,0)
        
    );

    public static Option option8_0_0 = new Option(
        "购买侦察无人机",
        new int[] { 1 },
        new GoldCondition(100),
        new GoldOperation(100)
     );

    public static Option option8_0_1 = new Option(
        "购买轰炸无人机",
        new int[] { 2 },
        new GoldCondition(120),
        new GoldOperation(120)
     );

    public static Option option8_0_2 = new Option(
        "购买武装机器人",
        new int[] { 3 },
        new GoldCondition(120),
        new GoldOperation(120)
     );

    public static Option option8_0_3 = new Option(
        "什么也不买",
        new int[] { 4 }

     );

    public static Option option9_0_0 = new Option(
        
        "紧急处理",
        new int[] {1},
        new GoldCondition(25),
        new GoldOperation(25)
    );

    public static Option option9_0_1 = new Option(

        "检查治疗",
        new int[] { 2 },
        new GoldCondition(80),
        new GoldOperation(80)
    );

    public static Option option9_0_2 = new Option(

        "离开",
        new int[] { 3 }

    );

    public static Option option10_0_0 = new Option(

        "雇佣",
        new int[] { 1 },
        new GoldCondition(100),
        new GoldOperation(100)
    );

    public static Option option10_0_1 = new Option(

        "拒绝",
        new int[] { 2 }
    );

    //事件1-11
    public static Option option11_0_0 = new Option(

        "抽奖！",
        new int[] { 6 },
        new GoldCondition(50),
        new GoldOperation(50)

    );
    public static Option option11_6_0 = new Option(

        "看看运气",
        new int[] { 2, 1 },
        new LuckCondition(20)

    );


    public static Option option11_0_1 = new Option(

        "尝试黑客技术破解",
        new int[] { 3, 4 },
        new DiceColorCondition(1, 0, 2)

    );

    public static Option option11_0_2 = new Option(

         "转身离开",
         new int[] { 5 }
     );


    //事件1-12
    public static Option option12_0_0 = new Option(

        "躲避碎片",
        new int[] { 1, 2 },
        new DiceColorCondition(1,0,2)

    );

    public static Option option12_0_1 = new Option(

        "寻找掩体",
        new int[] { 1,2 },
        new DiceColorCondition(1, 2, 0)

    );

    //事件1-13
    public static Option option13_0_0 = new Option(

        "仔细聆听",
        new int[] { 2 }

    );

    public static Option option13_0_1 = new Option(

        "拒绝聆听",
        new int[] { 1 }

    );

    public static Option option13_0_2 = new Option(

        "出手攻击",
        new int[] { 5 }

    );

    public static Option option13_2_0 = new Option(

        "金钱支援",
        new int[] { 4 },
        new GoldCondition(50),
        new GoldOperation(50)

    );

    public static Option option13_2_1 = new Option(

        "婉言拒绝",
        new int[] { 3 }

    );

    //事件1-2
    public static Option option2_0_0 = new Option(

        "离开",
        new int[] { 1 }

    );

    public static Option option2_0_1 = new Option(

        "请他一杯",
        new int[] { 4 },
        new GoldCondition(20),
        new GoldOperation(20)

    );

    public static Option option2_0_2 = new Option(

        "给他一拳",
        new int[] { 2, 3 },
        new DiceColorCondition(2,0,0)

    );

    public static Option option2_1_0 = new Option(

        "请他一杯",
        new int[] { 4 },
        new GoldCondition(20),
        new GoldOperation(20)

    );

    public static Option option2_1_1 = new Option(

        "给他一拳",
        new int[] { 2, 3 },
        new DiceColorCondition(2, 0, 0)

    );

    //事件2-0
    public static Option option50_0_0 = new Option(

        "声称不知情",
        new int[] { 3, 4 },
        new DiceColorCondition(0, 0, 1)

    );

    public static Option option50_0_1 = new Option(

        "告知少女逃跑方向",
        new int[] { 1 }
    );

    public static Option option50_0_2 = new Option(

        "告知错误的方向",
        new int[] { 2, 4 },
        new DiceColorCondition(0, 0, 4)

    );

    //事件2-3
    public static Option option53_0_0 = new Option(

        "利用掩体躲藏",
        new int[] { 1, 2 },
        new DiceColorCondition(0, 2, 1)

    );

    public static Option option53_0_1 = new Option(

        "帮助“红莲团”帮会成员",
        new int[] { 3 }
    );

    public static Option option53_0_2 = new Option(

        "帮助“巨齿鲨”帮会成员",
        new int[] { 4 }
    );

    //事件2-4
    public static Option option54_0_0 = new Option(

        "想",
        new int[] { 2 }
    );

    public static Option option54_0_1 = new Option(

        "不想",
        new int[] { 1 }
    );

    public static Option option54_2_0 = new Option(

        "强悍的力量",
        new int[] { 4, 3 },
        new DiceColorCondition(4, 0, 0)

    );

    public static Option option54_2_1 = new Option(

        "坚定的意志",
        new int[] { 4, 3 },
        new DiceColorCondition(0, 4, 0)

    );

    public static Option option54_2_2 = new Option(

        "广博的知识",
        new int[] { 4, 3 },
        new DiceColorCondition(0, 0, 4)

    );

    public static Option option54_4_0 = new Option(

        "金钱",
        new int[] { 5 }
    );

    public static Option option54_4_1 = new Option(

        "技能",
        new int[] { 6 }
    );




    //事件2-5

    public static Option option55_0_0 = new Option(

        "蒙混过关",
        new int[] { 1, 2 },
        new DiceColorCondition(0,0,3)
    );

    public static Option option55_0_1 = new Option(

        "拔腿就溜",
        new int[] { 4, 5 },
        new DiceColorCondition(0, 2, 1)
    );

    public static Option option55_2_1 = new Option(

        "给他一拳！",
        new int[] { 3, 6 },
        new DiceColorCondition(3, 0, 0)
    );

    //事件2-6
    public static Option option56_0_0 = new Option(

        "给她一些钱",
        new int[] { 1 },
        new GoldCondition(60),
        new GoldOperation(60)

    );

    public static Option option56_0_1 = new Option(

        "无视她",
        new int[] { 2 }
    );

    //事件2-7
    public static Option option57_0_0=new Option(

        "转身离开",
        new int[] { 1 }
    );

    public static Option option57_0_1 = new Option(

        "挺身而出",
        new int[] { 2 }
    );

    public static Option option57_2_0 = new Option(

        "虚张声势",
        new int[] { 3, 4 },
        new DiceColorCondition(2, 0, 3)
    );

    public static Option option57_2_1 = new Option(

        "贿赂警察",
        new int[] { 5 },
        new GoldCondition(80),
        new GoldOperation(80)
    );

    public static Option option57_2_2 = new Option(

        "动手解救",
        new int[] { 4 }
    );

    public static Option option57_3_0 = new Option(

        "查看男人的情况",
        new int[] { 6 }
    );

    public static Option option57_6_0 = new Option(

        "要求金钱报酬",
        new int[] { 7 }
    );

    public static Option option57_6_1 = new Option(

        "要求男人加入队伍",
        new int[] { 8 }
    );

    //事件2-9
    public static Option option59_0_0 = new Option(

        "雇佣",
        new int[] { 1 },
        new GoldCondition(150),
        new GoldOperation(150)
    );

    public static Option option59_0_1 = new Option(

        "拒绝",
        new int[] { 2 }
    );


    //事件2-10
    public static Option option60_0_0 = new Option(

        "悄悄跟上",
        new int[] { 2,5 },
        new DiceColorCondition(0,3,0)
    );

    public static Option option60_0_1 = new Option(

        "正面对峙",
        new int[] { 5 }
    );

    public static Option option60_0_2 = new Option(

        "无视",
        new int[] { 1 }
    );

    public static Option option60_2_0 = new Option(

        "出手阻止",
        new int[] { 3 }
    );

    public static Option option60_2_1 = new Option(

        "默默观察",
        new int[] { 4 }
    );



    #region 剧情关

    public static Option option_e_4_0_0 = new Option(

        "力证清白",
        new int[] { 1, 3 },
        new DiceColorCondition(0, 4, 0)
    );

    public static Option option_e_4_0_1 = new Option(

        "先下手为强",
        new int[] { 2, 3 },
        new DiceColorCondition(4, 0, 0)
    );

    #endregion

}

