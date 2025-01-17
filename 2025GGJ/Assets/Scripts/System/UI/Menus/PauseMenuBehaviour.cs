using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// ��ͣ�˵�ϵͳ���Լ���ͣ�˵��ĵ��ϵͳ
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
        UIBehaviour.Instance.pauseMenuUI.SetActive(true); // ��ʾ��ͣ�˵�
        Time.timeScale = 0f; // ��ͣ��Ϸʱ��
        isPaused = true;
        Debug.Log("��ͣ");
    }

    public void BackToGame()
    {
        UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // �ָ���Ϸʱ��
        isPaused = false;
        Debug.Log("����");
        canSwitchPauseMenu = true;
    }

    public void Option()
    {
        UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        UIBehaviour.Instance.optionMenuUI.SetActive(true);
        Debug.Log("����");
    }

    public void BackToMenu()
    {
        UIBehaviour.Instance.pauseMenuUI.SetActive(false);
        UIBehaviour.Instance.startMenuSystem.ToStartMenu();
        Debug.Log("�ص��˵�");
        isPaused = false;
        canSwitchPauseMenu = false;
    }

    public void ExitGame()
    {
        Debug.Log("�˳���Ϸ");
        Application.Quit(); // �˳���Ϸ
    }
}
