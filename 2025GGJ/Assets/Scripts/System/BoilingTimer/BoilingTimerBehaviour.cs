using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilingTimerBehaviour : MonoBehaviour
{
    /// <summary>
    /// ���ڵ���ʱ�����󵹼�ʱ��ϵͳ
    /// </summary>

    //���󵹼�ʱ�ı���
    [SerializeField] Image boilTimer_1;
    [SerializeField] Image boilTimer_2;
    public float boilTimer;
    public float boilDuration;
    bool isRunningTimer_1;

    //���ڵ���ʱ�ı���
    [SerializeField] Image boilingTimerFullBar;
    public int boilingTimerCellCount;
    // Start is called before the first frame update
    void Start()
    {
        boilTimer = 0;
        isRunningTimer_1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        RunBoilTimer();
    }

    private void RunBoilTimer ()
    {
        boilTimer += Time.deltaTime;
        SwitchBoilTimer();
        if (boilTimer > boilDuration)
        {
            boilingTimerCellCount--;
        }
    }

    private void SwitchBoilTimer()
    {
        if (isRunningTimer_1)
            isRunningTimer_1 = false;
        else
            isRunningTimer_1 = true;
    }

    private void ChangeBoilTimerImage()
    {

    }
}
