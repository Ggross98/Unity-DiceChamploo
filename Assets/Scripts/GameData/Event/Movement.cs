using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    internal string description;

    internal bool isEnding;
    internal bool isBattle;

    internal BattleData battleData = null;

    internal List<Option> options = new List<Option>();

    internal List<EventReward> rewards = new List<EventReward>();

    public int OptionCount()
    {
        return options.Count;
    }

    public BattleData GetBattleData()
    {
        return battleData;
    }

    public string FullDescription()
    {
        string info = description;
        if (rewards == null || rewards.Count < 1) return info;

        info += "\n\n";
        for(int i = 0; i < rewards.Count; i++)
        {
            info += rewards[i].ToString();
        }

        return info;
    }

    Movement(string _description, bool _isBattle = false, BattleData _battle = null, List < EventReward> _rewards = null)//结局场景
    {
        isEnding = true;

        isBattle = _isBattle;
        battleData = _battle;

        description = _description;
        options.Add(Option.finalOption);
        
        rewards = _rewards;
    }

    Movement(string _description, List<Option> _options, bool _isBattle = false, BattleData _battle = null, List<EventReward> _rewards = null, bool _ending = false)//一般场景
    {
        isEnding = _ending;
        description = _description;
        options = _options;

        isBattle = _isBattle;
        battleData = _battle;

        rewards = _rewards;
    }

    //internal IsEnding() { return isEnding; }

    /// <summary>
    /// 选择某一选项后，检测是否满足选项的条件，并返回结果
    /// </summary>
    /// <param name="index">选项在Movement中位置</param>
    /// <param name="dices">骰子列表</param>
    /// <returns></returns>
    public OptionResult CheckOption(int index, List<DiceFaceData> dices)
    {
        //如果本Movement是结局
        if (isEnding)
        {
            if (isBattle)
                return OptionResult.Battle;
            else
                return OptionResult.Ending;
        }
        //否则进行条件判断
        if (options[index].CheckOption(dices))
        {
            return OptionResult.SuccessJump;
        }

        if (options[index].nextIndex.Length >1) //存在第二种跳转
            return OptionResult.FailJump;

        return OptionResult.NoJump;
    }

    public bool NeedDices(int index)
    {
        return options[index].condition.GetType() == new DiceColorCondition(1,1,1).GetType();
    }


    internal string[] getOptionDiscription()
    {
        string[] result = new string[options.Count];
        for (int i = 0; i < options.Count; ++i)
        {
            result[i] = options[i].description;
        }
        return result;
    }

    internal string[] getConditionDiscription()
    {
        
        string[] result = new string[options.Count];
        for (int i = 0; i < options.Count; ++i)
        {
            result[i] = options[i].condition.ToString();
        }
        return result;
    }



    //***********************************数据库**************************

    #region 事件 遭遇劫匪
    public static Movement m0_0 = new Movement(
        "\t你经过一条小巷时，一个手持匕首、满脸凶相的男人向你走来。\n\t“这位小兄弟，老子最近手头有点紧，借点钱花花呗？”他朝你喊道。", 
        new List<Option>
        {
            Option.option0_0_0,
            Option.option0_0_1,
            Option.option0_0_2
        }
    );

    public static Movement m0_1 = new Movement("\t男人数了数钱，满意地离开了。他很快消失在了夜色之中");

    public static Movement m0_3 = new Movement(
        
        "\t“这是你自找的！”男人冲向了你。", 
        new List<Option> { Option.battleOption },
        true,
        BattleData.GetBattleData(0,1),
        null,
        true

        );

    public static Movement m0_2 = new Movement(

        "\t男人悻悻地离开了。他很快消失在了夜色之中。",
        false,null,
        new List<EventReward>() {

            EventReward.GoldReward(20),
            EventReward.SkillPointReward(2)
        }
        
        
    );
    #endregion

    #region 事件 遭遇黑帮Ⅰ
    public static Movement m1_0 = new Movement("\t几个持刀的混混围住了一位女性。你认出，这些混混是“巨齿鲨”帮会的成员！\n\t“求求你们，我还有孩子啊！”\n\t女性求饶道，但几个混混不为所动，狞笑着向她走去……		",
                new List<Option>
                {
                    Option.option1_0_0,
                    Option.option1_0_1
                });

    public static Movement m1_1 = new Movement("\t你觉得不要装英雄，悄悄离开了。走出一段距离后，你听到身后传来女性的惨叫声……");

    public static Movement m1_2 = new Movement("\t混混们注意到了你。\n\t“你是什么人？想活命的话就快滚，别坏了兄弟们的兴致！”为首的男人朝你挥了挥手中的匕首。",
                new List<Option>
                {
                    Option.option1_2_0,
                    Option.option1_2_1,
                    Option.option1_2_2
                });

    public static Movement m1_3 = new Movement(
        @"男人似乎被你坚定的语气，抑或是你手中的武器唬住了。
                他一挥手，混混们不情愿地离开了现场。
                那个女人小声向你们道了谢，匆匆逃离了这条小巷。",
        false,null,
        new List<EventReward>() {

            EventReward.GoldReward(20),
            EventReward.SkillPointReward(2)
        }

    );

    public static Movement m1_4 = new Movement(
        
        @"那群混混纷纷掏出武器，把你团团围住！",
        new List<Option> { Option.battleOption},
        true,
        BattleData.GetBattleData(0, 2),
        null,
        true
        );

    #endregion

    #region 遭遇黑帮 Ⅱ
    public static Movement m2_0 = new Movement(@"你走在一条小路中，突然一群混混把你团团围住。
                你认出，这些混混是“巨齿鲨”帮会的成员！
                他们宣称要替“老大”给你一个教训……",
                new List<Option>
                {
                    Option.option2_0_0,
                    Option.option2_0_1
                });

    public static Movement m2_1 = new Movement(
        "你灵活的闪转腾挪，躲过混混们的棍棒，转眼间逃离了现场。",
        false,null,
        new List<EventReward>() {

            //EventReward.GoldReward(20),
            EventReward.SkillPointReward(3)
        }
    );

    public static Movement m2_2 = new Movement(
        "那群混混大吼一声便冲了过来。",
        new List<Option> { Option.battleOption },

        true,
        BattleData.GetBattleData(0, 2),
        null,
        true
    );

    #endregion

    #region 第一大关 初始事件
    public static Movement m_e_1_0 = new Movement(
        "\t在这座光怪陆离的大都会中，少数上流社会的人享受着穷奢极欲的生活，而大部分居民则挣扎求生，城市一端的贫民窟更是混乱与罪恶的孳生之处……"+
        "\t你，维托（Vito），则与身边的伙伴一起，始终寻找着逃离贫民窟的机会。",
        new List<Option>
        {
            Option.option_e1_0_0,
        }
    );

    public static Movement m_e_1_1 = new Movement(
        "\t某日在路上，你收到一封信：“你的朋友玛雅在我手上，速来！”上面还附带一个酒吧的地址。你认出这个地址位于黑帮活跃的地区，路途恐怕非常艰险。"+
        "\t但你救人心切，没多做考虑便准备出发。",
        new List<Option>
        {
            Option.option_e1_1_0,
        }
    );

    public static Movement m_e_1_2 = new Movement(
        "\t你与搭档的冒险之旅即将启程。在此之前，你觉得需要做一些准备，是什么呢？",
        new List<Option>
        {
            Option.option_e1_2_0,
            Option.option_e1_2_1,
        }
    );

    public static Movement m_e_1_3 = new Movement(
        "\t你取走了之前藏起来的一小笔积蓄。",
        false, null,
        new List<EventReward>() {

            EventReward.GoldReward(80)
        }
    );

    public static Movement m_e_1_4 = new Movement(
        "\t你又喊上了一个信得过的伙伴同行。",
        false, null,
        new List<EventReward>() {
            EventReward.TeammateReward(101)
        }
    );

    #endregion

    #region 第一大关 Boss

    public static Movement m_e_2_0 = new Movement(
        "\t你来到了信上所标注的地址：“大牙”酒吧。来这里喝酒的大都是黑帮成员与通缉犯，他们不怀好意的眼光让你不寒而栗。"+
        "\t在吧台边，帮派老大向你们招手。你走上前去，谁知他一挥手，几个打手便向你们冲来。这是个陷阱！" ,
        new List<Option> { Option.battleOption},
        true,
        BattleData.GetBattleData(0, 101),
        null,
        true
    );


    #endregion


    #region 第二大关 初始事件
    public static Movement m_e_3_0 = new Movement(
        "\t你使出浑身解数，打趴了几个黑帮。老大收起武器，鼓了鼓掌。“不错，你果然是个可造之才，带上你的伙伴走吧。不过其实我还有些想告诉你的事情。”",
                new List<Option>
                {
                    Option.option_e3_0_0,
                    Option.option_e3_0_1
                }
                
    );

    public static Movement m_e_3_1 = new Movement(
        "\t看到你仍举着武器，老大赞许地点了点头。“你的谨慎是正确的。在贫民窟，只有时刻警惕才能活下去，不过改变这一切的机会已经来了。"+
        "\t我暗中观察你很久了，你有成为一名战士的潜质，我希望你能去见见革命军的‘K教官’”",
                new List<Option>
                {
                    Option.option_e3_1_0,
                });

    public static Movement m_e_3_2 = new Movement(
        "\t老大继续说道：" +
        "\t“我暗中观察你很久了，你有成为一名战士的潜质，我希望你能去见见革命军的‘K教官’”",
                new List<Option>
                {
                    Option.option_e3_1_0,
                });

    public static Movement m_e_3_3 = new Movement(
        "\t“不错，他们正策划推翻“日冕”公司在城市的统治，到时候本地的帮派也会提供支持。到这个地方去吧，或许很危险，但靠你的身手没问题，大概？此地不宜久留，快走吧。”他不怀好意地笑了笑，递给你一张破破烂烂的纸条，上面写着一个富人区的地址。",
        false, null,
        new List<EventReward>() {
            EventReward.TeammateReward(4)
        }
    );

    #endregion


    #region 第二大关 Boss
    public static Movement m_e_4_0 = new Movement(
        "\t站在你们面前的是一个蒙着面的怪人。虽然他（或他？）还没发动攻击，但你感受到了浓烈的杀气！",
        new List<Option> { Option.battleOption},
        true,
        BattleData.GetBattleData(0, 102),
        null,
        true
    );
    #endregion
}


