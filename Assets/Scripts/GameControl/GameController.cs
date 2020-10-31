using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏主进程，控制游戏的退出、场景切换等功能
/// </summary>
public class GameController : SingletonTemplate<GameController>
{

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


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
