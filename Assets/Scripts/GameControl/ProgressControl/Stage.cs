using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public EventDataBase data = null;

    public StageType type;

    public enum StageType {Event, Battle };

    public int level;

    public bool isBossStage;

    public bool isFinished = false;

    public Vector2Int pos = new Vector2Int();

    public Stage() {

        type = StageType.Event;
        data = EventData.GetEventData(1,1);
    }

    public Stage(StageType st, EventDataBase dt)
    {
        type = st;
        data = dt;

        //isBossStage = false;
    }

    public bool IsBattle()
    {
        return type == StageType.Battle;
    }

}
