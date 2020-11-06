using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 结算场景管理，之后做
/// </summary>
public class GameSettlementScene : SceneStateBase
{

    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

    protected override void LoadPrefabs()
    {
        //throw new System.NotImplementedException();
    }

    protected override void LoadUIObjects()
    {
        //throw new System.NotImplementedException();
    }

    protected override void RefreshUIObjects()
    {
        //throw new System.NotImplementedException();
    }
}
