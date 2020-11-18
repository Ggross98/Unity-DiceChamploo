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
    private static EventData Event0 = new EventData(
        "遭遇劫匪",
        new List<Movement>(){
            Movement.m0_0,
            Movement.m0_1,
            Movement.m0_2,
            Movement.m0_3,

        });

    private static EventData Event1 = new EventData(
        "遭遇黑帮Ⅰ",
        new List<Movement> {
            Movement.m1_0,
            Movement.m1_1,
            Movement.m1_2,
            Movement.m1_3,
            Movement.m1_4
        });

    private static EventData Event2 = new EventData(
        "遭遇黑帮 Ⅱ",
        new List<Movement>
        {
            Movement.m2_0,
            Movement.m2_1,
            Movement.m2_2
        });

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
            Movement.m_e_4_0
        }
    );




    private static Dictionary<int, EventData> eventDictionary_1 = new Dictionary<int, EventData>() {

        { 1, Event1 },

        { 2, Event2 },




    };

    private static Dictionary<int, EventData> eventDictionary_story = new Dictionary<int, EventData>()
    {
        { 1, Story1_0},
        { 2, Story1_1 },
        { 3, Story2_0 },
        { 4, Story2_1 }

    };

    private static Dictionary<int, EventData>[] eventDictionary = new Dictionary<int, EventData>[] { null, eventDictionary_1, eventDictionary_1};

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
    }
}
