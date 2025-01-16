using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// ��ͣ�˵�ϵͳ���Լ���ͣ�˵��ĵ��ϵͳ
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
        pauseMenuUI.SetActive(true); // ��ʾ��ͣ�˵�
        Time.timeScale = 0f; // ��ͣ��Ϸʱ��
        isPaused = true;
        Debug.Log("��ͣ");
    }

    public void BackToGame()
    {
        pauseMenuUI.SetActive(false); // ������ͣ�˵�
        Time.timeScale = 1f; // �ָ���Ϸʱ��
        isPaused = false;
        Debug.Log("����");
    }

    public void Option()
    {
        Debug.Log("����");
    }

    public void BackToMenu()
    {
        Debug.Log("�ص��˵�");
    }

    public void ExitGame()
    {
        Debug.Log("�˳���Ϸ");
        Application.Quit(); // �˳���Ϸ
    }
}
