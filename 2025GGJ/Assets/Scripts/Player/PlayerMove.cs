using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    private bool canMoveAgain = true;

    //���ݵı���
    private Vector3 lastPosition;
    [HideInInspector]public Coroutine currentMoveCoroutine;


    //private Queue<Vector3> moveQueue = new Queue<Vector3>(); // �ƶ��������

    void Start()
    {
        if (moveCellCount == 0)
            moveCellCount = 1; // ��ʼ��ÿ���ƶ��ĸ���������֤����Ϊ1
    }

    void Update()
    {
        TryToMove(moveCellCount);
    }

    public IEnumerator PlayerMoveCells(int i, Vector3 MoveDirection)
    {
        lastPosition=transform.position;

        isMoving = true; ///���Ϊ�����ƶ�

        Vector3 targetPosition = transform.position + MoveDirection * (i * cellSize);///��Ŀ��λ��

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }/// ƽ���ƶ���Ŀ��λ��

        Debug.Log("��ʱ����");
        if(!isForcedMove)
            BoilingSystemBehaviour.Instance.BoilingTimer.boilingTimerCellCount -= 1;///ʹ���ڼ�ʱ��-1

        // ȷ������λ��׼ȷ
        transform.position = targetPosition;
        //Debug.Log(transform.position - targetPosition);

        //Debug.Log("�ƶ���ȴ");
        yield return new WaitForSeconds(moveWaitTime);///�ӳ� waitTime ��
        //Debug.Log("����");


        isMoving = false; ///���Ϊ�ƶ�����
        isForcedMove = false;///���Ϊǿ���ƶ�����
        canMoveAgain = true;///�����ٴ��ƶ�
        currentMoveCoroutine = null; // �������
        //Debug.Log(PlayerBehaviour.Instance.move.isForcedMove);
    }///ʹ����ƶ��ķ�����ͬʱ���ƶ������������ƶ���ر���

    public void TryToMove(int moveCellCount)
    {
        if (Moveable() && GetMoveDirection() != Vector3.zero)
        {
            Debug.Log("������ " + GetMoveDirection() + " �ƶ�");
            CanMoveAgainCheck();
            canMoveAgain = false;
        }
    }///�����ƶ�������ܶ��������벻Ϊ�վͶ�

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
    }///��ȡ����ķ���

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
    }///�ɿ������Ϳ����ٴ��ƶ�

    private bool Moveable()
    {
        if (isForcedMove)
            return false;
        Vector3 moveDirection = GetMoveDirection();
        if (isMoving)
            return false;
        if (!canMoveAgain)
            return false;
        return true;
    }///ȷ�����ڿ����ƶ���״̬

    public void MoveBack()
    {
        StopCoroutine(currentMoveCoroutine);
        currentMoveCoroutine = null;
        currentMoveCoroutine = StartCoroutine(PlayerMoveCells(moveCellCount, lastPosition));
    }
}
