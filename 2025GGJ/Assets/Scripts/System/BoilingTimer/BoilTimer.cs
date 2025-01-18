using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilTimer : MonoBehaviour
{
    // �����ʱ���ı���
    private Image boilTimer;
    private float boilTimerDuration; // �����ʱ������
    [SerializeField] private float boilTimerTotalTime; // ���������ڰ������ʱͬ����0~1
    bool justRunningBoilTimer_1; // �л���ʱ���õ�


    void Start()
    {
        ResetBoilTimerSystem();
    }

    // Update is called once per frame
    void Update()
    {
        RunBoilTimer(); // ���������ʱ��
    }

    /// <summary>
    /// ����Ϊ�����ʱ����ϵͳ
    /// </summary>
    private void RunBoilTimer()
    {
        boilTimerDuration -= Time.deltaTime;
        if (boilTimerDuration <= 0)
        {
            BoilingSystemBehaviour.Instance.BoilingTimer.boilingTimerCellCount -= 1;
            boilTimerDuration = boilTimerTotalTime;
            SwitchBoilTimer();
        }
        ChangeBoilTimerImage();
    }

    private void SwitchBoilTimer()
    {
        if (justRunningBoilTimer_1)
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_2;
            justRunningBoilTimer_1 = false;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(true); // ��1�׼���
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(false); // ��2�׹ر�
        } // ������1�Ļ����л���2
        else
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1;
            justRunningBoilTimer_1 = true;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(false); // ��1�׹ر�
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(true); // ��2�׼���
        } // ������2�Ļ����л���1
    } // �ڵ���ʱ������ʱ����м�ʱ���л�

    private void ChangeBoilTimerImage()
    {
        boilTimer.fillAmount = boilTimerDuration / boilTimerTotalTime;
    }

    private void ResetBoilTimerSystem()
    {
        if (boilTimerTotalTime == 0)
            boilTimerTotalTime = 3; // ȷ�������ʱ��������һ��Ĭ�ϵ�3�������0
        boilTimerDuration = boilTimerTotalTime; // ȷ�������ʱ���Ĵ�С������ɻ�ֵΪ0~1
        boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1; // ����Ĭ�ϵ������ʱ��
        justRunningBoilTimer_1 = true; // Ĭ��ʹ�������ʱ��1
    } // ���������ʱ��ϵͳ

    private void BoilTimerChecker()
    {
        if (boilTimer == null)
            Debug.Log("û����ֵ");
        else
            Debug.Log(boilTimer.name);
    } // �������ʱ��û����ֵʱ����//����ͱ�������
}
