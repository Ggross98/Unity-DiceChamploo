using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScene : SceneStateBase
{
    public override void LoadPrefabs()
    {
        throw new System.NotImplementedException();
    }

    public override void LoadUIObjects()
    {
        throw new System.NotImplementedException();
    }

    public void Quit()
    {
        GameController.Instance.QuitGame();
    }

    public override void RefreshUIObjects()
    {
        throw new System.NotImplementedException();
    }

    public void StartGame()
    {
        GameController.Instance.LoadScene("GameStart");
    }

    
}
