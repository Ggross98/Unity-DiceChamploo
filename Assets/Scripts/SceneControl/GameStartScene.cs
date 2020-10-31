using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override void LoadUIObjects()
    {
        throw new System.NotImplementedException();
    }

    public override void RefreshUIObjects()
    {
        throw new System.NotImplementedException();
    }

    public override void LoadPrefabs()
    {
        throw new System.NotImplementedException();
    }
}
