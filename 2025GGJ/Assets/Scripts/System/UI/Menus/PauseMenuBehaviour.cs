using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// 暂停菜单系统，以及暂停菜单的点击系统
    /// </summary>

    [HideInInspector] public bool canSwitchPauseMenu = true;
    private bool isPaused;

    void Start()
    {
        if (UIBehaviour.Instance.pauseMenuUI != null)
            UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        isPaused = false;
        canSwitchPauseMenu = false;
    }

    void Update()
    {
        if (canSwitchPauseMenu)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                PauseMenuSwitch();
            }
        }
    }

    private void PauseMenuSwitch()
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
        UIBehaviour.Instance.pauseMenuUI.SetActive(true); // 显示暂停菜单
        Time.timeScale = 0f; // 暂停游戏时间
        isPaused = true;
        Debug.Log("暂停");
    }

    public void BackToGame()
    {
        UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏时间
        isPaused = false;
        Debug.Log("继续");
        canSwitchPauseMenu = true;
    }

    public void Option()
    {
        UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        UIBehaviour.Instance.optionMenuUI.SetActive(true);
        Debug.Log("设置");
    }

    public void BackToMenu()
    {
        UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        UIBehaviour.Instance.startMenuSystem.ToStartMenu();
        Debug.Log("回到菜单");
        isPaused = false;
        canSwitchPauseMenu = false;
    }

    public void ExitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit(); // 退出游戏
    }
}
