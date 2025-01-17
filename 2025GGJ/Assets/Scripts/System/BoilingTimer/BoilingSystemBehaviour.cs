using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingSystemBehaviour : MonoBehaviour
{
    /// <summary>
    /// 烧煮计时器和沸腾计时器的系统
    /// </summary>

    //烧煮计时器的变量
    [SerializeField] Image boilTimer_1;
    [SerializeField] Image boilTimer_2;
    [SerializeField] GameObject boilTimer_1Bottom;
    [SerializeField] GameObject boilTimer_2Bottom;
    [HideInInspector] Image boilTimer;
    private float boilTimerDuration;//烧煮计时，秒数
    [SerializeField] private float boilTimerTotalTime;//几倍，用于把烧煮计时同步到0~1
    bool justRunningBoilTimer_1;//切换计时器用的

    //沸腾计时器的变量
    [SerializeField] Image boilingTimerFullBar;
    [SerializeField] private int boilingTimerCellCount;//沸腾计时器的总格数
    float boilingTimerTotalCellCount;//几倍，用于把沸腾计时同步到0~1

    //沸腾计时器——打点用变量
    int lastCount;
    List<int> CountToMakePlayerMoveUp = new();

    public void AddIntToList(params int[] numbers)
    {
        foreach (int cellCount in numbers)
        {
            CountToMakePlayerMoveUp.Add(cellCount);
        }
    }//添加顺序为从小到大，添加方式为AddIntToList(a,b,c,d,f,..);

    void Start()
    {
        AddIntToList(1, 2, 4, 6, 9, 12, 16);//设置打点的位置（格数）
        ResetBoilTimerSystem();
        ResetBoilingTimerSystem();
    }

    void Update()
    {
        RunBoilTimer();//运行烧煮计时器
        RunBoilingTimer();//运行沸腾计时器
    }


    /// <summary>
    /// 以下为烧煮计时器的系统
    /// 包括了
    /// 启用烧煮计时器-->减少倒计时，当倒计时清零的时候，沸腾倒计时的格数-1，重置烧煮倒计时，切换当前的烧煮倒计时（用于切换图像），最后实时改变烧煮倒计时的图像
    /// 切换烧煮计时器-->如果当前是计时器1,就切换到2，反之切换到1-->[默认是计时器1]
    /// 实时改变烧煮计时器的图像
    /// </summary>
    private void RunBoilTimer()
    {
        boilTimerDuration -= Time.deltaTime;
        //Debug.Log(boilTimerDuration);
        if (boilTimerDuration <= 0)
        {
            boilingTimerCellCount -= 1;
            boilTimerDuration = boilTimerTotalTime;
            SwitchBoilTimer();
        }
        ChangeBoilTimerImage();
    }
    private void SwitchBoilTimer()
    {
        if (justRunningBoilTimer_1)
        {
            boilTimer = boilTimer_2;
            justRunningBoilTimer_1 = false;
            boilTimer_1Bottom.SetActive(true);//将1底激活
            boilTimer_2Bottom.SetActive(false);//将2底关闭
        }//正在用1的话就切换到2
        else
        {
            boilTimer = boilTimer_1;
            justRunningBoilTimer_1 = true;
            boilTimer_1Bottom.SetActive(false);//将1底关闭
            boilTimer_2Bottom.SetActive(true);//将2底激活
        }//正在用2的话就切换到1
    }//在倒计时结束的时候进行计时器切换
    private void ChangeBoilTimerImage()
    {
        boilTimer.fillAmount = boilTimerDuration / boilTimerTotalTime;
    }
    private void ResetBoilTimerSystem()
    {
        if (boilTimerTotalTime == 0)
            boilTimerTotalTime = 3;//确保烧煮计时器至少有一个默认的3秒而不是0
        boilTimerDuration = boilTimerTotalTime;//确定烧煮计时器的大小，相除可化值为0~1
        boilTimer = boilTimer_1;//设置默认的烧煮计时器
        justRunningBoilTimer_1 = true;//默认使用烧煮计时器1
        //BoilTimerChecker();//检查计时器的合法性
    }//重启烧煮计时器系统
    private void BoilTimerChecker()
    {
        if (boilTimer == null)
            Debug.Log("没赋上值");
        else
            Debug.Log(boilTimer.name);
    }//当烧煮计时器没赋上值时报错//否则就报告名字



    /// <summary>
    ///以下为沸腾计时器的系统
    /// </summary>
    private void RunBoilingTimer()
    {
        ChangeBoilingTimerImage();
        if (boilingTimerCellCount <= 0)
            PlayerBehaviour.Instance.health.Die();
    }
    private void ChangeBoilingTimerImage()
    {
        boilingTimerFullBar.fillAmount = boilingTimerCellCount / boilingTimerTotalCellCount;
        //Debug.Log(boilingTimerCellCount);
        //Debug.Log(boilingTimerCellCount / boilingTimerTotalCellCount);
        if (boilingTimerCellCount <= lastCount)
        {
            SetLastCount();
            MakePlayerMoveUp(1, Vector3.up);
        }
    }
    private void ResetBoilingTimerSystem()
    {
        lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; //打点数初始化
        Debug.Log(lastCount);
        if (boilingTimerCellCount == 0)
            boilingTimerCellCount = 20;//确保沸腾计时器至少有一个默认的20格而不是0
        boilingTimerTotalCellCount = boilingTimerCellCount;//确定沸腾计时器的大小，相除可化值为0~1
    }
    private void MakePlayerMoveUp(int i, Vector3 moveDirection)
    {
        if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.move != null)
        {
            PlayerBehaviour.Instance.move.RequestMove(moveDirection); // 将移动请求添加到队列
        }
        else
        {
            Debug.LogError("PlayerBehaviour 或 move 未初始化！");
        }
    }
    private void SetLastCount()
    {
        if (CountToMakePlayerMoveUp.Count <= 0)
            return;
        Debug.Log("沸腾计时器到达 " + lastCount + " 格");
        lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; //读取最后一个（最大的）打点的数字
        CountToMakePlayerMoveUp.RemoveAt(CountToMakePlayerMoveUp.Count - 1); // 删除最后一个整数
    }
}
