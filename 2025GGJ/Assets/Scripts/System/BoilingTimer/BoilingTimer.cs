using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilingTimer : MonoBehaviour
{
    // ���ڼ�ʱ���ı���
    [SerializeField] public int boilingTimerCellCount; // ���ڼ�ʱ�����ܸ���
    float boilingTimerTotalCellCount; // ���������ڰѷ��ڼ�ʱͬ����0~1

    // ���ڼ�ʱ����������ñ����б�
    int lastCount;
    List<int> CountToMakePlayerMoveUp = new List<int>();

    //// ���ڷ�ֹ�ظ������ƶ�
    //private bool hasTriggeredMove = false;


    // Start is called before the first frame update
    void Start()
    {
        AddIntToList(1, 2, 4, 6, 9, 12, 16); // ���ô���λ�ã�������
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
        if (boilingTimerCellCount <= 0)
            PlayerBehaviour.Instance.health.Die();
    }

    private void ChangeBoilingTimerImage()
    {
        BoilingSystemBehaviour.Instance.boilingTimerFullBar.fillAmount = (float)boilingTimerCellCount / boilingTimerTotalCellCount;//ʹֵƥ��0~1

        if (boilingTimerCellCount == lastCount )
        {
            SetLastCount();
            MakePlayerMoveUp(1, Vector3.up);
        }
    }//ƥ����ֵ�Ͷ���

    private void ResetBoilingTimerSystem()
    {
        lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; // �������ʼ��
        Debug.Log(lastCount);
        if (boilingTimerCellCount == 0)
            boilingTimerCellCount = 100; // ȷ�����ڼ�ʱ��������һ��Ĭ�ϵ�20�������0
        boilingTimerTotalCellCount = boilingTimerCellCount; // ȷ�����ڼ�ʱ���Ĵ�С������ɻ�ֵΪ0~1
    }

    private void MakePlayerMoveUp(int i, Vector3 moveDirection)
    {
        Debug.Log("ǿ���ƶ�");
        if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.move != null)
        {
            PlayerBehaviour.Instance.move.PlayerMoveCells(i, moveDirection);
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
        Debug.Log("���ڼ�ʱ������ " + lastCount + " ��");
        CountToMakePlayerMoveUp.RemoveAt(CountToMakePlayerMoveUp.Count - 1); // ɾ�����һ������
        if (CountToMakePlayerMoveUp.Count > 0)
        {
            lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; // ��ȡ���һ�������ģ���������
        }
    }
}
