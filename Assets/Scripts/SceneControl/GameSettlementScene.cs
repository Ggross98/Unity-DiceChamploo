using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 结算场景管理，之后做
/// </summary>
public class GameSettlementScene : SceneStateBase<GameSettlementScene>
{

    public Text timeText, stageText, goldText, skillPointText;

    public Text ending, endingInfo;

    public GameObject endingPanel, dataPanel;
    bool isShowingEnding = true;

    internal void ShowGameData()
    {
        GameData gd = GameController.Instance.gameData;

        timeText.text = Utils.FormatTime(gd.time);
        stageText.text = gd.progress.finishedStages+"";
        goldText.text = gd.gold+"";
        skillPointText.text = gd.skillPoint+"";
    }

    internal void ShowEnding()
    {
        bool won = GameController.Instance.won;

        if (won)
        {
            ending.text = "游戏胜利";
            endingInfo.text = "你和你的伙伴运用力量和智慧，团结合作，在这座城市中生存了下来。但更为严酷的考验还在等候你们……";
        }
        else
        {
            endingInfo.text = "游戏失败";
            endingInfo.text = "你的伙伴一个接一个倒下了，最后你也没能坚持下去。在下一次挑战中相信你会做的更好。";
        }
    }

    public void Switch()
    {
        isShowingEnding = !isShowingEnding;

        ShowPanel(isShowingEnding);
    }

    internal void ShowPanel(bool ending)
    {
        endingPanel.SetActive(ending);
        dataPanel.SetActive(!ending);
    }


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
        ShowGameData();
        ShowEnding();
    }

    protected override void RefreshUIObjects()
    {
        //throw new System.NotImplementedException();
    }
}
