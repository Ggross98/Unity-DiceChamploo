using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress
{
    //第几大关
    public int level;

    public int totalLevels = 2;

    public int finishedStages = 0;

    public Stage[,] stages;

    public int width, height, count;

    public Vector2Int playerPos;

    public EventDataBase nextEventData;
    

    public GameProgress()
    {
        level = 0;
        //StartLevel();
        //CreateStages(6, 3, 1);
    }

    private void SetStage(Stage s, int x, int y)
    {
        if(stages!= null && s != null)
        {
            stages[x, y] = s;

            s.pos = new Vector2Int(x, y);
        }
    }

    /// <summary>
    /// 结束关卡后结算进度
    /// </summary>
    /// <returns>是否结束了一整个大关</returns>
    public bool FinishStage()
    {
        Stage cStage = stages[playerPos.x, playerPos.y];

        cStage.isFinished = true;
        nextEventData = null;

        finishedStages++;

        if (cStage.isBossStage)
        {
            return true;
        }
        return false;
    }

    public void StartLevel()
    {

        level++;

        CreateStages(6, 4, 7, 8);
    }

    public Stage GetCurrentStage()
    {
        return stages[playerPos.x, playerPos.y];
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns><param name="type">0：事件；1：战斗；2：Boss战</param>
    /// <param name="accessable">0：锁定；1：可到达；2：已完成</param></returns>
    public int[] GetStageStatus(Stage s)
    {
        int[] result = new int[2];

        if (s.isBossStage) result[0] = 2;
        else if (s.IsBattle()) result[0] = 1;
        else result[0] = 0;

        
        if (s.isFinished) result[1] = 2;
        else
        {
            int x = s.pos.x;
            int y = s.pos.y;
            bool access = false;

            if (x > 0)
            {
                if (stages[x - 1, y] != null && stages[x - 1, y].isFinished) access = true;
            }

            if (x < width - 1)
            {
                if (stages[x + 1, y] != null && stages[x + 1, y].isFinished) access = true;
            }

            if (y > 0)
            {
                if (stages[x, y - 1] != null && stages[x, y - 1].isFinished) access = true;
            }

            if (y < height - 1)
            {
                if (stages[x, y + 1] != null && stages[x, y + 1].isFinished) access = true;
            }

            if (access)
            {
                result[1] = 1;
            }
            else
            {
                result[1] = 0;
            }
        }

        return result;
    }

    
    public void CreateStages(int w, int h, int eventCount, int battleCount)
    {

        if(w < 2 || h < 1)
        {
            Debug.Log("Stages creation error!");
        }
        else
        {
            width = w;
            height = h;

            //暂时
            if(level ==2)
            {
                width = 3;
                height = 1;
            }

            count = eventCount + battleCount;
        }

        stages = new Stage[width, height];
        for(int i = 0; i < stages.GetLength(0); i++)
        {
            for(int j = 0; j < stages.GetLength(1); j++)
            {
                stages[i,j] = null;
            }
            
        }

        //随机初始位置
        int startY = Random.Range(0, height);

        Stage startStage = new Stage();

        switch (level)
        {
            case 1:
                startStage = new Stage(Stage.StageType.Event, EventData.GetStoryEventData(1));
                break;
            case 2:
                startStage = new Stage(Stage.StageType.Event, EventData.GetStoryEventData(3));
                break;
        }
        //startStage.isFinished = true;

        SetStage(startStage, 0, startY);

        playerPos = new Vector2Int(0, startY);

        eventCount--;

        //随机boss位置
        int endY = Random.Range(0, height);

        Stage bossStage = new Stage();
        switch (level)
        {
            case 1:
                bossStage = new Stage(Stage.StageType.Event, EventData.GetStoryEventData(2));
                break;
            case 2:
                bossStage = new Stage(Stage.StageType.Event, EventData.GetStoryEventData(4));
                break;
        }


        bossStage.isBossStage = true;
        SetStage(bossStage, width - 1, endY);

        battleCount--;

        int total = 0;

        //随机生成所有战斗、事件
        List<EventData> events = EventData.GetRandomEventDataList(level, eventCount);
        List<BattleData> battles = BattleData.GetRandomBattleDataList(level, battleCount);

        //生成一条从初始位置到结束位置的路径
        int turn = Random.Range(0,width);

        for(int i = 1; i <= turn; i++)
        {
            Stage stage = CreateStage(events, battles);

            SetStage(stage, i, startY);
            total++;
        }

        for(int i = turn; i < width-1; i++)
        {
            if (stages[i, endY] != null) continue;

            Stage stage = CreateStage(events, battles);

            SetStage(stage, i, endY);
            total++;
        }

        if(startY != endY)
        {
            for (int j = Mathf.Min(startY, endY) + 1; j < Mathf.Max(startY, endY); j++)
            {
                Stage stage = CreateStage(events, battles);

                SetStage(stage, turn, j);
                total++;
            }
        }
        

        //在其他位置补充
    }

    private static Stage CreateStage(List<EventData> e, List<BattleData> b)
    {
        if (e.Count == 0 && b.Count == 0) return new Stage();

        Stage.StageType type;
        if (e.Count == 0) type = Stage.StageType.Battle;
        else if (b.Count == 0) type = Stage.StageType.Event;
        else
        {
            int t = Random.Range(0, e.Count + b.Count);
            type = (t < e.Count) ? Stage.StageType.Event : Stage.StageType.Battle;

        }

        int index1 = Random.Range(0, e.Count);
        int index2 = Random.Range(0, b.Count);

        switch (type)
        {
            case Stage.StageType.Battle:
                BattleData bd = b[0];
                b.Remove(bd);

                return new Stage(type, bd);

            case Stage.StageType.Event:
                EventData ed = e[0];
                e.Remove(ed);

                return new Stage(type, ed);
        }

        return new Stage();



    }

}
