using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilingTimer : MonoBehaviour
{
    // 沸腾计时器的变量
    [SerializeField] public int boilingTimerCellCount; // 沸腾计时器的总格数
    float boilingTimerTotalCellCount; // 几倍，用于把沸腾计时同步到0~1

    // 沸腾计时器——打点用变量列表
    int lastCount;
    List<int> CountToMakePlayerMoveUp = new List<int>();

    //// 用于防止重复触发移动
    //private bool hasTriggeredMove = false;


    // Start is called before the first frame update
    void Start()
    {
        AddIntToList(1, 2, 4, 6, 9, 12, 16); // 设置打点的位置（格数）
        ResetBoilingTimerSystem();
    }

    // Update is called once per frame
    void Update()
    {
        RunBoilingTimer(); // 运行沸腾计时器
    }

    public void AddIntToList(params int[] numbers)
    {
        foreach (int cellCount in numbers)
        {
            CountToMakePlayerMoveUp.Add(cellCount);
        }
    } // 添加顺序为从小到大，添加方式为AddIntToList(a,b,c,d,f,..);

    /// <summary>
    /// 以下为沸腾计时器的系统
    /// </summary>
    private void RunBoilingTimer()
    {
        ChangeBoilingTimerImage();
        if (boilingTimerCellCount <= 0)
            PlayerBehaviour.Instance.health.Die();
    }

    private void ChangeBoilingTimerImage()
    {
        BoilingSystemBehaviour.Instance.boilingTimerFullBar.fillAmount = (float)boilingTimerCellCount / boilingTimerTotalCellCount;//使值匹配0~1

        if (boilingTimerCellCount == lastCount )
        {
            SetLastCount();
            MakePlayerMoveUp(1, Vector3.up);
        }
    }//匹配数值和动画

    private void ResetBoilingTimerSystem()
    {
        lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; // 打点数初始化
        Debug.Log(lastCount);
        if (boilingTimerCellCount == 0)
            boilingTimerCellCount = 100; // 确保沸腾计时器至少有一个默认的20格而不是0
        boilingTimerTotalCellCount = boilingTimerCellCount; // 确定沸腾计时器的大小，相除可化值为0~1
    }

    private void MakePlayerMoveUp(int i, Vector3 moveDirection)
    {
        Debug.Log("强制移动");
        if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.move != null)
        {
            PlayerBehaviour.Instance.move.PlayerMoveCells(i, moveDirection);
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
        CountToMakePlayerMoveUp.RemoveAt(CountToMakePlayerMoveUp.Count - 1); // 删除最后一个整数
        if (CountToMakePlayerMoveUp.Count > 0)
        {
            lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; // 读取最后一个（最大的）打点的数字
        }
    }
}
