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
    [HideInInspector]
    public GameData gameData = new GameData();

    //是否处于游戏状态
    [HideInInspector]
    public bool playing = false;

    public bool won = true;

    #region 暂停控制
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
        if (!playing) return false;

        if (gameData.skillPoint>= cd.UpgradeCost() && cd.level<cd.maxLevel)
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
        if (!playing) return false;

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

    public bool RecruitCharacter(CharacterData cd)
    {
        if (!playing) return false;

        if (gameData.playerTeamData.Count() > 5)
        {
            return false;
        }
        else
        {
            gameData.playerTeamData.Recruit(cd);

            Debug.Log("recruit!");
            return true;
        }
    }

    public void GainGold(int delta)
    {
        if (!playing) return;

        gameData.gold += delta;
        if (gameData.gold < 0) gameData.gold = 0;
    }

    public void GainSkillPoint(int delta)
    {
        if (!playing) return;

        gameData.skillPoint += delta;
    }

    public void StartStage(Stage s)
    {
        gameData.progress.playerPos = s.pos;

        if (s.IsBattle())
        {
            StartBattle((BattleData)s.data);
        }
        else
        {
            StartEvent((EventData)s.data);
        }
        
    }

    public void StartEvent(EventDataBase dt)
    {
        gameData.progress.nextEventData = dt;

        LoadScene("GameEvent");
        AudioManager.Instance.ChangeBGM("BGM_Tense");
        //AudioManager.Instance.PlaySoundEffect("SE_Beep1");
    }

    public void StartBattle(BattleData bd)
    {
        gameData.progress.nextEventData = bd;
        Debug.Log("start battle! " + bd);

        LoadScene("GameBattle");
        AudioManager.Instance.ChangeBGM("BGM_Kill");
    }

    public void FinishStage()
    {
        if (playing)
        {
            Debug.Log("Finish stage");

            //是否完成一个大关
            if (gameData.progress.FinishStage())
            {
                //完成所有大关：游戏胜利
                if (gameData.progress.level == gameData.progress.totalLevels)
                {
                    GameWin();
                    
                }
                //否则：开始新的大关
                else
                {
                    gameData.progress.StartLevel();
                    StartStage(gameData.progress.GetCurrentStage());
                    //LoadScene("GameMap");
                }
            }
            else
            {
                AudioManager.Instance.ChangeBGM("BGM_IntroEdit");
                LoadScene("GameMap");
            }
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

        //gameData = new GameData();

        gameData.progress.StartLevel();

        StartStage(gameData.progress.GetCurrentStage());

    }

    public void GameLose()
    {
        won = false;
        EndGame();
        LoadScene("GameSettlement");
        AudioManager.Instance.ChangeBGM("BGM_BlueRainInKyoto");
    }

    public void GameWin()
    {
        //Debug.Log("Game Win!");
        won = true;
        EndGame();
        LoadScene("GameSettlement");
        AudioManager.Instance.ChangeBGM("BGM_BlueRainInKyoto");
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
