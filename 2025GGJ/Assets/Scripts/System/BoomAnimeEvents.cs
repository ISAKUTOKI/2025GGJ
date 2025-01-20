using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAnimeEvents : MonoBehaviour
{
    [HideInInspector]public bool IsDied = false;
    public void TryExitGame()
    {
        IsDied = true;
        Invoke("ExitGame", 3.0f);
    }

    private void ExitGame()
    {
        Debug.Log("ÍË³öÁË");
        Application.Quit();
    }
}
