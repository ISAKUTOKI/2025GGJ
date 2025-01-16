using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// 暂停菜单系统，以及暂停菜单的点击系统
    /// </summary>

    private bool isPaused;
    [SerializeField] GameObject pauseMenuUI;
    void Start()
    {
        if (pauseMenuUI != null) 
            pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    private void PauseMenu()
    {
        if (!isPaused)
        {
            ToPauseMenu();
        }
        else
        {
            BackToGame();
        }
    }

    private void ToPauseMenu()
    {
        pauseMenuUI.SetActive(true); // 显示暂停菜单
        Time.timeScale = 0f; // 暂停游戏时间
        isPaused = true;
        Debug.Log("暂停");
    }

    public void BackToGame()
    {
        pauseMenuUI.SetActive(false); // 隐藏暂停菜单
        Time.timeScale = 1f; // 恢复游戏时间
        isPaused = false;
        Debug.Log("继续");
    }

    public void Option()
    {
        Debug.Log("设置");
    }

    public void BackToMenu()
    {
        Debug.Log("回到菜单");
    }

    public void ExitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit(); // 退出游戏
    }
}
