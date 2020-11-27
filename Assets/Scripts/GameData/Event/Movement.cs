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

        if(isBattle)
            options.Add(Option.battleOption);
        else
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


    internal string[] GetOptionDiscription()
    {
        string[] result = new string[options.Count];
        for (int i = 0; i < options.Count; ++i)
        {
            result[i] = options[i].description;
        }
        return result;
    }

    internal string[] GetConditionDiscription()
    {
        
        string[] result = new string[options.Count];
        for (int i = 0; i < options.Count; ++i)
        {
            result[i] = options[i].condition.ToString();
        }
        return result;
    }



    //***********************************数据库**************************

    #region 事件1-0 遭遇劫匪
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

    #region 事件1-1 遭遇黑帮Ⅰ
    public static Movement m1_0 = new Movement(
        "  几个持刀的混混围住了一位女性。你认出，这些混混是“巨齿鲨”帮会的成员！\n "+
        "  “求求你们，我还有孩子啊！”女性求饶道，但几个混混不为所动，狞笑着向她走去……",
        new List<Option>
        {
            Option.option1_0_0,
            Option.option1_0_1
        });

    public static Movement m1_1 = new Movement(
        "  你觉得不要装英雄，悄悄离开了。走出一段距离后，你听到身后传来女性的惨叫声……");

    public static Movement m1_2 = new Movement(
        "  混混们注意到了你。“你是什么人？想活命的话就快滚，别坏了兄弟们的兴致！”为首的男人朝你挥了挥手中的匕首。",
        new List<Option>
        {
            Option.option1_2_0,
            Option.option1_2_1,
            Option.option1_2_2
        });

    public static Movement m1_3 = new Movement(
        "  男人似乎被你坚定的语气，抑或是你手中的武器唬住了。\n"+
        "  他一挥手，混混们不情愿地离开了现场。那个女人小声向你们道了谢，匆匆逃离了这条小巷。",
        false,null,
        new List<EventReward>() {

            EventReward.GoldReward(20),
            EventReward.SkillPointReward(2)
        }

    );

    public static Movement m1_4 = new Movement(
        
        "  那群混混纷纷掏出武器，把你团团围住！",
        new List<Option> { Option.battleOption},
        true,
        BattleData.GetBattleData(0, 3),
        null,
        true
        );

    #endregion

    //TODO
    #region 事件1-2 流浪汉
    public static Movement m2_0 = new Movement(
        "  一个浑身酒气的流浪汉向你们走来。\n" +
        "  “酒……我要喝酒！”他含混地喊道。",
        new List<Option>
        {
            Option.option2_0_0,
            Option.option2_0_1,
            Option.option2_0_2,
        }
    );

    public static Movement m2_1 = new Movement(
        "  他见你们要离开，跪坐在地上抓住了你的裤子。\n"+
        "  “别……别走！就……请我喝，喝一杯！”",
        new List<Option>
        {
            Option.option2_1_0,
            Option.option2_1_1,
        }
    );

    public static Movement m2_2 = new Movement(
        "  你给了他重重一巴掌。他似乎被打晕了，摇摇晃晃地消失在了巷子里。",
        false, null,
        new List<EventReward>() {

            EventReward.SkillPointReward(2)
        }
    );

    public static Movement m2_3 = new Movement(
        "  你打了他一巴掌，流浪汉似乎清醒了一些，不过他似乎勃然大怒。\n" +
        "  “敢打老子？臭小鬼，看我不把你教训一顿！”",
        true, BattleData.GetBattleData(0,1)
    );

    public static Movement m2_4 = new Movement(
        "  你请流浪汉喝了一瓶最便宜的劣质酒。他似乎非常兴奋，大喊“小兄弟，我就跟你混了！”\n"+
        "  不等你做出回应，他就自顾自地跟在了队伍后头。",
        false, null,
        new List<EventReward>() {

            EventReward.TeammateReward(105)
        }
    );
    #endregion

    #region 事件1-3 城市捉贼
    public static Movement m3_0 = new Movement(
        "  在路上，你突然被后面冲出的人给撞了一下，这个人似乎怀里还抱着什么东西。\n"+
        "  捉贼啊！你听到身后传来喊叫声。",
        new List<Option>
        {
            Option.option3_0_0,
            Option.option3_0_1
        }
    );

    public static Movement m3_1 = new Movement(
        "  你没有理会小偷和失主，离开了现场。" 

    );

    public static Movement m3_2 = new Movement(
        "  你奋力追逐小偷，但他一转眼就跑入小巷、消失得无影无踪。气喘吁吁的你只得作罢。",
        new List<Option> { Option.finalOption},
        false,null,
        new List<EventReward> { EventReward.SkillPointReward(1)},
        true
    );

    public static Movement m3_3 = new Movement(
        "  小偷眼见你紧追不舍，扔下了一个背包。",
        new List<Option>
        {
                Option.option3_3_0,
                Option.option3_3_1
        });

    public static Movement m3_4 = new Movement(
        "  你捡起背包，里面装着不少现金！你不禁想到，这笔钱能给自己的冒险提供很大帮助……",
        new List<Option>
        {
                Option.option3_4_0,
                Option.option3_4_1
        });

    public static Movement m3_5 = new Movement(
        "  你无视了背包，继续追逐小偷，终于将他逼入了一个死胡同。他转过身来，掏出一把匕首，准备和你鱼死网破！",
        new List<Option> { Option.battleOption },
        true, BattleData.GetBattleData(0,1),
        new List<EventReward> { },
        true
    );

    public static Movement m3_6 = new Movement(
        "  你将背包还给了失主。",
        new List<Option> { Option.finalOption },
        false, null,
        new List<EventReward> { EventReward.SkillPointReward(3)},
        true
    );

    public static Movement m3_7 = new Movement(
        "  你将背包里的钱据为己有，随后头也不回地离开了这片区域。",
        new List<Option> { Option.finalOption },
        false, null,
        new List<EventReward> { EventReward.GoldReward(50)},
        true
    );

    #endregion

    #region 事件1-4 乞丐
    public static Movement m4_0 = new Movement(
        "  你在路边走着，突然被路边的一个衣衫褴褛的乞丐拉住了裤子，他恳求你能施舍他一点钱财去填饱肚子。",
        new List<Option>
        {
            Option.option4_0_0,
            Option.option4_0_1
        }
    );

    public static Movement m4_1 = new Movement(
        "  乞丐为了感激你的恩情，掏出了一本昨天在桥下捡的书，送给了你。",
        new List<Option>
        {
            Option.finalOption
        },
        false, null,
        new List<EventReward> { EventReward.SkillPointReward(2) },
        true
    );

    public static Movement m4_2 = new Movement(
        "  你头也不回地向前走去，后面乞丐的声音越来越远。",
        new List<Option>
        {
            Option.finalOption
        },
        false, null,
        null,
        true
    );

    #endregion

    #region 事件1-5 毒品交易
    public static Movement m5_0 = new Movement(
        "  小巷昏暗的灯光下，你看见两个男人鬼鬼祟祟地交流着些什么，似乎是在进行毒品交易。\n" +
        "  这时，你不小心咳嗽了一声，那两个男人立刻举起武器朝你躲藏的位置走来！",
        new List<Option>
        {
            Option.option5_0_0,
            Option.option5_0_1
        }
    );

    public static Movement m5_1 = new Movement(
        "  你蹑手蹑脚地离开了现场，没有被任何人发现。",
        false, null,
        new List<EventReward>() {
            
            EventReward.SkillPointReward(2)
        }
    );

    public static Movement m5_2 = new Movement(
        "  男人发现了你。“你是什么人？看见我们在做什么了吗？”他大吼道。",
        new List<Option>
        {
            Option.option5_2_0,
            Option.option5_2_1
        }
    );

    public static Movement m5_3 = new Movement(
        "  你宣称什么也没听见，毒贩虽然有些怀疑，最后还是放你走了。",
        false, null,
        new List<EventReward>() {

            EventReward.SkillPointReward(2)
        }
    );

    public static Movement m5_4 = new Movement(
        "  毒贩拿起武器，朝你冲了过来。",
        new List<Option> { Option.battleOption },
        true,
        BattleData.GetBattleData(0,4),
        null,
        true
    );

    #endregion

    #region 事件1-6 恶棍警察 Ⅰ

    public static Movement m6_0 = new Movement(
        "  一个大腹便便、身着警察制服的男人大摇大摆地向你们走来，显然是来找碴的。\n"+
        "  你们违反了城市管理条例对着装的要求！我本来应该把你们抓起来，但今天心情不错，如果你们能给我25块钱的话……",
        new List<Option>
        {
            Option.option6_0_0,
            Option.option6_0_1,
            Option.option6_0_2
        }
    );

    public static Movement m6_1 = new Movement(
        "  警察点了点钱数，满意地离开了。",
        false, null,
        new List<EventReward>() {
            
            EventReward.SkillPointReward(1)
        }

    );

    public static Movement m6_2 = new Movement(
        "  “胆子不小，看来该给你一点教训啊。”警察掏出了他的电棍。",
        new List<Option> { Option.battleOption },

        true,
        BattleData.GetBattleData(0, 7),
        null,
        true
    );

    public static Movement m6_3 = new Movement(
        "  你向警察极力证明了自己的清白，他气急败坏，却也没法找到合适的理由逮捕你。",
        false, null,
        new List<EventReward>() {

            //EventReward.GoldReward(20),
            EventReward.SkillPointReward(3)
        }
    );

    public static Movement m6_4 = new Movement(
        "  你向警察威胁自己认识“道上的”朋友，劝他好自为之。他犹豫了一会，终于骂骂咧咧地离开了",
        false, null,
        new List<EventReward>() {

            //EventReward.GoldReward(20),
            EventReward.SkillPointReward(3)
        }
    );
    #endregion

    #region 事件1-7 毒贩藏匿点
    public static Movement m7_0 = new Movement(
        "  你来到了一间看似废弃的小屋门前。\n" +
        "  从特殊的气味上你认出这是毒贩们藏匿毒品的地方！在这里或许能找到一些有价值的物资，但如果被毒贩发现一定是凶多吉少……",
        new List<Option>
        {
            Option.option7_0_0,
            Option.option7_0_1
        }
    );

    public static Movement m7_1 = new Movement(
        "  你决定不冒这个险。",
        false, null,
        null
    );

    public static Movement m7_2 = new Movement(
        "  你快速地搜索了一番，拿取了一些现金，迅速离开了。",
        false, null,
        new List<EventReward>() {

            EventReward.GoldReward(30),
            EventReward.SkillPointReward(2)
        }
    );
    public static Movement m7_3 = new Movement(
        "  你搜索了一番，但没找到什么有价值的东西。准备离开时，两个毒贩刚好迎面走来！他们立刻拿起了武器。",
        new List<Option> { Option.battleOption },

        true,
        BattleData.GetBattleData(0, 4),
        null,
        true
    );
    #endregion

    #region 事件1-8 科技商店

    public static Movement m8_0 = new Movement(
        "  你来到一家科技商店的门前，这里出售各种无人机和机器人\n" +
        "  这些小玩意儿能够用于侦察或战斗，但价格也不便宜。",
        new List<Option>
        {
            Option.option8_0_0,
            Option.option8_0_1,
            //Option.option8_0_2,
            Option.option8_0_3,

        }
    );

    public static Movement m8_1 = new Movement(
        "  你购买了一架侦察无人机。",
        false, null,
        new List<EventReward>() {

            EventReward.TeammateReward(161)
        }
    );

    public static Movement m8_2 = new Movement(
        "  你购买了一架轰炸无人机。",
        false, null,
        new List<EventReward>() {

            EventReward.TeammateReward(162)
        }
    );

    public static Movement m8_3 = new Movement(
        "  你购买了一台小型武装机器人！",
        false, null,
        new List<EventReward>() {

            EventReward.TeammateReward(163)
        }
    );

    public static Movement m8_4 = new Movement(
        "  你觉得不需要在这里浪费宝贵的金钱，离开了。"
    );


    #endregion

    #region 事件1-9 诊所
    public static Movement m9_0 = new Movement(
        "  你来到一家破旧的小诊所前。在这里可以花费金钱，让医生为你和队友的伤口做一些应急处理。\n" ,
        new List<Option>
        {
            Option.option9_0_0,
            Option.option9_0_1,
            Option.option9_0_2,
        }
    );

    public static Movement m9_1 = new Movement(
        "  医生对你们的伤口进行了紧急处理。",
        false, null,
        new List<EventReward>() {

            EventReward.HealReward(4,1)
        }
    );

    public static Movement m9_2 = new Movement(
        "  医生对你们进行了检查和医治。",
        false, null,
        new List<EventReward>() {

            EventReward.HealReward(10,1)
        }
    );

    public static Movement m9_3 = new Movement(
        "  你没有在诊所前多做停留。"
    );


    #endregion

    #region 事件1-10 雇佣兵Ⅰ
    public static Movement m10_0 = new Movement(
        "  一个衣着有些非主流的少年向你走来。\n"+
        "  “哟，我想你们会需要一个哨兵？我对这块地方很熟，给点小费我就来带路啦。”",
        new List<Option>
        {
            Option.option10_0_0,
            Option.option10_0_1
        }
    );

    public static Movement m10_1 = new Movement(
        "  你向他递出几张纸币，他兴高采烈地收下，加入了队伍。",
        false, null,
        new List<EventReward>() {

            EventReward.TeammateReward(157)
        }
    );

    public static Movement m10_2 = new Movement(
        "  少年无聊地走开了。"
    );
    #endregion

    #region 事件1-11 抽奖机
    public static Movement m11_0 = new Movement(
        "  路边有一台“日冕”公司出品的扭蛋机。上面写着：一次抽奖50元，最高可得200元！" ,
        new List<Option>
        {
            Option.option11_0_0,
            Option.option11_0_1,
            Option.option11_0_2
        }
    );

    

    public static Movement m11_1 = new Movement(
        "  很遗憾没有中奖……要不要再试试？",
        new List<Option>
        {
            Option.option11_0_0,
            Option.option11_0_1,
            Option.option11_0_2
        }
    );

    public static Movement m11_2 = new Movement(
        "  中大奖了！硬币从机器里疯狂地跳出来……要不要再试试？",
        new List<Option>
        {
            Option.option11_0_0,
            Option.option11_0_1,
            Option.option11_0_2
        },
        false,null,
        new List<EventReward> { EventReward.GoldReward(200) },
        false
    );

    public static Movement m11_3 = new Movement(
        "  你利用精湛的黑客技术直接让自己中了头奖。见好就收，你把钱收好便快步离开了。",
        false, null,
        new List<EventReward> { EventReward.GoldReward(200), EventReward.SkillPointReward(2) }
    );

    public static Movement m11_4 = new Movement(
        "  你尝试黑进扭蛋机的系统，但没能成功，反而触发了报警系统……趁没有安保人员过来，你赶紧离开了。",
        false,null,
        new List<EventReward> { EventReward.SkillPointReward(1) }
    );

    public static Movement m11_5 = new Movement(
        "  你觉得这大概是日冕公司的骗局，扭头就走。",
        false,null
    );

    public static Movement m11_6 = new Movement(
        "  你把金钱放入了机器，希望能够中得大奖。",
        new List<Option>
        {
            Option.option11_6_0
        }
    );

    #endregion

    #region 事件1-12 爆炸！
    public static Movement m12_0 = new Movement(
        "  路边的一家商店突然发生了爆炸！冲击波夹带着碎玻璃向你们袭来。",
        new List<Option>
        {
            Option.option12_0_0,
            Option.option12_0_1
        }
    );

    public static Movement m12_1 = new Movement(
        "  你们成功在爆炸的冲击中保护好了自己。",
        false,null,
        new List<EventReward> { EventReward.SkillPointReward(2)}
    );

    public static Movement m12_2 = new Movement(
        "  你们的行动没能完全防护住冲击，队员们受了些轻伤。",
        false, null,
        new List<EventReward> { EventReward.DamageReward(2) }
    );

    #endregion

    #region  事件1-13 邪教徒 Ⅰ
    public static Movement m13_0 = new Movement(
        "  一个穿着斗篷、脸上戴着奇怪面具的人缠上了你们。他似乎想向你们传教！\n"+
        "  “世人皆苦，但只要我们愿意行善，终有一天主会降临，消灭一切罪恶。”他（或者她？）用经过变声器处理的声音说着诸如此类的话。",
        new List<Option>
        {
            Option.option13_0_0,
            Option.option13_0_1,
            Option.option13_0_2,
        }
    );

    public static Movement m13_1 = new Movement(
        "  传教士显得一点也不失望。“我理解你们，当时我也是和你们一样的反应，不过我相信你们有一天会改变想法的。在网络和其他媒体上，你可以随时找到关于‘降临者’的信息，我和主教永远欢迎你们的加入。”他留下了一番意味深长的话。",
        false, null
    );

    public static Movement m13_2 = new Movement(
        "  这个传教士显得非常满意。再拉着你们讲述了一番“教义”之后，他最后说道：\n"+
        "  “现在我们降临者教会正在筹划一次大的善行，需要来自八方的支援，不知道你们是否愿意贡献一点点金钱呢？”",
        new List<Option>
        {
            Option.option13_2_0,
            Option.option13_2_1
        }
    );

    public static Movement m13_3 = new Movement(
        "  传教士显得一点也不失望。“没有关系，在几天之后你就会看到我们的成果，到时候可能会更愿意与我们合作了。相信我们还会再见面。”他留下了一番意味深长的话。",
        false, null
    );

    public static Movement m13_4 = new Movement(
        "  传教士收下了钱，点点头，递给了你一个奇怪的挂饰。“这是‘降临者’信徒专属的标志，好好保管。”没等你说什么，他就转身离开，消失在了人群中。",
        false,null,
        new List<EventReward> { EventReward.SkillPointReward(1)}
    );

    public static Movement m13_5 = new Movement(
        "  传教士变魔术似地从斗篷中掏出了武器。“愚蠢的年轻人，让你们见识一下‘降临者’的怒火！”",
        true, BattleData.GetBattleData(0,8)
    );
    #endregion

    #region 事件2-0 逃亡的革命军
    public static Movement m50_0 = new Movement(
        "  一个少女匆匆从你身边经过，悄悄对你说：“不要告诉后面的警察我往哪里走了。”，说罢，跑进了一条小巷。\n"+
        "  不一会，两个持枪的警察来到你面前。“我们在追捕一个叛乱分子，是一个十几岁的女性，你有没有见过这样的人经过？”",
        new List<Option>
                {
                    Option.option50_0_0,
                    Option.option50_0_1,
                    Option.option50_0_2
        });

    

    public static Movement m50_1 = new Movement(
        "  警察匆匆追向了少女的方向。过了一会，你听见砰砰两声枪响，之后再没有其他声音传来……",
        false,null
   );

    public static Movement m50_2 = new Movement(
        "  警察听信了你的话语，朝着少女的反方向跑去了。待他们走远后，少女向你表示感谢，之后匆匆离开了，连自我介绍也没来得及做。",
        false, null,
        new List<EventReward> { EventReward.GoldReward(30), EventReward.SkillPointReward(2) }
        
    );

    public static Movement m50_3 = new Movement(
        "  警察狐疑地看了你一眼，还是让你离开了。",
        false, null,
        new List<EventReward> { EventReward.SkillPointReward(1) }
    );

    public static Movement m50_4 = new Movement(
        "  警察愤怒道：“臭小鬼，看来你也是和叛乱分子一伙的？那我们先把你给收拾了！”\n" +
        "  说完，他们向你冲来！",
        
        true, BattleData.GetBattleData(2,2)

    );

    #endregion

    #region 事件2-1 失控机器人
    public static Movement m51_0 = new Movement(
        "  路边突然传来了一阵枪声和哭喊声。原来是几台安保机器人被黑客入侵，正在向路人无差别攻击。这些机器人似乎已经把你们锁定为目标，正在准备射击！",
        true, BattleData.GetBattleData(2,5)
    );

    #endregion

    #region 事件2-2 遭遇黑帮 Ⅱ
    public static Movement m52_0 = new Movement(
        "你走在一条小路中，突然一群混混把你团团围住。你认出，这些混混是“巨齿鲨”帮会的成员！\n" +
        "  他们宣称要替“老大”给你一个教训……",
        new List<Option>
                {
                    Option.option52_0_0,
                    Option.option52_0_1
                });

    public static Movement m52_1 = new Movement(
        "你灵活的闪转腾挪，躲过混混们的棍棒，转眼间逃离了现场。",
        false, null,
        new List<EventReward>() {

            //EventReward.GoldReward(20),
            EventReward.SkillPointReward(3)
        }
    );

    public static Movement m52_2 = new Movement(
        "那群混混大吼一声便冲了过来。",
        new List<Option> { Option.battleOption },

        true,
        BattleData.GetBattleData(0, 51),
        null,
        true
    );
    #endregion

    //TODO
    #region 事件2-3 帮派火并Ⅰ
    public static Movement m53_0 = new Movement(
        "  你们路过一条荒无人烟的小路，这时从你们的身前、身后同时传来了枪声！原来是“巨齿鲨”帮会正在与红莲团交火。\n"+
        "  你可以躲在掩体后等待双方离去，也可以站出来帮助其中一方。",
        new List<Option>
        {
            Option.option53_0_0,
            Option.option53_0_1,
            Option.option53_0_2
        }
    );

    public static Movement m53_1 = new Movement(
        "  你利用道路上的路障与建筑作为掩体，成功保护了全队成员。十几分钟的交火后，双方似乎都离去了。",
        false, null,
        new List<EventReward> {EventReward.SkillPointReward(3)}
    );

    public static Movement m53_2 = new Movement(
        "  你利用道路上的路障与建筑作为掩体，但还是有几个队员不慎被流弹击中，受了轻伤。",
        false, null,
        new List<EventReward> { EventReward.DamageReward(4) }
    );

    public static Movement m53_3 = new Movement(
        "  你和队员从掩体中跑出，与“巨齿鲨”帮会成员正面交战！",
        true, BattleData.GetBattleData(0, 501)
    );

    public static Movement m53_4 = new Movement(
        "  你和队员从掩体中跑出，与“红莲团”帮会成员正面交战！",
        true, BattleData.GetBattleData(0, 501)
    );


    #endregion

    #region 事件2-4 陌生男人Ⅰ
    public static Movement m54_0 = new Movement(
        "  昏暗的路灯下，一个陌生男人向你们招手。男人身上的衣装十分破旧，但健硕的身形和坚毅的目光显示出他并非等闲之辈。\n"+
        "  “少年少女们，你们想要改变这座城市吗？”男人伸了个懒腰问道。",
        new List<Option>
        {
            Option.option54_0_0,
            Option.option54_0_1
        }
    );

    public static Movement m54_1 = new Movement(
        "  “看来你们不是我要找的人。”男人耸了耸肩，离开了。",
        false, null
    );

    public static Movement m54_2 = new Movement(
        "  “那你们拥有怎样的本领来做出改变呢？”男人饶有兴致地问道。",
        new List<Option>
        {
            Option.option54_2_0,
            Option.option54_2_1,
            Option.option54_2_2
        }
    );

    public static Movement m54_3 = new Movement(
        "  “口说无凭，我就来试试你们的能耐！”男人突然起身向你们发动了攻击！",
        true, BattleData.GetBattleData(0,502)
    );

    public static Movement m54_4 = new Movement(
        "  “哈哈哈，很有意思！好，我就来助你们一臂之力！”男人赞赏地说，他同意为你们提供一些帮助。",
        new List<Option>
        {
            Option.option54_4_0,
            Option.option54_4_1
        }
    );

    public static Movement m54_5 = new Movement(
        "  男人向你扔来一个钱袋。",
        false, null,
        new List<EventReward> { EventReward.GoldReward(100)}
    );

    public static Movement m54_6 = new Movement(
        "  男人教了你们几个招式。",
        false, null,
        new List<EventReward> { EventReward.SkillPointReward(4) }
    );


    #endregion

    #region 事件2-5 政府盘查 Ⅰ

    public static Movement m55_0 = new Movement(
        "  一个身着制服的女子和两名荷枪实弹的武装人员拦住了你们。\n"+
        "  “这里是贫民窟的边缘地区，一般人没事不会到这里来。实际上，这附近有叛乱分子的活动迹象，你们这些贱民都有同谋的嫌疑！我给你三分钟，说明你的身份和来这里的目的！”",
        new List<Option>
        {
            Option.option55_0_0,
            Option.option55_0_1
        }
    );

    public static Movement m55_1 = new Movement(
        "  你伶牙俐齿地解释道自己没有恶意，是迷路了才来到这里的。穿着制服的女人虽然还是有点怀疑，但最终还是放走了你们。",
        false, null,
        new List<EventReward> { EventReward.SkillPointReward(2)}
    );

    public static Movement m55_2 = new Movement(
        "  穿着制服的女人一下就听出你在胡扯。她压低了声音说道：\n"+
        "  “你是糊弄不了我的。如果你不老实，我先让人把你的腿给打断！”",
        new List<Option>
        {
                Option.option55_0_1,
                Option.option55_2_1
        }
    );

    public static Movement m55_3 = new Movement(
        "  你给了女人一击重拳，打得她摔在地上不省人事。旁边的两个保安立刻向你冲来！\n"+
        "  （战斗难度降低）" ,
        true, BattleData.GetBattleData(2,2)
    );

    public static Movement m55_4 = new Movement(
        "  你们拔腿就溜，穿制服的女人气得直跺脚。",
        false, null,
            new List<EventReward> { EventReward.SkillPointReward(2) }
        );

    public static Movement m55_5 = new Movement(
        "  你们拔腿就溜，但跑不过训练有素的两个保安。\n"+
        "  “果然有鬼！先给他们点教训！”女人一边说道，一边也掏出了武器。",
        true, BattleData.GetBattleData(0,505)
        );

    public static Movement m55_6 = new Movement(
        "  女人灵活地躲开了你的攻击。“小兔崽子，胆子不小啊！给我往死里打!”她向两个保安发出指令。" ,
        true, BattleData.GetBattleData(0, 505)
    );

    #endregion


    #region 事件2-6 流浪乐手

    public static Movement m56_0 = new Movement(
        "  路边，一个卖艺的小女孩正用一台手风琴样的乐器演奏着优美的音乐。这乐器不但能奏出乐音，还发射着随声音变化的美丽光线。周围的路人行色匆匆，没有一个停下来欣赏她的音乐……",
        new List<Option>
        {
            Option.option56_0_0,
            Option.option56_0_1
        }
    );

    public static Movement m56_1 = new Movement(
        "  小女孩向你们鞠了个躬表示感谢，接下来为你们演奏了一首优美而忧伤的乐曲，在声和光的共同作用下，你们似乎得到了治愈……",
        new List<Option>
        {
            Option.finalOption
        },
        false, null,
        new List<EventReward> { EventReward.HealReward(3,1), EventReward.SkillPointReward(1) },
        true
    );

    public static Movement m56_2 = new Movement(
        "  你头也不回地向前走去，风琴的声音越来越远。",
        new List<Option>
        {
            Option.finalOption
        },
        false, null,
        null,
        true
    );
    #endregion

    #region 事件2-7 恶棍警察 Ⅱ
    public static Movement m57_0 = new Movement(
        "  路边突然传来一阵惨叫声！原来是三个警察正对着一位看起来像是公司员工的男子拳打脚踢！男子抱头趴在地上，已经流了不少血，但警察完全没有停手的意思。",
        new List<Option>
        {
            Option.option57_0_0,
            Option.option57_0_1
        }
    );

    public static Movement m57_1 = new Movement(
        "  你觉得不要凑这个热闹，离开了。男子的惨叫声越来越远……",
        false, null
    );

    public static Movement m57_2 = new Movement(
        "  见你们走上前来，一个警察趾高气扬地过来说：\n"+
        "  “这个男人有窝藏叛乱分子的嫌疑。你不要干扰执法，快点离开！”",
        new List<Option>
        {
            Option.option57_2_0,
            Option.option57_2_1,
            Option.option57_2_2
        }
    );

    public static Movement m57_3 = new Movement(
        "  你宣称男人是黑帮的重要合作伙伴，劝警察们好自为之。他们听信了你的说辞，犹豫再三还是离开了。",
        new List<Option>
        {
            Option.option57_3_0
        }
    );

    public static Movement m57_4 = new Movement(
        "  警察停止了对男人的攻击，转而拿起警棍朝向了你！",
        true, BattleData.GetBattleData(0,504)
    );

    public static Movement m57_5 = new Movement(
        "  警察们收下了这一大笔钱，顿时眉开眼笑，互相说道“都是误会”，转身就离开了。",
        new List<Option>
        {
            Option.option57_3_0
        }
    );

    public static Movement m57_6 = new Movement(
        "  男人艰难地站起身，向你们表示了感谢。他说无以为报，如果需要他的帮助一定全力以赴。",
        new List<Option>
        {
            Option.option57_6_0,
            Option.option57_6_1
        }
    );

    public static Movement m57_7 = new Movement(
        "  男人给了你他身上的所有金钱。",false, null,
        new List<EventReward> { EventReward.GoldReward(80)}
    );

    public static Movement m57_8 = new Movement(
        "  男人犹豫了一会，最后说道：“反正我的工作也丢了，正无处可去，就和你们一起冒险吧。”",
        false, null,
        new List<EventReward> { EventReward.TeammateReward(12) }
    );


    #endregion

    #region 事件2-8 爆炸
    #endregion

    #region 事件2-9 雇佣兵 Ⅱ
    public static Movement m59_0 = new Movement(
        "  一个年轻人向你走来。他身着混搭的装备，腰上别着一支新型号的手枪。\n" +
        "  “我想你可能会需要一个保镖？我靠当佣兵为生，你给我钱，我能帮你解决麻烦。”他这样说道。",
        new List<Option>
        {
            Option.option59_0_0,
            Option.option59_0_1
        }
    );

    public static Movement m59_1 = new Movement(
        "  你向他递出一叠金钱，他默默收下后跟在了队伍后面。",
        false, null,
        new List<EventReward>() {

            EventReward.TeammateReward(151)
        }
    );

    public static Movement m59_2 = new Movement(
        "  你拒绝了年轻的枪手，他哼了一声便离开了。"
    );
    #endregion

    #region 事件2-10 邪教徒 Ⅱ
    public static Movement m60_0 = new Movement(
        "  两个身穿斗篷的人从你们身边匆匆走过，你认出了“降临者教团”的标志！这些邪教徒是在密谋些什么吗？",
        new List<Option>
        {
            Option.option60_0_0,
            Option.option60_0_1,
            Option.option60_0_2
        }
    );

    public static Movement m60_1 = new Movement(
        "  你无视了邪教徒继续前进。他们去了哪里？准备做些什么呢？这都与你无关。",
        false,null
    );

    public static Movement m60_2 = new Movement(
        "  你悄悄跟随邪教徒们来到了一个偏僻的小巷中。你看见一个男人把一个大麻袋交给了邪教徒：“仪式的材料已经准备好了。”。\n"+
        "  一个教徒把麻袋打开查看，里面居然是一个被捆住手脚的男孩！邪教的“仪式”，恐怕不会是什么好事情……",
        new List<Option>
        {
            Option.option60_2_0,
            Option.option60_2_1
        }
    );

    public static Movement m60_3 = new Movement(
        "  三人被你的出现吓了一跳，但很快他们反应过来，向你发动了攻击！那个男孩趁机挣脱绳索，逃离了小巷。",
        true, BattleData.GetBattleData(0,503)
    );

    public static Movement m60_4 = new Movement(
        "  你没有出声，看着邪教徒把男孩又装回麻袋里，随后一起走进了一所破败的大楼之中。",
        false, null,
        new List<EventReward> { EventReward.SkillPointReward(1)}
    );

    public static Movement m60_5 = new Movement(
        "  两个教徒相互对视一眼，二话不说向你发动了攻击！",
        true, BattleData.GetBattleData(0,56)
    );


    #endregion



    #region 第一大关 初始事件
    public static Movement m_e_1_0 = new Movement(
        "  在这座光怪陆离的大都会中，少数上流社会的人享受着穷奢极欲的生活，而大部分居民则只能挣扎求生，城市一端的贫民窟更是混乱与罪恶的孳生之处……\n"+
        "  你则与身边的伙伴一起，始终寻找着逃离贫民窟的机会。",
        new List<Option>
        {
            Option.option_e1_0_0,
        }
    );

    public static Movement m_e_1_1 = new Movement(
        "  某日在路上，你收到一封信：“你的朋友在我手上，速来！”上面还附带一个酒吧的地址。你认出这个地址位于黑帮活跃的地区，路途恐怕非常艰险。\n"+
        "  但你救人心切，没多做考虑便准备出发。",
        new List<Option>
        {
            Option.option_e1_1_0,
        }
    );

    public static Movement m_e_1_2 = new Movement(
        "  你与搭档的冒险之旅即将启程。在此之前，你觉得需要做一些准备，是什么呢？",
        new List<Option>
        {
            Option.option_e1_2_0,
            Option.option_e1_2_1,
        }
    );

    public static Movement m_e_1_3 = new Movement(
        "  你取走了之前藏起来的一小笔积蓄。",
        false, null,
        new List<EventReward>() {

            EventReward.GoldReward(80)
        }
    );

    public static Movement m_e_1_4 = new Movement(
        "  你又喊上了一个信得过的伙伴同行。",
        false, null,
        new List<EventReward>() {
            EventReward.TeammateReward(11)
        }
    );

    #endregion

    #region 第一大关 Boss

    public static Movement m_e_2_0 = new Movement(
        "  你来到了信上所标注的地址：“大牙”酒吧。来这里喝酒的大都是黑帮成员与通缉犯，他们不怀好意的眼光让你不寒而栗。\n"+
        "  在吧台边，一个看起来风度翩翩的金发男子向你们招手。你走上前去，谁知他一个眼神，几个打手便向你们冲来。这是个陷阱！" ,
        new List<Option> { Option.battleOption},
        true,
        BattleData.GetBattleData(0, 1001),
        null,
        true
    );


    #endregion


    #region 第二大关 初始事件
    public static Movement m_e_3_0 = new Movement(
        "  你使出浑身解数，打趴了几个黑帮。老大收起武器，鼓了鼓掌。“不错，你果然是个可造之才，带上你的伙伴走吧。不过其实我还有些想告诉你的事情。”",
                new List<Option>
                {
                    Option.option_e3_0_0,
                    Option.option_e3_0_1
                }
                
    );

    public static Movement m_e_3_1 = new Movement(
        "  看到你仍举着武器，老大赞许地点了点头。“你的谨慎是正确的。在贫民窟，只有时刻警惕才能活下去，不过改变这一切的机会已经来了。"+
        "  我暗中观察你很久了，你有成为一名战士的潜质，我希望你能去见见革命军的‘K教官’”",
                new List<Option>
                {
                    Option.option_e3_1_0,
                });

    public static Movement m_e_3_2 = new Movement(
        "  老大继续说道：" +
        "  “我暗中观察你很久了，你有成为一名战士的潜质，我希望你能去见见革命军的‘K教官’”",
                new List<Option>
                {
                    Option.option_e3_1_0,
                });

    public static Movement m_e_3_3 = new Movement(
        "  “不错，他们正策划推翻“日冕”公司在城市的统治，到时候本地的帮派也会提供支持。到这个地方去吧，或许很危险，但靠你的身手没问题，大概？此地不宜久留，快走吧。”他不怀好意地笑了笑，递给你一张破破烂烂的纸条，上面写着一个富人区的地址。",
        false, null,
        new List<EventReward>() {
            EventReward.RandomMainCharacterReward()
        }
    );

    #endregion


    #region 第二大关 Boss
    public static Movement m_e_4_0 = new Movement(
        "  “好了小家伙们，游戏时间该结束了。”一位警官与几个警员出现在你们面前。\n"+
        "  “我有证据表明你们与革命军有关，现在按照法律要将你们逮捕。还有什么要说的吗？”",
        new List<Option>
        {
            Option.option_e_4_0_0,
            Option.option_e_4_0_1

        }
    );

    public static Movement m_e_4_1 = new Movement(
        "  警官明显出现了一些动摇，但他想了想，接着说道：\n"+
        "  “好吧，或许是我搞错了，你们可能不是叛乱分子。不过你们之前殴打警察的事情是确凿无疑的，总之要抓起来。动手！”\n"+
        "  （战斗难度降低）",
        true,
        BattleData.GetBattleData(0, 1002)
    );

    public static Movement m_e_4_2 = new Movement(
        "  你们不等警长说完话，发动了突袭，转眼间击倒了其中一名警察！剩余的警员马上展开了反击。\n"+
        "  （战斗难度降低）",
        true,
        BattleData.GetBattleData(0, 1002)
    );

    public static Movement m_e_4_3 = new Movement(
        "  警官一声令下，几个警察纷纷朝你们走来，警官自己也举起了枪！看上去他不是要逮捕犯人，而是要直接处决你们！",
        true,
        BattleData.GetBattleData(0, 1003)
    );
    #endregion
}


