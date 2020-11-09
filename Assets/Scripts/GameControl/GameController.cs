using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏主进程，控制游戏的退出、场景切换等功能
/// </summary>
public class GameController : SingletonTemplate<GameController>
{

    //一局游戏的全局数据
    public GameData gameData = new GameData();

<<<<<<< Updated upstream
=======
    public bool playing = false;


    #region 暂停控制
>>>>>>> Stashed changes
    public bool pause = false;

    public void Pause()
    {
        pause = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pause = false;
        Time.timeScale = 1;
    }
    #endregion

    public bool UpgradeCharacter(CharacterData cd)
    {
        if(gameData.skillPoint>= cd.UpgradeCost() && cd.level<cd.maxLevel)
        {
            gameData.skillPoint -= cd.UpgradeCost();
            cd.Upgrade();

            Debug.Log("level up!");
            return true;
        }
        return false;
    }

    public bool DismissCharacter(CharacterData cd)
    {
        if (gameData.playerTeamData.Count() <= 1)
        {
            return false;
        }
        else
        {
            gameData.playerTeamData.Dismiss(cd);

            Debug.Log("dismissed!");
            return true;
        }
    }

    private void Update()
    {
        if (playing)
        {
            if (!pause)
            {
                gameData.time += Time.deltaTime;
            }
        }
    }


    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void StartGame() {

        playing = true;

        gameData = new GameData();

    }

    public void EndGame()
    {
        playing = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
