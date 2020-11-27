//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventData: EventDataBase
{
    //internal string description;
    //Sprite icon;

    internal List<Movement> movements;

    public EventData(string d, List<Movement> m)
    {
        description = d;
        movements = m;
    }
    //public string getEventDiscription() { return description; }

    //返回当前场景描述
    // public string getMovementDiscription() { return movements[currentMovement].description; }

    //返回场景所有选项的描述
    //public string[] getOptionDiscrioption() { return movements[currentMovement].getOptionDiscription(); }
    /*
    public OptionResult CheckOption(int index, )
    {
        if (movements[currentMovement].isEnding)
            return Ending;
    }

    void Jump(int optionIndex, int result)
    {

        currentMovement = currentMovement.options[optionIndex].nextIndex[result];

    }*/
    //***********************数据库**************************

    #region 第一大关事件
    private static EventData Event1_0 = new EventData(
        "遭遇劫匪",
        new List<Movement>(){
            Movement.m0_0,
            Movement.m0_1,
            Movement.m0_2,
            Movement.m0_3,

        });

    private static EventData Event1_1 = new EventData(
        "遭遇黑帮Ⅰ",
        new List<Movement> {
            Movement.m1_0,
            Movement.m1_1,
            Movement.m1_2,
            Movement.m1_3,
            Movement.m1_4
        });

    private static EventData Event1_2 = new EventData(
        "流浪汉",
        new List<Movement> {
                Movement.m2_0,
                Movement.m2_1,
                Movement.m2_2,
                Movement.m2_3,
                Movement.m2_4
        });

    private static EventData Event1_3 = new EventData(
        
        "城市捉贼",
        new List<Movement> {

            Movement.m3_0,
            Movement.m3_1,
            Movement.m3_2,
            Movement.m3_3,
            Movement.m3_4,
            Movement.m3_5,
            Movement.m3_6,
            Movement.m3_7,
        }
    );

    private static EventData Event1_4 = new EventData(
        "乞丐",
        new List<Movement>
        {
            Movement.m4_0,
            Movement.m4_1,
            Movement.m4_2
        });

    private static EventData Event1_5 = new EventData(
        "目睹交易",
        new List<Movement>
        {
            Movement.m5_0,
            Movement.m5_1,
            Movement.m5_2,
            Movement.m5_3,
            Movement.m5_4
        });

    private static EventData Event1_6 = new EventData(
        "警察恶棍 Ⅰ",
        new List<Movement>
        {
                Movement.m6_0,
                Movement.m6_1,
                Movement.m6_2,
                Movement.m6_3,
                Movement.m6_4
    });

    private static EventData Event1_7 = new EventData(
        "毒贩藏匿点",
        new List<Movement>
        {
            Movement.m7_0,
            Movement.m7_1,
            Movement.m7_2,
            Movement.m7_3
        });

    private static EventData Event1_8 = new EventData(
        "科技商店",
        new List<Movement>
        {
            Movement.m8_0,
            Movement.m8_1,
            Movement.m8_2,
            Movement.m8_3,
            Movement.m8_4
        });

    private static EventData Event1_9 = new EventData(
        "诊所",
        new List<Movement>
        {
            Movement.m9_0,
            Movement.m9_1,
            Movement.m9_2,
            Movement.m9_3
        });

    private static EventData Event1_10 = new EventData(
        "雇佣兵Ⅰ",
        new List<Movement>
        {
            Movement.m10_0,
            Movement.m10_1,
            Movement.m10_2
        });

    private static EventData Event1_11 = new EventData(
        "抽奖机",
        new List<Movement>
        {
            Movement.m11_0,
            Movement.m11_1,
            Movement.m11_2,
            Movement.m11_3,
            Movement.m11_4,
            Movement.m11_5,
            Movement.m11_6
        });

    private static EventData Event1_12 = new EventData(
        "爆炸！",
        new List<Movement>
        {
            Movement.m12_0,
            Movement.m12_1,
            Movement.m12_2
        });

    private static EventData Event1_13 = new EventData(
        "邪教徒 Ⅰ",
        new List<Movement>
        {
            Movement.m13_0,
            Movement.m13_1,
            Movement.m13_2,
            Movement.m13_3,
            Movement.m13_4,
            Movement.m13_5
        });

    #endregion

    #region 第二大关事件
    private static EventData Event2_0 = new EventData(
        "逃亡的革命军",
        new List<Movement>
        {
            Movement.m50_0,
            Movement.m50_1,
            Movement.m50_2,
            Movement.m50_3,
            Movement.m50_4
        });

    private static EventData Event2_1 = new EventData(
       "智械失控",
       new List<Movement>
       {
                Movement.m51_0
       });

    private static EventData Event2_2 = new EventData(
        "遭遇黑帮 Ⅱ",
        new List<Movement>
        {
                Movement.m52_0,
                Movement.m52_1,
                Movement.m52_2
        });

    private static EventData Event2_3 = new EventData(
        "帮派火并",
        new List<Movement>
        {
                Movement.m53_0,
                Movement.m53_1,
                Movement.m53_2,
                Movement.m53_3,
                Movement.m53_4
        });

    private static EventData Event2_4 = new EventData(
        "神秘流浪者",
        new List<Movement>
        {
                Movement.m54_0,
                Movement.m54_1,
                Movement.m54_2,
                Movement.m54_3,
                Movement.m54_4,
                Movement.m54_5,
                Movement.m54_6
        });

    private static EventData Event2_5 = new EventData(
        "政府盘查 Ⅰ",
        new List<Movement>
        {
                Movement.m55_0,
                Movement.m55_1,
                Movement.m55_2,
                Movement.m55_3,
                Movement.m55_4,
                Movement.m55_5,
                Movement.m55_6
        });


    private static EventData Event2_6 = new EventData(
        "流浪乐手",
        new List<Movement>
        {
                    Movement.m56_0,
                    Movement.m56_1,
                    Movement.m56_2
        });


    private static EventData Event2_7 = new EventData(
        "恶棍警察 Ⅱ",
        new List<Movement>
        {
                    Movement.m57_0,
                    Movement.m57_1,
                    Movement.m57_2,
                    Movement.m57_3,
                    Movement.m57_4,
                    Movement.m57_5,
                    Movement.m57_6,
                    Movement.m57_7,
                    Movement.m57_8
        });


    private static EventData Event2_9 = new EventData(
        "雇佣兵 Ⅱ",
        new List<Movement>
        {
                    Movement.m59_0,
                    Movement.m59_1,
                    Movement.m59_2
        });

    private static EventData Event2_10 = new EventData(
        "邪教徒 Ⅱ",
        new List<Movement>
        {
                    Movement.m60_0,
                    Movement.m60_1,
                    Movement.m60_2,
                    Movement.m60_3,
                    Movement.m60_4,
                    Movement.m60_5
        });

    #endregion

    #region 剧情事件
    private static EventData Story1_0 = new EventData(
        
        "启程",
        new List<Movement> {
            Movement.m_e_1_0,
            Movement.m_e_1_1,
            Movement.m_e_1_2,
            Movement.m_e_1_3,
            Movement.m_e_1_4,


        }
    );

    private static EventData Story1_1 = new EventData(

        "“大牙”酒吧",
        new List<Movement> {
            Movement.m_e_2_0
        }
    );

    private static EventData Story2_0 = new EventData(

        "再度启程",
        new List<Movement> {
            Movement.m_e_3_0,
            Movement.m_e_3_1,
            Movement.m_e_3_2,
            Movement.m_e_3_3,


        }
    );

    private static EventData Story2_1 = new EventData(

        "第二章boss战",
        new List<Movement> {
            Movement.m_e_4_0,
            Movement.m_e_4_1,
            Movement.m_e_4_2,
            Movement.m_e_4_3,
        }
    );

    #endregion


    private static Dictionary<int, EventData> eventDictionary_1 = new Dictionary<int, EventData>() {

        { 0, Event1_0 },
        { 1, Event1_1 },
        { 2, Event1_2 },
        { 3, Event1_3 },
        { 4, Event1_4 },
        { 5, Event1_5 },
        { 6, Event1_6 },
        { 7, Event1_7 },
        { 8, Event1_8 },
        { 9, Event1_9 },
        { 10, Event1_10 },
        { 11, Event1_11 },
        { 12, Event1_12 },
        { 13, Event1_13 },
    };

    private static Dictionary<int, EventData> eventDictionary_2 = new Dictionary<int, EventData>() {

        { 0, Event2_0 },
        { 1, Event2_1 },
        { 2, Event2_2 },
        { 3, Event2_3 },
        { 4, Event2_4 },
        { 5, Event2_5 },
        { 6, Event2_6 },
        { 7, Event2_7 },
        //{ 8, Event2_8 },
        { 9, Event1_9 },
        { 10, Event1_10 },

        { 101,  Event1_8},
        { 102,  Event1_9},
    };

    private static Dictionary<int, EventData> eventDictionary_story = new Dictionary<int, EventData>()
    {
        { 1, Story1_0},
        { 2, Story1_1 },
        { 3, Story2_0 },
        { 4, Story2_1 }

    };

    private static Dictionary<int, EventData>[] eventDictionary = new Dictionary<int, EventData>[] { eventDictionary_story, eventDictionary_1, eventDictionary_2};

    public static EventData GetEventData(int level , int index)
    {
        if(level <0 || level > eventDictionary.Length)
        {
            return null;
        }

        if (eventDictionary[level].ContainsKey(index))
        {
            return eventDictionary[level][index];
        }
        else
        {
            return null;
        }
    }

    public static EventData GetStoryEventData(int index)
    {
        if (!eventDictionary_story.ContainsKey(index))
        {
            return null;
        }
        else
        {
            return eventDictionary_story[index];
        }
    }

    public static List<EventData> GetRandomEventDataList(int level, int count)
    {
        List<EventData> list = new List<EventData>();

        if (count <= 0 || level < 0 || level > eventDictionary.Length) return list;


        List<EventData> data = new List<EventData>();
        int iCount = 0;

        while (iCount < count)
        {
            if (data.Count < 1)
            {
                foreach (EventData bd in eventDictionary[level].Values)
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




//操作类
class Operation
{
    public Operation() { }
    public virtual void ExecuteOperation()
    { }
}

//金钱操作，可加可减
class GoldOperation : Operation
{
    int value;
    public GoldOperation(int val)
    {
        value = val;
    }

    public override void ExecuteOperation()
    {
        GameController.Instance.gameData.gold -= value;

        AudioManager.Instance.PlaySoundEffect("SE_Gold");
       
    }
}

class HealOperation : Operation
{

    int value;
    bool areaEffect;

    public HealOperation(int v, bool aoe)
    {
        value = v;
        areaEffect = aoe;
    }

    public override void ExecuteOperation()
    {



    }
}
