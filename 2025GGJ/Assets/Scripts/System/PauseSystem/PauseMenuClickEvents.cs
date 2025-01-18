using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuClickEvent : MonoBehaviour
{

    public void Continue()
    {
        PauseSystemBehaviour.Instance.BackToGame();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ReStart()
    {
        PauseSystemBehaviour.Instance.ReloadGame();
    }
}
