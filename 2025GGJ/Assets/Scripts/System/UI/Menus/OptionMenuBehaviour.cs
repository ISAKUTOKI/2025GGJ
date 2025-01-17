using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// ���ò˵�ϵͳ���Լ���ͣ�˵��ĵ��ϵͳ
    /// </summary>

    [HideInInspector]public int lastMenu;
    //0=��
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
            Debug.Log("û�л��ֵ"); 
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
