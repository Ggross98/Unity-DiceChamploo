using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 难度选择场景，有空再做
/// 功能包括：选择难度；选择主角；随机生成初始队友
/// </summary>
public class GameStartScene : SceneStateBase
{

    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        GameController.Instance.LoadScene("GameMap");
    }

    protected override void LoadUIObjects()
    {
        //throw new System.NotImplementedException();
    }

    protected override void RefreshUIObjects()
    {
        //throw new System.NotImplementedException();
    }

    protected override void LoadPrefabs()
    {
        //throw new System.NotImplementedException();
    }
}
