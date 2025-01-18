using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingTimer : MonoBehaviour
{
    // 沸腾计时器的变量
    [SerializeField] public int boilingTimerCellCount; // 沸腾计时器的总格数
    float boilingTimerTotalCellCount; // 几倍，用于把沸腾计时同步到0~1

    // 沸腾计时器——打点用变量列表
    int firstCount;
    [SerializeField] List<int> CountToMakePlayerMoveUp = new List<int>();//列表为从大到小

    //// 用于防止重复触发移动
    //private bool hasTriggeredMove = false;


    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void ChangeBoilingTimerImage()
    {
        BoilingSystemBehaviour.Instance.boilingTimerFullBar.fillAmount = boilingTimerCellCount / boilingTimerTotalCellCount;//使值匹配0~1
        BoilingTimerCurrentCountCheck();
    }//匹配数值和动画

    private void ResetBoilingTimerSystem()
    {
        if (CountToMakePlayerMoveUp.Count == 0)
            AddIntToList(80, 70, 60, 50, 40, 30, 20, 10, 5); // 如果打点列表为空就设置一个默认打点（从大到小）
        else
            firstCount = CountToMakePlayerMoveUp[0]; // 打点数初始化为第0个值（最大的值）
        //Debug.Log(lastCount);
        if (boilingTimerCellCount == 0)
            boilingTimerCellCount = 100; // 确保沸腾计时器至少有一个默认的100格而不是0
        boilingTimerTotalCellCount = boilingTimerCellCount; // 确定沸腾计时器的大小，使其相除时可化值为0~1
    }

    private IEnumerator MakePlayerMoveUpDelay(int i, Vector3 moveDirection)
    {
        while (PlayerBehaviour.Instance.move.isMoving)
        {
            yield return null;
            //Debug.Log("正在移动，所以动不了");
        }
        PlayerBehaviour.Instance.move.isForcedMove = true;
        PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(i, moveDirection));
    }

    private void TryMakePlayerMoveUp(int i, Vector3 moveDirection)
    {
        //Debug.Log("强制移动");
        PlayerBehaviour.Instance.move.isForcedMove = true;
        if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.move != null)
        {
            //Debug.Log(PlayerBehaviour.Instance.move.isForcedMove);
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(i, moveDirection));
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
        //Debug.Log("沸腾计时器到达 " + firstCount + " 格");
        CountToMakePlayerMoveUp.RemoveAt(0); // 删除最后一个整数
        if (CountToMakePlayerMoveUp.Count > 0)
        {
            firstCount = CountToMakePlayerMoveUp[0]; // 读取最后一个（最大的）打点的数字
        }
    }

    private void BoilingTimerCurrentCountCheck()
    {
        if (boilingTimerCellCount == firstCount)
        {
            SetLastCount();
            if (!PlayerBehaviour.Instance.move.isMoving)
            {
                //Debug.Log("立即移动");
                TryMakePlayerMoveUp(1, Vector3.up);
            }//如果当前没在移动就立即移动
            else
            {
                PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(MakePlayerMoveUpDelay(1, Vector3.up));
                //Debug.Log("延迟移动");
            }//否则就开始协程"延迟开始"
        }//打点检测

        if (boilingTimerCellCount <= 0)
            PlayerBehaviour.Instance.health.Die();//死亡检测
    }
}
