using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 结算场景管理，之后做
/// </summary>
public class GameSettlementScene : SceneStateBase
{

    public Text timeText, stageText, goldText, skillPointText;

<<<<<<< Updated upstream
=======
    public void ShowGameData()
    {
        GameData gd = GameController.Instance.gameData;

        timeText.text = Utils.FormatTime(gd.time);
        stageText.text = "Level 1-1";
        goldText.text = gd.gold+"";
        skillPointText.text = gd.skillPoint+"";
    }


    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");
    }

>>>>>>> Stashed changes
    protected override void LoadPrefabs()
    {
        //throw new System.NotImplementedException();
    }

    protected override void LoadUIObjects()
    {
        ShowGameData();
    }

    protected override void RefreshUIObjects()
    {
        //throw new System.NotImplementedException();
    }
}
