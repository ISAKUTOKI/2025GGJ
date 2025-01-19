using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditorInternal.VersionControl.ListControl;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的移动系统
    /// </summary>

    //基础属性
    [SerializeField] private int moveCellCount; // 每次移动的格子数
    [SerializeField] private float cellSize; // 每格的大小（单位：Unity 单位）
    [SerializeField] private float moveSpeed = 5f; // 玩家移动速度
    [SerializeField] private float moveWaitTime;

    //移动可行性的变量
    [HideInInspector] public bool isMoving = false; // 是否正在移动
    [HideInInspector] public bool isForcedMove = false;//是否正在被强迫移动
    [HideInInspector] public bool canMoveAgain = true;

    //回溯用的变量
    private Vector3 backToPosition;
    [HideInInspector] public Coroutine currentMoveCoroutine;
    [HideInInspector] public bool isBackMoving = false;

    //反弹用的变量
    [HideInInspector] public Vector3 deflectDirection;

    //穿越用的变量
    [HideInInspector] public Vector3 currentDirection;



    //private Queue<Vector3> moveQueue = new Queue<Vector3>(); // 移动请求队列

    void Start()
    {
        canMoveAgain = true;
        if (moveCellCount == 0)
            moveCellCount = 1; // 初始化每次移动的格子数，保证至少为1
    }

    void Update()
    {
        TryToMove(moveCellCount);
    }

    public IEnumerator PlayerMoveCells(int i, Vector3 MoveDirection)
    {
        StartCoroutine(PlayerBehaviour.Instance.playerSound.PlayMoveSound());
        PlayerBehaviour.Instance.playerAnimator.SwitchAnimator(MoveDirection);
        //Debug.Log("响了！");
        backToPosition = transform.position;
        //Debug.Log("记录当前位置");

        isMoving = true; ///标记为正在移动

        Vector3 targetPosition = transform.position + MoveDirection * (i * cellSize);///定目标位置

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // 等待下一帧
        }/// 平滑移动到目标位置

        //Debug.Log("计时减了");
        if (!isForcedMove)
            BoilingSystemBehaviour.Instance.BoilingTimer.boilingTimerCellCount -= 1;///使沸腾计时器-1

        // 确保最终位置准确
        transform.position = targetPosition;
        //Debug.Log(transform.position - targetPosition);

        //Debug.Log("移动冷却");
        yield return new WaitForSeconds(moveWaitTime);///延迟 waitTime 秒
        //Debug.Log("结束");


        isMoving = false; ///标记为移动结束
        isForcedMove = false;///标记为强制移动结束
        canMoveAgain = true;///可以再次移动
        currentMoveCoroutine = null; // 清除引用
        //Debug.Log(PlayerBehaviour.Instance.move.isForcedMove);
    }///使玩家移动的方法，同时在移动结束后重置移动相关变量

    public void TryToMove(int moveCellCount)
    {
        //Debug.Log("可以检测移动");
        if (Moveable() && GetMoveDirection() != Vector3.zero)
        {
            currentDirection = GetMoveDirection();
            deflectDirection = GetMoveDirection() * -1;
            //Debug.Log("尝试向 " + GetMoveDirection() + " 移动");
            currentMoveCoroutine = StartCoroutine(PlayerMoveCells(moveCellCount, GetMoveDirection()));
            CanMoveAgainCheck();
            canMoveAgain = false;
        }
    }///尝试移动，如果能动并且输入不为空就动

    public Vector3 GetMoveDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return Vector3.up;
        }
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    return Vector3.down;
        //}
        else if (Input.GetKeyDown(KeyCode.A))
        {
            return Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            return Vector3.right;
        }
        return Vector3.zero;
    }///读取输入的方法



    private void CanMoveAgainCheck()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            canMoveAgain = true;
        }
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    canMoveAgain = true;
        //}
        if (Input.GetKeyUp(KeyCode.A))
        {
            canMoveAgain = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            canMoveAgain = true;
        }
    }///松开按键就可以再次移动

    private bool Moveable()
    {
        //Debug.Log("1");

        if (isForcedMove)
            return false;
        //Debug.Log("2");

        Vector3 moveDirection = GetMoveDirection();
        if (isMoving)
            return false;
        //Debug.Log("正在判断canMoveAgain");

        if (!canMoveAgain)
            return false;
        //Debug.Log("可以移动");
        return true;
    }///确保是在可以移动的状态

    //public void MoveBack()
    //{
    //    if (isMoving && currentMoveCoroutine != null)
    //    {
    //        //Debug.Log("撞墙，回溯到出发位置: " + backToPosition);
    //        StopCoroutine(currentMoveCoroutine); // 停止当前移动协程
    //        currentMoveCoroutine = StartCoroutine(MoveBackToPosition()); // 启动回溯协程
    //    }
    //    else
    //    {
    //        Debug.LogWarning("无法回溯：当前没有正在移动或已经回溯。");
    //    }
    //}///回溯
    //private IEnumerator MoveBackToPosition()
    //{
    //    isBackMoveing = true;
    //    isMoving = true; // 标记为正在移动
    //    isForcedMove = true; // 标记为强制移动

    //    while (Vector3.Distance(transform.position, backToPosition) > 0.01f)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, backToPosition, moveSpeed * Time.deltaTime);
    //        yield return null; // 等待下一帧
    //    }

    //    // 确保最终位置准确
    //    transform.position = backToPosition;

    //    yield return new WaitForSeconds(moveWaitTime); // 移动冷却

    //    isBackMoveing = false;
    //    isMoving = false; // 标记为移动结束
    //    isForcedMove = false; // 标记为强制移动结束
    //    canMoveAgain = true; // 可以再次移动
    //    currentMoveCoroutine = null; // 清除引用
    //}///回溯的协程


    public void MoveBackCells(int moveCounts)
    {
        if (isMoving && currentMoveCoroutine != null)
        {
            StopCoroutine(currentMoveCoroutine); // 停止当前移动协程
            currentMoveCoroutine = StartCoroutine(MoveBackCellsCoroutine(moveCounts)); // 启动回溯协程
        }
        else
        {
            Debug.LogWarning("无法回溯：当前没有正在移动或已经回溯。");
        }
    }
    private IEnumerator MoveBackCellsCoroutine(int moveCounts)
    {
        PlayerBehaviour.Instance.health.canBeHurt = false;

        Debug.Log("移动方向是 " + GetMoveDirection());
        //Debug.Log("反弹方向是 " + deflectDirection);

        isBackMoving = true;
        isMoving = true; // 标记为正在移动
        isForcedMove = true; // 标记为强制移动

        // 第一步：回到 backToPosition
        while (Vector3.Distance(transform.position, backToPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, backToPosition, moveSpeed * Time.deltaTime);
            yield return null; // 等待下一帧
        }

        // 确保最终位置准确
        transform.position = backToPosition;
        Debug.Log("到达反弹位置 " + transform.position);
        // 第二步：从 backToPosition 向 deflectDirection 方向移动n-1
        Vector3 targetPosition = backToPosition + deflectDirection * ((moveCounts - 1) * cellSize); // 计算目标位置

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // 等待下一帧
        }

        // 确保最终位置准确
        transform.position = targetPosition;
        //Debug.Log("到达指定位置 " + targetPosition);

        //Debug.Log("又移动了 " + targetPosition);


        yield return new WaitForSeconds(moveWaitTime); // 移动冷却

        isBackMoving = false;
        isMoving = false; // 标记为移动结束
        isForcedMove = false; // 标记为强制移动结束
        canMoveAgain = true; // 可以再次移动
        currentMoveCoroutine = null; // 清除引用
        PlayerBehaviour.Instance.health.canBeHurt = true;//增加反弹时候的无敌时间

    }

}
