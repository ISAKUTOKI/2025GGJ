using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour
{
    public static StartMenuBehaviour instance;
    /// <summary>
    /// 开始菜单系统，以及开始菜单的点击系统
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
        Debug.Log("退出游戏");
        Application.Quit(); // 退出游戏
    }

}
