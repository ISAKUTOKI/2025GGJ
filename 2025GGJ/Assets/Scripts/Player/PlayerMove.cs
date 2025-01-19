using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using static UnityEditorInternal.VersionControl.ListControl;

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
    [HideInInspector] public bool canMoveAgain = true;

    //�����õı���
    private Vector3 backToPosition;
    [HideInInspector] public Coroutine currentMoveCoroutine;
    [HideInInspector] public bool isBackMoving = false;

    //�����õı���
    [HideInInspector] public Vector3 deflectDirection;

    //��Խ�õı���
    [HideInInspector] public Vector3 currentDirection;



    //private Queue<Vector3> moveQueue = new Queue<Vector3>(); // �ƶ��������

    void Start()
    {
        canMoveAgain = true;
        if (moveCellCount == 0)
            moveCellCount = 1; // ��ʼ��ÿ���ƶ��ĸ���������֤����Ϊ1
    }

    void Update()
    {
        TryToMove(moveCellCount);
    }

    public IEnumerator PlayerMoveCells(int i, Vector3 MoveDirection)
    {
        StartCoroutine(PlayerBehaviour.Instance.playerSound.PlayMoveSound());
        PlayerBehaviour.Instance.playerAnimator.SwitchAnimator(MoveDirection);
        //Debug.Log("���ˣ�");
        backToPosition = transform.position;
        //Debug.Log("��¼��ǰλ��");

        isMoving = true; ///���Ϊ�����ƶ�

        Vector3 targetPosition = transform.position + MoveDirection * (i * cellSize);///��Ŀ��λ��

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }/// ƽ���ƶ���Ŀ��λ��

        //Debug.Log("��ʱ����");
        if (!isForcedMove)
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
        //Debug.Log("���Լ���ƶ�");
        if (Moveable() && GetMoveDirection() != Vector3.zero)
        {
            currentDirection = GetMoveDirection();
            deflectDirection = GetMoveDirection() * -1;
            //Debug.Log("������ " + GetMoveDirection() + " �ƶ�");
            currentMoveCoroutine = StartCoroutine(PlayerMoveCells(moveCellCount, GetMoveDirection()));
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
        //Debug.Log("1");

        if (isForcedMove)
            return false;
        //Debug.Log("2");

        Vector3 moveDirection = GetMoveDirection();
        if (isMoving)
            return false;
        //Debug.Log("�����ж�canMoveAgain");

        if (!canMoveAgain)
            return false;
        //Debug.Log("�����ƶ�");
        return true;
    }///ȷ�����ڿ����ƶ���״̬

    //public void MoveBack()
    //{
    //    if (isMoving && currentMoveCoroutine != null)
    //    {
    //        //Debug.Log("ײǽ�����ݵ�����λ��: " + backToPosition);
    //        StopCoroutine(currentMoveCoroutine); // ֹͣ��ǰ�ƶ�Э��
    //        currentMoveCoroutine = StartCoroutine(MoveBackToPosition()); // ��������Э��
    //    }
    //    else
    //    {
    //        Debug.LogWarning("�޷����ݣ���ǰû�������ƶ����Ѿ����ݡ�");
    //    }
    //}///����
    //private IEnumerator MoveBackToPosition()
    //{
    //    isBackMoveing = true;
    //    isMoving = true; // ���Ϊ�����ƶ�
    //    isForcedMove = true; // ���Ϊǿ���ƶ�

    //    while (Vector3.Distance(transform.position, backToPosition) > 0.01f)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, backToPosition, moveSpeed * Time.deltaTime);
    //        yield return null; // �ȴ���һ֡
    //    }

    //    // ȷ������λ��׼ȷ
    //    transform.position = backToPosition;

    //    yield return new WaitForSeconds(moveWaitTime); // �ƶ���ȴ

    //    isBackMoveing = false;
    //    isMoving = false; // ���Ϊ�ƶ�����
    //    isForcedMove = false; // ���Ϊǿ���ƶ�����
    //    canMoveAgain = true; // �����ٴ��ƶ�
    //    currentMoveCoroutine = null; // �������
    //}///���ݵ�Э��


    public void MoveBackCells(int moveCounts)
    {
        if (isMoving && currentMoveCoroutine != null)
        {
            StopCoroutine(currentMoveCoroutine); // ֹͣ��ǰ�ƶ�Э��
            currentMoveCoroutine = StartCoroutine(MoveBackCellsCoroutine(moveCounts)); // ��������Э��
        }
        else
        {
            Debug.LogWarning("�޷����ݣ���ǰû�������ƶ����Ѿ����ݡ�");
        }
    }
    private IEnumerator MoveBackCellsCoroutine(int moveCounts)
    {
        PlayerBehaviour.Instance.health.canBeHurt = false;

        Debug.Log("�ƶ������� " + GetMoveDirection());
        //Debug.Log("���������� " + deflectDirection);

        isBackMoving = true;
        isMoving = true; // ���Ϊ�����ƶ�
        isForcedMove = true; // ���Ϊǿ���ƶ�

        // ��һ�����ص� backToPosition
        while (Vector3.Distance(transform.position, backToPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, backToPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }

        // ȷ������λ��׼ȷ
        transform.position = backToPosition;
        Debug.Log("���ﷴ��λ�� " + transform.position);
        // �ڶ������� backToPosition �� deflectDirection �����ƶ�n-1
        Vector3 targetPosition = backToPosition + deflectDirection * ((moveCounts - 1) * cellSize); // ����Ŀ��λ��

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }

        // ȷ������λ��׼ȷ
        transform.position = targetPosition;
        //Debug.Log("����ָ��λ�� " + targetPosition);

        //Debug.Log("���ƶ��� " + targetPosition);


        yield return new WaitForSeconds(moveWaitTime); // �ƶ���ȴ

        isBackMoving = false;
        isMoving = false; // ���Ϊ�ƶ�����
        isForcedMove = false; // ���Ϊǿ���ƶ�����
        canMoveAgain = true; // �����ٴ��ƶ�
        currentMoveCoroutine = null; // �������
        PlayerBehaviour.Instance.health.canBeHurt = true;//���ӷ���ʱ����޵�ʱ��

    }

}
