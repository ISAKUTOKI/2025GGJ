using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ���ƶ�ϵͳ
    /// </summary>

    [SerializeField] private int moveCellCount; // ÿ���ƶ��ĸ�����
    [SerializeField] private int cellSize = 1; // ÿ��Ĵ�С����λ��Unity ��λ��
    [SerializeField] private float moveSpeed = 5f; // ����ƶ��ٶ�
    [SerializeField] private float moveWaitTime;

    private bool isMoving = false; // �Ƿ������ƶ�
    //private Queue<Vector3> moveQueue = new Queue<Vector3>(); // �ƶ��������

    void Start()
    {
        if (moveCellCount == 0)
            moveCellCount = 1; // ��ʼ��ÿ���ƶ��ĸ���������֤����Ϊ1
    }

    void Update()
    {
        MoveCheck();
        //ProcessMoveQueue(); // �����ƶ�����
    }

    /// <summary>
    /// �����ƶ�����
    /// </summary>
    //private void ProcessMoveQueue()
    //{
    //    if (!isMoving && moveQueue.Count > 0)
    //    {
    //        Vector3 direction = moveQueue.Dequeue();
    //        StartCoroutine(PlayerMoveCells(moveCellCount, direction));
    //    }
    //}

    /// <summary>
    /// ����ƶ����󵽶���
    /// </summary>
    //public void RequestMove(Vector3 direction)
    //{
    //    moveQueue.Enqueue(direction);
    //}

    public IEnumerator PlayerMoveCells(int i, Vector3 moveDirection)
    {
        isMoving = true; // ���Ϊ�����ƶ�

        Vector3 targetPosition = transform.position + moveDirection * (i * cellSize);

        // ƽ���ƶ���Ŀ��λ��
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }

        // ȷ������λ��׼ȷ
        transform.position = targetPosition;

        Debug.Log("��ʼ�ȴ�");
        // �ӳ� waitTime ��
        Debug.Log("����");

        yield return new WaitForSeconds(moveWaitTime);

        isMoving = false; // ���Ϊ�ƶ�����
    }

    private Vector3 GetMoveDirection()
    {
        float horizontal = Input.GetAxis("Horizontal"); // ��ȡˮƽ���루A/D �� ��/�Ҽ�ͷ��
        float vertical = Input.GetAxis("Vertical");     // ��ȡ��ֱ���루W/S �� ��/�¼�ͷ��

        // ����������ֵ��������Ч����
        float threshold = 0.1f;
        if (Mathf.Abs(horizontal) < threshold) horizontal = 0;
        if (Mathf.Abs(vertical) < threshold) vertical = 0;

        // ���������ƶ�
        if (vertical < 0) vertical = 0;

        // ȷ��ÿ��ֻ��ѡ��һ������ˮƽ��ֱ��
        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            vertical = 0; // ���ˮƽ������󣬺��Դ�ֱ����
        }
        else
        {
            horizontal = 0; // �����ֱ������󣬺���ˮƽ����
        }

        // ��������ֵ�����ƶ�����
        Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
        return direction;
    }

    private void MoveCheck()
    {
        if (isMoving)
            return;

        Vector3 moveDirection = GetMoveDirection();
        StartCoroutine(PlayerMoveCells(moveCellCount, moveDirection));
    }
}