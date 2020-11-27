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
    CharacterInfo firstCharacterInfo, secondCharacterInfo;

    CharacterData firstCharacter, secondCharacter;

    CharacterData[] teammates;
    int firstTeamIndex, secondTeamIndex;


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
        playerTeam.Recruit(firstCharacter);
        playerTeam.Recruit(secondCharacter);
       

        //开始游戏
        GameController.Instance.StartGame();
        
        //GameController.Instance.LoadScene("GameMap");
    }

    public void ChangeTeammate(bool first)
    {
        if (first)
        {
            do {

                firstTeamIndex++;
                if (firstTeamIndex >= teammates.Length) firstTeamIndex = 0;


            } while (firstTeamIndex == secondTeamIndex);

            

            firstCharacter = teammates[firstTeamIndex];

        }
        else
        {
            do {

                secondTeamIndex++;
                if (secondTeamIndex >= teammates.Length) secondTeamIndex = 0;


            } while (firstTeamIndex == secondTeamIndex);

            
            secondCharacter = teammates[secondTeamIndex];

        }



        RefreshUIObjects();
    }

    protected override void LoadUIObjects()
    {
        //1、生成两个角色的数据，并显示在信息栏中
        //firstCharacter = CharacterData.GetCharacterData(1);

        teammates = new CharacterData[] {
            CharacterData.GetCharacterData(1),
            CharacterData.GetCharacterData(2),
            CharacterData.GetCharacterData(3),
            CharacterData.GetCharacterData(4),
            CharacterData.GetCharacterData(5),
        };

        firstTeamIndex = 0;
        firstCharacter = teammates[0];
        secondTeamIndex = 1;
        secondCharacter = teammates[1];

        RefreshUIObjects();
    }

    protected override void RefreshUIObjects()
    {
        firstCharacterInfo.ShowCharacter(firstCharacter);
        secondCharacterInfo.ShowCharacter(secondCharacter);
    }

    protected override void LoadPrefabs()
    {
        //throw new System.NotImplementedException();
    }
}
