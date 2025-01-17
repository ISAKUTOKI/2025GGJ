using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// 开始菜单系统，以及开始菜单的点击系统
    /// </summary>

    private void Start()
    {
        if (UIBehaviour.Instance.startMenuUI == null)
            Debug.Log("没有加载到startMenuUI");
        else
            ToStartMenu();
    }


    // Update is called once per frame
    private void Update()
    {

    }

    [HideInInspector]
    public void ToStartMenu()
    {
        if (UIBehaviour.Instance.startMenuUI != null)
            UIBehaviour.Instance.startMenuUI.SetActive(true);
        Time.timeScale = 0f; // 暂停游戏时间
        UIBehaviour.Instance.pauseMenuSystem.canSwitchPauseMenu = false;
    }

    private void ExitStartMenu()
    {
        if (UIBehaviour.Instance.startMenuUI != null)
            UIBehaviour.Instance.startMenuUI.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏时间
    }

    public void StartNewGame()
    {
        //Debug.Log("开始新游戏");
        SaveSystemehaviour.Instance.NewGame();
        ExitStartMenu();
        UIBehaviour.Instance.pauseMenuSystem.canSwitchPauseMenu = true;
    }

    public void ContinueGame()
    {
        if (SaveSystemehaviour.Instance.savePoints.Count == 0)
        {
            StartNewGame();
        }
        else
        {
            //Debug.Log("继续游戏");
            ExitStartMenu();
            SaveSystemehaviour.Instance.LoadLastSave();
            UIBehaviour.Instance.pauseMenuSystem.canSwitchPauseMenu = true;
        }
    }

    public void Option()
    {
        UIBehaviour.Instance.startMenuUI.SetActive(false);
        UIBehaviour.Instance.optionMenuUI.SetActive(true);
        Debug.Log("设置");
    }

    public void ExitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit(); // 退出游戏
    }

}
