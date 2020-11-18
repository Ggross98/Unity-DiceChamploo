using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 难度选择场景
/// 功能包括：选择难度；选择主角；选择初始队友
/// </summary>
public class GameStartScene : SceneStateBase<GameStartScene>
{

    #region ui组件

    [SerializeField]
    CharacterInfo mainCharacterInfo, secondCharacterInfo;

    CharacterData mainCharacter, secondCharacter;

    CharacterData[] teammates;
    int teamIndex;


    #endregion



    public void BackToMenu()
    {
        GameController.Instance.LoadScene("MainMenu");

    }

    public void StartGame()
    {

        //创建队伍信息，并保存在GameData中
        //GameController.Instance.StartGame();

        GameController.Instance.gameData = new GameData();


        //生成队伍
        TeamData playerTeam = GameController.Instance.gameData.playerTeamData;
        playerTeam.Recruit(mainCharacter);
        playerTeam.Recruit(secondCharacter);
       

        //开始游戏
        GameController.Instance.StartGame();
        
        //GameController.Instance.LoadScene("GameMap");
    }

    public void ChangeTeammate()
    {
        teamIndex++;
        if (teamIndex >= teammates.Length) teamIndex = 0;

        secondCharacter = teammates[teamIndex];

        RefreshUIObjects();
    }

    protected override void LoadUIObjects()
    {
        //1、生成两个角色的数据，并显示在信息栏中
        mainCharacter = CharacterData.GetCharacterData(1);

        teammates = new CharacterData[] {
            CharacterData.GetCharacterData(2),
            CharacterData.GetCharacterData(3),
        };

        teamIndex = 0;
        secondCharacter = teammates[0];

        RefreshUIObjects();
    }

    protected override void RefreshUIObjects()
    {
        mainCharacterInfo.ShowCharacter(mainCharacter);
        secondCharacterInfo.ShowCharacter(secondCharacter);
    }

    protected override void LoadPrefabs()
    {
        //throw new System.NotImplementedException();
    }
}
