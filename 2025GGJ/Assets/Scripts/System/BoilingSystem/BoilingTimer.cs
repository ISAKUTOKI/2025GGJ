using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingTimer : MonoBehaviour
{
    // ���ڼ�ʱ���ı���
    [SerializeField] public int boilingTimerCellCount; // ���ڼ�ʱ�����ܸ���
    float boilingTimerTotalCellCount; // ���������ڰѷ��ڼ�ʱͬ����0~1

    // ���ڼ�ʱ����������ñ����б�
    int firstCount;
    [SerializeField] List<int> CountToMakePlayerMoveUp = new List<int>();//�б�Ϊ�Ӵ�С

    //// ���ڷ�ֹ�ظ������ƶ�
    //private bool hasTriggeredMove = false;


    // Start is called before the first frame update
    void Start()
    {
        ResetBoilingTimerSystem();
    }

    // Update is called once per frame
    void Update()
    {
        RunBoilingTimer(); // ���з��ڼ�ʱ��
    }

    public void AddIntToList(params int[] numbers)
    {
        foreach (int cellCount in numbers)
        {
            CountToMakePlayerMoveUp.Add(cellCount);
        }
    } // ���˳��Ϊ��С������ӷ�ʽΪAddIntToList(a,b,c,d,f,..);

    /// <summary>
    /// ����Ϊ���ڼ�ʱ����ϵͳ
    /// </summary>
    private void RunBoilingTimer()
    {
        ChangeBoilingTimerImage();
    }

    private void ChangeBoilingTimerImage()
    {
        BoilingSystemBehaviour.Instance.boilingTimerFullBar.fillAmount = boilingTimerCellCount / boilingTimerTotalCellCount;//ʹֵƥ��0~1
        BoilingTimerCurrentCountCheck();
    }//ƥ����ֵ�Ͷ���

    private void ResetBoilingTimerSystem()
    {
        if (CountToMakePlayerMoveUp.Count == 0)
            AddIntToList(80, 70, 60, 50, 40, 30, 20, 10, 5); // �������б�Ϊ�վ�����һ��Ĭ�ϴ�㣨�Ӵ�С��
        else
            firstCount = CountToMakePlayerMoveUp[0]; // �������ʼ��Ϊ��0��ֵ������ֵ��
        //Debug.Log(lastCount);
        if (boilingTimerCellCount == 0)
            boilingTimerCellCount = 100; // ȷ�����ڼ�ʱ��������һ��Ĭ�ϵ�100�������0
        boilingTimerTotalCellCount = boilingTimerCellCount; // ȷ�����ڼ�ʱ���Ĵ�С��ʹ�����ʱ�ɻ�ֵΪ0~1
    }

    private IEnumerator MakePlayerMoveUpDelay(int i, Vector3 moveDirection)
    {
        while (PlayerBehaviour.Instance.move.isMoving)
        {
            yield return null;
            //Debug.Log("�����ƶ������Զ�����");
        }
        PlayerBehaviour.Instance.move.isForcedMove = true;
        PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(i, moveDirection));
    }

    private void TryMakePlayerMoveUp(int i, Vector3 moveDirection)
    {
        //Debug.Log("ǿ���ƶ�");
        PlayerBehaviour.Instance.move.isForcedMove = true;
        if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.move != null)
        {
            //Debug.Log(PlayerBehaviour.Instance.move.isForcedMove);
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(i, moveDirection));
        }
        else
        {
            Debug.LogError("PlayerBehaviour �� move δ��ʼ����");
        }
    }

    private void SetLastCount()
    {
        if (CountToMakePlayerMoveUp.Count <= 0)
            return;
        //Debug.Log("���ڼ�ʱ������ " + firstCount + " ��");
        CountToMakePlayerMoveUp.RemoveAt(0); // ɾ�����һ������
        if (CountToMakePlayerMoveUp.Count > 0)
        {
            firstCount = CountToMakePlayerMoveUp[0]; // ��ȡ���һ�������ģ���������
        }
    }

    private void BoilingTimerCurrentCountCheck()
    {
        if (boilingTimerCellCount == firstCount)
        {
            SetLastCount();
            if (!PlayerBehaviour.Instance.move.isMoving)
            {
                //Debug.Log("�����ƶ�");
                TryMakePlayerMoveUp(1, Vector3.up);
            }//�����ǰû���ƶ��������ƶ�
            else
            {
                PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(MakePlayerMoveUpDelay(1, Vector3.up));
                //Debug.Log("�ӳ��ƶ�");
            }//����Ϳ�ʼЭ��"�ӳٿ�ʼ"
        }//�����

        if (boilingTimerCellCount <= 0)
            PlayerBehaviour.Instance.health.Die();//�������
    }
}
