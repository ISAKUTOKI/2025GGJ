using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilTimer : MonoBehaviour
{
    // 烧煮计时器的变量
    private Image boilTimer;
    private float boilTimerDuration; // 烧煮计时，秒数
    [SerializeField] private float boilTimerTotalTime = 3f; // 总时间，默认3秒
    private bool justRunningBoilTimer_1 = true; // 切换计时器用的

    void Start()
    {
        ResetBoilTimerSystem();
    }

    void Update()
    {
        RunBoilTimer(); // 运行烧煮计时器
    }

    /// <summary>
    /// 运行烧煮计时器
    /// </summary>
    private void RunBoilTimer()
    {
        boilTimerDuration -= Time.deltaTime;
        if (boilTimerDuration <= 0)
        {
            // 替换为 boilBarBehaviour 的接口
            BoilingSystemBehaviour.Instance.boilBarBehaviour.CurrentFullBarDropBy(1); // 每次减少1个单位
            boilTimerDuration = boilTimerTotalTime;
            SwitchBoilTimer();
        }
        ChangeBoilTimerImage();
    }

    /// <summary>
    /// 切换计时器
    /// </summary>
    private void SwitchBoilTimer()
    {
        if (justRunningBoilTimer_1)
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_2;
            justRunningBoilTimer_1 = false;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(true); // 激活1底
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(false); // 关闭2底
        }
        else
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1;
            justRunningBoilTimer_1 = true;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(false); // 关闭1底
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(true); // 激活2底
        }
    }

    /// <summary>
    /// 更新计时器图像
    /// </summary>
    private void ChangeBoilTimerImage()
    {
        if (boilTimer != null)
        {
            boilTimer.fillAmount = boilTimerDuration / boilTimerTotalTime;
        }
    }

    /// <summary>
    /// 重置烧煮计时器系统
    /// </summary>
    private void ResetBoilTimerSystem()
    {
        if (boilTimerTotalTime <= 0)
            boilTimerTotalTime = 3f; // 确保烧煮计时器至少有一个默认的3秒

        boilTimerDuration = boilTimerTotalTime;
        boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1; // 设置默认计时器
        justRunningBoilTimer_1 = true; // 默认使用计时器1
    }

    /// <summary>
    /// 检查计时器是否赋值
    /// </summary>
    private void BoilTimerChecker()
    {
        if (boilTimer == null)
        {
            Debug.LogError("烧煮计时器未赋值！");
        }
        else
        {
            Debug.Log($"当前计时器：{boilTimer.name}");
        }
    }
}