using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ���ƶ�ϵͳ
    /// </summary>

    [HideInInspector] public int moveCellCount; // ÿ���ƶ��ĸ�����
    [SerializeField] private int cellSize = 1; // ÿ��Ĵ�С����λ��Unity ��λ��
    private bool isMoving = false; // �Ƿ������ƶ�
    [SerializeField] private float waitTime; // �ƶ���ĵȴ�ʱ��
    [SerializeField] private float moveSpeed = 5f; // ����ƶ��ٶ�

    void Start()
    {
        moveCellCount = 1; // ��ʼ��ÿ���ƶ��ĸ�����
    }

    void Update()
    {
        MoveCheck();
    }

    private IEnumerator PlayerMoveCells(int i, Vector3 moveDirection)
    {
        isMoving = true; // ���Ϊ�����ƶ�

        Vector3 targetPosition = transform.position; // Ŀ��λ��

        // �������ƶ�����
        float totalDistance = i * cellSize;

        // ����Ŀ��λ��
        targetPosition += moveDirection * totalDistance;

        // ƽ���ƶ���Ŀ��λ��
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null; // �ȴ���һ֡
        }

        // ȷ������λ��׼ȷ
        transform.position = targetPosition;
        Debug.Log("�ƶ���ɣ���ǰλ��: " + transform.position);

        // �ӳ� waitTime ��
        yield return new WaitForSeconds(waitTime);

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
        if (isMoving) return; // ��������ƶ���ֱ�ӷ���

        Vector3 moveDirection = GetMoveDirection();

        if (moveDirection != Vector3.zero) // ���������
        {
            StartCoroutine(PlayerMoveCells(moveCellCount, moveDirection)); // �ƶ� moveCellCount ��
        }
    }
}