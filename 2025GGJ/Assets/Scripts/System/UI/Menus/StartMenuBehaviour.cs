using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour
{
    public static StartMenuBehaviour instance;
    /// <summary>
    /// ��ʼ�˵�ϵͳ���Լ���ʼ�˵��ĵ��ϵͳ
    /// </summary>

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

    }


    // Update is called once per frame
    private void Update()
    {

    }



    public void ContinueGame()
    {


    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("1-1");
    }
    public void Option()
    {
        SceneManager.LoadScene("OptionScene");
    }
    public void ExitGame()
    {
        Debug.Log("�˳���Ϸ");
        Application.Quit(); // �˳���Ϸ
    }

}
