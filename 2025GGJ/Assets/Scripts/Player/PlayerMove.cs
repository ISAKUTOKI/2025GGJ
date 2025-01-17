using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的移动系统
    /// </summary>

    [HideInInspector] public int moveCellCount; // 每次移动的格子数
    [SerializeField] private int cellSize = 1; // 每格的大小（单位：Unity 单位）
    private bool isMoving = false; // 是否正在移动
    [SerializeField] private float waitTime; // 移动后的等待时间
    [SerializeField] private float moveSpeed = 5f; // 玩家移动速度

    private Queue<Vector3> moveQueue = new Queue<Vector3>(); // 移动请求队列

    void Start()
    {
        moveCellCount = 1; // 初始化每次移动的格子数
    }

    void Update()
    {
        MoveCheck();
        ProcessMoveQueue(); // 处理移动队列
    }

    /// <summary>
    /// 处理移动队列
    /// </summary>
    private void ProcessMoveQueue()
    {
        if (!isMoving && moveQueue.Count > 0)
        {
            Vector3 direction = moveQueue.Dequeue();
            StartCoroutine(PlayerMoveCells(moveCellCount, direction));
        }
    }

    /// <summary>
    /// 添加移动请求到队列
    /// </summary>
    public void RequestMove(Vector3 direction)
    {
        moveQueue.Enqueue(direction);
    }

    public IEnumerator PlayerMoveCells(int i, Vector3 moveDirection)
    {
        isMoving = true; // 标记为正在移动

        Vector3 targetPosition = transform.position + moveDirection * (i * cellSize);

        // 平滑移动到目标位置
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // 等待下一帧
        }

        // 确保最终位置准确
        transform.position = targetPosition;

        // 延迟 waitTime 秒
        yield return new WaitForSeconds(waitTime);

        isMoving = false; // 标记为移动结束
    }

    private Vector3 GetMoveDirection()
    {
        float horizontal = Input.GetAxis("Horizontal"); // 获取水平输入（A/D 或 左/右箭头）
        float vertical = Input.GetAxis("Vertical");     // 获取垂直输入（W/S 或 上/下箭头）

        // 设置输入阈值，过滤无效输入
        float threshold = 0.1f;
        if (Mathf.Abs(horizontal) < threshold) horizontal = 0;
        if (Mathf.Abs(vertical) < threshold) vertical = 0;

        // 注释掉向下移动的功能
        if (vertical < 0) vertical = 0; // 忽略向下的输入

        // 确保每次只能选择一个方向（水平或垂直）
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            vertical = 0; // 如果水平输入更大，忽略垂直输入
        }
        else
        {
            horizontal = 0; // 如果垂直输入更大，忽略水平输入
        }

        // 根据输入值计算移动方向
        Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
        return direction;
    }

    private void MoveCheck()
    {
        if (isMoving) return; // 如果正在移动，直接返回

        Vector3 moveDirection = GetMoveDirection();

        if (moveDirection != Vector3.zero) // 如果有输入
        {
            RequestMove(moveDirection); // 将移动请求添加到队列
        }
    }
}