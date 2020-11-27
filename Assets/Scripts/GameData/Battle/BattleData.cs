
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData : EventDataBase
{
    //List<CharacterData> characters;
    public TeamData enemyTeam;

    public List<EventReward> rewards;

    private BattleData()
    {
        enemyTeam = new TeamData();

        List<CharacterData> enemyCharacters = new List<CharacterData>() {

            

        };

        enemyTeam.characters = enemyCharacters;

        rewards = new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(5)};
    }

    private BattleData(TeamData _team, List<EventReward> _rewards)
    {
        enemyTeam = _team;
        rewards = _rewards;
    }

    #region 第一大关
    /// <summary>
    /// 一个小混混
    /// </summary>
    private static BattleData Battle_1_1 = new BattleData(
        
        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101)

        }),

        new List<EventReward>() { EventReward.GoldReward(10), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 一男一女两个小混混
    /// </summary>
    private static BattleData Battle_1_2 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101),
            CharacterData.GetCharacterData(102)

        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(2) }


    );

    /// <summary>
    /// 两男一女三个小混混
    /// </summary>
    private static BattleData Battle_1_3 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101),
            CharacterData.GetCharacterData(102),
            CharacterData.GetCharacterData(101),

        }),

        new List<EventReward>() { EventReward.GoldReward(30), EventReward.SkillPointReward(2) }


    );

    /// <summary>
    /// 一混混一枪手
    /// </summary>
    private static BattleData Battle_1_4 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101),
            CharacterData.GetCharacterData(151)

        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(2) }


    );

    /// <summary>
    /// 一个枪手
    /// </summary>
    private static BattleData Battle_1_5 = new BattleData(

    new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(151)

    }),

    new List<EventReward>() { EventReward.GoldReward(10), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 一台智能炮塔
    /// </summary>
    private static BattleData Battle_1_6 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(163)

        }),

        new List<EventReward>() { EventReward.GoldReward(10), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 一个持棍武警
    /// </summary>
    private static BattleData Battle_1_7 = new BattleData(

    new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(155)

    }),

    new List<EventReward>() { EventReward.GoldReward(10), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 一个邪教徒
    /// </summary>
    private static BattleData Battle_1_8 = new BattleData(

    new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(103)

    }),

    new List<EventReward>() { EventReward.GoldReward(10), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 两个1级武警
    /// </summary>
    private static BattleData Battle_1_9 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(155),
            CharacterData.GetCharacterData(156)
        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(1) }


    );

    #endregion

    #region 第二大关

    /// <summary>
    /// 男女小混混枪手，均2级
    /// </summary>
    private static BattleData Battle_2_1 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101,2),
            CharacterData.GetCharacterData(102,2),
            CharacterData.GetCharacterData(151,2),

        }),

        new List<EventReward>() { EventReward.GoldReward(30), EventReward.SkillPointReward(2) }


    );

    /// <summary>
    /// 两个混混，两个枪手
    /// </summary>
    private static BattleData Battle_e_1 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101,2),
            CharacterData.GetCharacterData(151,2),
            CharacterData.GetCharacterData(102,2),
            CharacterData.GetCharacterData(151,2),


        }),

        new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(3) }


    );

    /// <summary>
    /// 三个二级警察
    /// </summary>
    private static BattleData Battle_e_4 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(155,2),
            CharacterData.GetCharacterData(156,2),
            CharacterData.GetCharacterData(155,2)


        }),

        new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(3) }


    );

    /// <summary>
    /// 神秘男子
    /// </summary>
    private static BattleData Battle_e_2 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(13)
        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 两个武警，一个女人
    /// </summary>
    private static BattleData Battle_e_5 = new BattleData(

    new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(155,2),
            CharacterData.GetCharacterData(106,2),
            CharacterData.GetCharacterData(156,2)
    }),

    new List<EventReward>() { EventReward.GoldReward(30), EventReward.SkillPointReward(1) }


);


    /// <summary>
    /// 两个2级武警
    /// </summary>
    private static BattleData Battle_2_2 = new BattleData(

    new TeamData(new List<CharacterData>() {

        CharacterData.GetCharacterData(155,2),
        CharacterData.GetCharacterData(156,2)
    }),

    new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(1) }


);

    /// <summary>
    /// 两个2级教徒
    /// </summary>
    private static BattleData Battle_2_6 = new BattleData(

    new TeamData(new List<CharacterData>() {

        CharacterData.GetCharacterData(103,2),
        CharacterData.GetCharacterData(103,2)
    }),

    new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(1) }


);

    /// <summary>
    /// 两个2级教徒，一个3级枪手
    /// </summary>
    private static BattleData Battle_e_3 = new BattleData(

    new TeamData(new List<CharacterData>() {

        CharacterData.GetCharacterData(103,2),
        CharacterData.GetCharacterData(151,3),
        CharacterData.GetCharacterData(103,2)
    }),

    new List<EventReward>() { EventReward.GoldReward(30), EventReward.SkillPointReward(2) }


);


    /// <summary>
    /// 一个2级重装干员
    /// </summary>
    private static BattleData Battle_2_3 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(152,2)

        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(1) }


    );

    /// <summary>
    /// 科学家和两台无人机
    /// </summary>
    private static BattleData Battle_2_4 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(161),
            CharacterData.GetCharacterData(154),
            CharacterData.GetCharacterData(162)

        }),

        new List<EventReward>() { EventReward.GoldReward(30), EventReward.SkillPointReward(2) }


    );

    /// <summary>
    /// 两台智能炮塔
    /// </summary>
    private static BattleData Battle_2_5 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(163,1),
            CharacterData.GetCharacterData(163,2),

        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(2) }


    );

    #endregion

    /// <summary>
    /// 第一大关boss战
    /// </summary>
    private static BattleData Battle_boss_1 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101,1),
            CharacterData.GetCharacterData(1001),
            CharacterData.GetCharacterData(102,1)

        }),

        new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(5) }


    );

    /// <summary>
    /// 第二大关boss战（临时）
    /// </summary>
    private static BattleData Battle_boss_2_easy = new BattleData(

        new TeamData(new List<CharacterData>() {
            //CharacterData.GetCharacterData(155,2),
            CharacterData.GetCharacterData(1002),
            CharacterData.GetCharacterData(156,2)

        }),

        new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(5) }


    );

    private static BattleData Battle_boss_2_hard = new BattleData(

        new TeamData(new List<CharacterData>() {
            //CharacterData.GetCharacterData(155,2),
            CharacterData.GetCharacterData(1002),
            CharacterData.GetCharacterData(156,2),
            CharacterData.GetCharacterData(155,2),

        }),

    new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(5) }


);



    private static Dictionary<int, BattleData> battleDictionary_event = new Dictionary<int, BattleData>() {

        { 1, Battle_1_1 },{ 4, Battle_1_4 },{ 6, Battle_1_6 },{ 7, Battle_1_7 },
        { 2, Battle_1_2 },{ 3, Battle_1_3 },{ 5, Battle_1_5 },{ 8, Battle_1_8 },{ 9, Battle_1_9 },

        { 51, Battle_2_1 },{ 54, Battle_2_4 },{ 55, Battle_2_5 },{ 56, Battle_2_6 },
        { 52, Battle_2_2 },{ 53, Battle_2_3 },/*{ 57, Battle_2_7 },{ 58, Battle_2_8 },*/

        { 501, Battle_e_1},{ 502, Battle_e_2},{ 503, Battle_e_3},{ 504, Battle_e_4},{ 505, Battle_e_5},

        { 1001, Battle_boss_1 },{ 1002, Battle_boss_2_easy },{ 1003, Battle_boss_2_hard },


    };

    private static Dictionary<int, BattleData> battleDictionary_1 = new Dictionary<int, BattleData>() {

        { 1, Battle_1_1 },{ 4, Battle_1_4 },{ 6, Battle_1_6 },{ 7, Battle_1_7 },
        { 2, Battle_1_2 },{ 3, Battle_1_3 },{ 5, Battle_1_5 },{ 8, Battle_1_8 },{ 9, Battle_1_9 },
    };

    private static Dictionary<int, BattleData> battleDictionary_2 = new Dictionary<int, BattleData>() {

        { 1, Battle_2_1 },{ 4, Battle_2_4 },{ 5, Battle_2_5 },{ 6, Battle_2_6 },
        { 2, Battle_2_2 },{ 3, Battle_2_3 },
    };

    private static Dictionary<int, BattleData>[] battleDictionary = new Dictionary<int, BattleData>[] { battleDictionary_event, battleDictionary_1, battleDictionary_2 };


    /// <summary>
    /// 获得特定战斗数据
    /// </summary>
    /// <param name="level">0:事件战斗；1-3：第n大关的战斗</param>
    /// <param name="index">序号</param>
    /// <returns></returns>
    public static BattleData GetBattleData(int level, int index)
    {
        if(level < 0 || level >= battleDictionary.Length)
        {
            Debug.LogError("Battle data index error!");
            return null;
        }

        if (battleDictionary[level].ContainsKey(index))
        {
            return battleDictionary[level][index];
        }
        else
        {
            return battleDictionary[level][1];
        }
    }


    public static List<BattleData> GetRandomBattleDataList(int level, int count)
    {
        List<BattleData> list = new List<BattleData>();

        if (count <= 0 || level < 1 || level > battleDictionary.Length) return list;


        List<BattleData> data = new List<BattleData>();
        int iCount = 0;

        while(iCount < count)
        {
            if (data.Count < 1)
            {
                foreach (BattleData bd in battleDictionary[level].Values)
                {
                    data.Add(bd);
                }
            }

            int index = Random.Range(0, data.Count);

            list.Add(data[index]);
            data.RemoveAt(index);

            iCount++;

        }

        return list;
    }
}
