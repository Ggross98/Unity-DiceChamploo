
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



    private static BattleData Battle_1 = new BattleData(
        
        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101)

        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(1) }


    );

    private static BattleData Battle_2 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101),
            CharacterData.GetCharacterData(102)

        }),

        new List<EventReward>() { EventReward.GoldReward(20), EventReward.SkillPointReward(2) }


    );

    private static BattleData Battle_101 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(101),
            CharacterData.GetCharacterData(102),
            CharacterData.GetCharacterData(101),
            CharacterData.GetCharacterData(102)

        }),

        new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(5) }


    );

    private static BattleData Battle_102 = new BattleData(

        new TeamData(new List<CharacterData>() {

            CharacterData.GetCharacterData(103)

        }),

        new List<EventReward>() { EventReward.GoldReward(50), EventReward.SkillPointReward(5) }


    );



    private static Dictionary<int, BattleData> battleDictionary_event = new Dictionary<int, BattleData>() {

        {1, Battle_1 },

        {2, Battle_2 },

        {101, Battle_101 },

        {102, Battle_102 },

    };

    private static Dictionary<int, BattleData> battleDictionary_1 = new Dictionary<int, BattleData>() {

        {1, Battle_1 },

        {2, Battle_2 },

    };

    private static Dictionary<int, BattleData>[] battleDictionary = new Dictionary<int, BattleData>[] { battleDictionary_event, battleDictionary_1, battleDictionary_1 };


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
