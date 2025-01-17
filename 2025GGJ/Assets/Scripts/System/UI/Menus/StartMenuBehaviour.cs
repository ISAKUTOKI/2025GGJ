using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// ��ʼ�˵�ϵͳ���Լ���ʼ�˵��ĵ��ϵͳ
    /// </summary>

    private void Start()
    {
        if (UIBehaviour.Instance.startMenuUI == null)
            Debug.Log("û�м��ص�startMenuUI");
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
        Time.timeScale = 0f; // ��ͣ��Ϸʱ��
        UIBehaviour.Instance.pauseMenuSystem.canSwitchPauseMenu = false;
    }

    private void ExitStartMenu()
    {
        if (UIBehaviour.Instance.startMenuUI != null)
            UIBehaviour.Instance.startMenuUI.SetActive(false);
        Time.timeScale = 1f; // �ָ���Ϸʱ��
    }

    public void StartNewGame()
    {
        //Debug.Log("��ʼ����Ϸ");
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
            //Debug.Log("������Ϸ");
            ExitStartMenu();
            SaveSystemehaviour.Instance.LoadLastSave();
            UIBehaviour.Instance.pauseMenuSystem.canSwitchPauseMenu = true;
        }
    }

    public void Option()
    {
        UIBehaviour.Instance.startMenuUI.SetActive(false);
        UIBehaviour.Instance.optionMenuUI.SetActive(true);
        Debug.Log("����");
    }

    public void ExitGame()
    {
        Debug.Log("�˳���Ϸ");
        Application.Quit(); // �˳���Ϸ
    }

}
