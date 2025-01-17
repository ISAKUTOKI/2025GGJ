using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingSystemBehaviour : MonoBehaviour
{
    /// <summary>
    /// �����ʱ���ͷ��ڼ�ʱ����ϵͳ
    /// </summary>

    //�����ʱ���ı���
    [SerializeField] Image boilTimer_1;
    [SerializeField] Image boilTimer_2;
    [SerializeField] GameObject boilTimer_1Bottom;
    [SerializeField] GameObject boilTimer_2Bottom;
    [HideInInspector] Image boilTimer;
    private float boilTimerDuration;//�����ʱ������
    [SerializeField] private float boilTimerTotalTime;//���������ڰ������ʱͬ����0~1
    bool justRunningBoilTimer_1;//�л���ʱ���õ�

    //���ڼ�ʱ���ı���
    [SerializeField] Image boilingTimerFullBar;
    [SerializeField] private int boilingTimerCellCount;//���ڼ�ʱ�����ܸ���
    float boilingTimerTotalCellCount;//���������ڰѷ��ڼ�ʱͬ����0~1

    //���ڼ�ʱ����������ñ���
    int lastCount;
    List<int> CountToMakePlayerMoveUp = new();

    public void AddIntToList(params int[] numbers)
    {
        foreach (int cellCount in numbers)
        {
            CountToMakePlayerMoveUp.Add(cellCount);
        }
    }//���˳��Ϊ��С������ӷ�ʽΪAddIntToList(a,b,c,d,f,..);

    void Start()
    {
        AddIntToList(1, 2, 4, 6, 9, 12, 16);//���ô���λ�ã�������
        ResetBoilTimerSystem();
        ResetBoilingTimerSystem();
    }

    void Update()
    {
        RunBoilTimer();//���������ʱ��
        RunBoilingTimer();//���з��ڼ�ʱ��
    }


    /// <summary>
    /// ����Ϊ�����ʱ����ϵͳ
    /// ������
    /// ���������ʱ��-->���ٵ���ʱ��������ʱ�����ʱ�򣬷��ڵ���ʱ�ĸ���-1���������󵹼�ʱ���л���ǰ�����󵹼�ʱ�������л�ͼ�񣩣����ʵʱ�ı����󵹼�ʱ��ͼ��
    /// �л������ʱ��-->�����ǰ�Ǽ�ʱ��1,���л���2����֮�л���1-->[Ĭ���Ǽ�ʱ��1]
    /// ʵʱ�ı������ʱ����ͼ��
    /// </summary>
    private void RunBoilTimer()
    {
        boilTimerDuration -= Time.deltaTime;
        //Debug.Log(boilTimerDuration);
        if (boilTimerDuration <= 0)
        {
            boilingTimerCellCount -= 1;
            boilTimerDuration = boilTimerTotalTime;
            SwitchBoilTimer();
        }
        ChangeBoilTimerImage();
    }
    private void SwitchBoilTimer()
    {
        if (justRunningBoilTimer_1)
        {
            boilTimer = boilTimer_2;
            justRunningBoilTimer_1 = false;
            boilTimer_1Bottom.SetActive(true);//��1�׼���
            boilTimer_2Bottom.SetActive(false);//��2�׹ر�
        }//������1�Ļ����л���2
        else
        {
            boilTimer = boilTimer_1;
            justRunningBoilTimer_1 = true;
            boilTimer_1Bottom.SetActive(false);//��1�׹ر�
            boilTimer_2Bottom.SetActive(true);//��2�׼���
        }//������2�Ļ����л���1
    }//�ڵ���ʱ������ʱ����м�ʱ���л�
    private void ChangeBoilTimerImage()
    {
        boilTimer.fillAmount = boilTimerDuration / boilTimerTotalTime;
    }
    private void ResetBoilTimerSystem()
    {
        if (boilTimerTotalTime == 0)
            boilTimerTotalTime = 3;//ȷ�������ʱ��������һ��Ĭ�ϵ�3�������0
        boilTimerDuration = boilTimerTotalTime;//ȷ�������ʱ���Ĵ�С������ɻ�ֵΪ0~1
        boilTimer = boilTimer_1;//����Ĭ�ϵ������ʱ��
        justRunningBoilTimer_1 = true;//Ĭ��ʹ�������ʱ��1
        //BoilTimerChecker();//����ʱ���ĺϷ���
    }//���������ʱ��ϵͳ
    private void BoilTimerChecker()
    {
        if (boilTimer == null)
            Debug.Log("û����ֵ");
        else
            Debug.Log(boilTimer.name);
    }//�������ʱ��û����ֵʱ����//����ͱ�������



    /// <summary>
    ///����Ϊ���ڼ�ʱ����ϵͳ
    /// </summary>
    private void RunBoilingTimer()
    {
        ChangeBoilingTimerImage();
        if (boilingTimerCellCount <= 0)
            PlayerBehaviour.Instance.health.Die();
    }
    private void ChangeBoilingTimerImage()
    {
        boilingTimerFullBar.fillAmount = boilingTimerCellCount / boilingTimerTotalCellCount;
        //Debug.Log(boilingTimerCellCount);
        //Debug.Log(boilingTimerCellCount / boilingTimerTotalCellCount);
        if (boilingTimerCellCount <= lastCount)
        {
            SetLastCount();
            MakePlayerMoveUp(1, Vector3.up);
        }
    }
    private void ResetBoilingTimerSystem()
    {
        lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; //�������ʼ��
        Debug.Log(lastCount);
        if (boilingTimerCellCount == 0)
            boilingTimerCellCount = 20;//ȷ�����ڼ�ʱ��������һ��Ĭ�ϵ�20�������0
        boilingTimerTotalCellCount = boilingTimerCellCount;//ȷ�����ڼ�ʱ���Ĵ�С������ɻ�ֵΪ0~1
    }
    private void MakePlayerMoveUp(int i, Vector3 moveDirection)
    {
        if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.move != null)
        {
            PlayerBehaviour.Instance.move.RequestMove(moveDirection); // ���ƶ�������ӵ�����
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
        lastCount = CountToMakePlayerMoveUp[CountToMakePlayerMoveUp.Count - 1]; //��ȡ���һ�������ģ���������
        CountToMakePlayerMoveUp.RemoveAt(CountToMakePlayerMoveUp.Count - 1); // ɾ�����һ������
    }
}
