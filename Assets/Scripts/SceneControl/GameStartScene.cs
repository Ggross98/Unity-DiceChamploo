using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 难度选择场景
/// 功能包括：选择难度；选择主角；选择初始队友
/// </summary>
public class GameStartScene : SceneStateBase
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
        GameController.Instance.StartGame();

        TeamData playerTeam = new TeamData();
        playerTeam.Recruit(mainCharacter);
        playerTeam.Recruit(secondCharacter);

        GameController.Instance.gameData.playerTeamData = playerTeam;

        //开始游戏

        
        GameController.Instance.LoadScene("GameMap");
    }

<<<<<<< Updated upstream
=======
    public void ChangeTeammate()
    {
        teamIndex++;
        if (teamIndex >= teammates.Length) teamIndex = 0;

        secondCharacter = teammates[teamIndex];

        RefreshUIObjects();
    }

>>>>>>> Stashed changes
    protected override void LoadUIObjects()
    {
        //1、生成两个角色的数据，并显示在信息栏中
        mainCharacter = CharacterData.MainCharacter_1.Model();

        teammates = new CharacterData[] {
            CharacterData.MainCharacter_2.Model(),
            CharacterData.MainCharacter_3.Model(),
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
