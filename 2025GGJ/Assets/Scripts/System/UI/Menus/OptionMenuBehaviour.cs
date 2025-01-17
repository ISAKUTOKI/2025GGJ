using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// 设置菜单系统，以及暂停菜单的点击系统
    /// </summary>

    [HideInInspector]public int lastMenu;
    //0=空
    //1=start
    //2=pause
    void Start()
    {
        lastMenu = 0;
    }

    void Update()
    {

    }

    public void VolumeDown()
    {
        VolumeSystemBehaviour.instance.DecreaseVolume();
    }
    public void VolumeUp()
    {
        VolumeSystemBehaviour.instance.IncreaseVolume();
    }
    public void LoadLastSave()
    {
        SaveSystemehaviour.Instance.LoadLastSave();
    }

    public void BackToLastMenu()
    {
            
        if (lastMenu == 0)
        {
            return;
        }//mull
        else if (lastMenu==1)
        {
            BackToStartMenu();
        }//start
        else if(lastMenu==2)
        {
            BackToPauseMenu();
        }//pause
        else
        {
            Debug.Log("没有获得值"); 
        }
    }

    public void BackToStartMenu()
    {
        UIBehaviour.Instance.optionMenuUI.SetActive(false);
        UIBehaviour.Instance.startMenuUI.SetActive(true);
        lastMenu = 0;
    }

    public void BackToPauseMenu()
    {
        UIBehaviour.Instance.optionMenuUI.SetActive(false);
        UIBehaviour.Instance.pauseMenuUI.SetActive(true);
        lastMenu = 0;
    }
}
