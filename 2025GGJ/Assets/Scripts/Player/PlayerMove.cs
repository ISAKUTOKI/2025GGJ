using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ���ƶ�ϵͳ
    /// </summary>

    //��������
    [SerializeField] private int moveCellCount; // ÿ���ƶ��ĸ�����
    [SerializeField] private float cellSize; // ÿ��Ĵ�С����λ��Unity ��λ��
    [SerializeField] private float moveSpeed = 5f; // ����ƶ��ٶ�
    [SerializeField] private float moveWaitTime;

    //�ƶ������Եı���
    [HideInInspector] public bool isMoving = false; // �Ƿ������ƶ�
    [HideInInspector] public bool isForcedMove = false;//�Ƿ����ڱ�ǿ���ƶ�
    private bool isTryToMove = false;//�Ƿ����ڳ����ƶ�

    //��⵱ǰ�ƶ�����ı���
    float horizontalInput; // ˮƽ����ֵ
    float verticalInput;   // ��ֱ����ֵ

    //private Queue<Vector3> moveQueue = new Queue<Vector3>(); // �ƶ��������

    void Start()
    {
        if (moveCellCount == 0)
            moveCellCount = 1; // ��ʼ��ÿ���ƶ��ĸ���������֤����Ϊ1
    }

    void Update()
    {
        MoveableCheck();
        MoveDirectionCheck();
       
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
        //Debug.Log(transform.position - targetPosition);

        //Debug.Log("�ƶ���ȴ");
        yield return new WaitForSeconds(moveWaitTime);///�ӳ� waitTime ��
        //Debug.Log("����");


        isMoving = false; //���Ϊ�ƶ�����
        isForcedMove = false;//���Ϊǿ���ƶ�����
        //Debug.Log(PlayerBehaviour.Instance.move.isForcedMove);
    }

    private Vector3 GetMoveDirection()
    {
        float horizontal = Input.GetAxis("Horizontal"); // ��ȡˮƽ���루A/D �� ��/�Ҽ�ͷ��
        float vertical = Input.GetAxis("Vertical");     // ��ȡ��ֱ���루W/S �� ��/�¼�ͷ��

        //// ����������ֵ��������Ч����
        //float threshold = 0.2f;
        //if (Mathf.Abs(horizontal) < threshold) horizontal = 0;
        //if (Mathf.Abs(vertical) < threshold) vertical = 0;

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

        isTryToMove = direction != Vector3.zero;
        //Debug.Log("�Ƿ����ڳ����ƶ��� "+isTryToMove);

        return direction;
    }

    private void MoveableCheck()
    {
        if (isForcedMove) 
            return; // �������ǿ���ƶ���ֱ�ӷ���
        Vector3 moveDirection = GetMoveDirection();
        if (!isTryToMove)
            return;
        if (isMoving)
            return;
        StartCoroutine(PlayerMoveCells(moveCellCount, moveDirection));
    }//ȷ�����ڿ����ƶ���״̬

    private void MoveDirectionCheck()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 && verticalInput != 0)
        {
            //Debug.Log("������ڳ���б���ƶ�");
            return;
        }
        else if (horizontalInput != 0 || verticalInput != 0)
        {

        }
    }//�ƶ�������
}
