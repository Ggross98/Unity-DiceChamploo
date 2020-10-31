using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettlementScene : SceneStateBase
{

    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

    public override void LoadPrefabs()
    {
        throw new System.NotImplementedException();
    }

    public override void LoadUIObjects()
    {
        throw new System.NotImplementedException();
    }

    public override void RefreshUIObjects()
    {
        throw new System.NotImplementedException();
    }
}
