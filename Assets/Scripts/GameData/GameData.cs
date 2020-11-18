using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 储存一局游戏中的全局参数，如难度、金钱、游戏时间等
/// </summary>
public class GameData
{

    public int difficulty;

    public int gold;

    public float time; //in seconds

    public int skillPoint = 99;

    public GameProgress progress;

    public TeamData playerTeamData;

    public GameData()
    {
        difficulty = 1;
        gold = 0;
        time = 0;
        skillPoint = 0;
        progress = new GameProgress();
        playerTeamData = new TeamData();
    }

}
