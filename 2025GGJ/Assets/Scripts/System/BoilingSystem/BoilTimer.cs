using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilTimer : MonoBehaviour
{
    // 烧煮计时器的变量
    private Image boilTimer;
    private float boilTimerDuration; // 烧煮计时，秒数
    [SerializeField] private float boilTimerTotalTime; // 几倍，用于把烧煮计时同步到0~1
    bool justRunningBoilTimer_1; // 切换计时器用的


    void Start()
    {
        ResetBoilTimerSystem();
    }

    // Update is called once per frame
    void Update()
    {
        RunBoilTimer(); // 运行烧煮计时器
    }

    /// <summary>
    /// 以下为烧煮计时器的系统
    /// </summary>
    private void RunBoilTimer()
    {
        boilTimerDuration -= Time.deltaTime;
        if (boilTimerDuration <= 0)
        {
            BoilingSystemBehaviour.Instance.BoilingTimer.boilingTimerCellCount -= 1;
            boilTimerDuration = boilTimerTotalTime;
            SwitchBoilTimer();
        }
        ChangeBoilTimerImage();
    }

    private void SwitchBoilTimer()
    {
        if (justRunningBoilTimer_1)
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_2;
            justRunningBoilTimer_1 = false;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(true); // 将1底激活
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(false); // 将2底关闭
        } // 正在用1的话就切换到2
        else
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1;
            justRunningBoilTimer_1 = true;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(false); // 将1底关闭
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(true); // 将2底激活
        } // 正在用2的话就切换到1
    } // 在倒计时结束的时候进行计时器切换

    private void ChangeBoilTimerImage()
    {
        boilTimer.fillAmount = boilTimerDuration / boilTimerTotalTime;
    }

    private void ResetBoilTimerSystem()
    {
        if (boilTimerTotalTime == 0)
            boilTimerTotalTime = 3; // 确保烧煮计时器至少有一个默认的3秒而不是0
        boilTimerDuration = boilTimerTotalTime; // 确定烧煮计时器的大小，相除可化值为0~1
        boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1; // 设置默认的烧煮计时器
        justRunningBoilTimer_1 = true; // 默认使用烧煮计时器1
    } // 重启烧煮计时器系统

    private void BoilTimerChecker()
    {
        if (boilTimer == null)
            Debug.Log("没赋上值");
        else
            Debug.Log(boilTimer.name);
    } // 当烧煮计时器没赋上值时报错//否则就报告名字
}
