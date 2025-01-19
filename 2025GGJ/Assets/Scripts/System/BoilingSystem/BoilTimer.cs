using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilTimer : MonoBehaviour
{
    // �����ʱ���ı���
    private Image boilTimer;
    private float boilTimerDuration; // �����ʱ������
    [SerializeField] private float boilTimerTotalTime = 3f; // ��ʱ�䣬Ĭ��3��
    private bool justRunningBoilTimer_1 = true; // �л���ʱ���õ�

    void Start()
    {
        ResetBoilTimerSystem();
    }

    void Update()
    {
        RunBoilTimer(); // ���������ʱ��
    }

    /// <summary>
    /// ���������ʱ��
    /// </summary>
    private void RunBoilTimer()
    {
        boilTimerDuration -= Time.deltaTime;
        if (boilTimerDuration <= 0)
        {
            // �滻Ϊ boilBarBehaviour �Ľӿ�
            BoilingSystemBehaviour.Instance.boilBarBehaviour.CurrentFullBarDropBy(1); // ÿ�μ���1����λ
            boilTimerDuration = boilTimerTotalTime;
            SwitchBoilTimer();
        }
        ChangeBoilTimerImage();
    }

    /// <summary>
    /// �л���ʱ��
    /// </summary>
    private void SwitchBoilTimer()
    {
        if (justRunningBoilTimer_1)
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_2;
            justRunningBoilTimer_1 = false;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(true); // ����1��
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(false); // �ر�2��
        }
        else
        {
            boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1;
            justRunningBoilTimer_1 = true;
            BoilingSystemBehaviour.Instance.boilTimer_1Bottom.SetActive(false); // �ر�1��
            BoilingSystemBehaviour.Instance.boilTimer_2Bottom.SetActive(true); // ����2��
        }
    }

    /// <summary>
    /// ���¼�ʱ��ͼ��
    /// </summary>
    private void ChangeBoilTimerImage()
    {
        if (boilTimer != null)
        {
            boilTimer.fillAmount = boilTimerDuration / boilTimerTotalTime;
        }
    }

    /// <summary>
    /// ���������ʱ��ϵͳ
    /// </summary>
    private void ResetBoilTimerSystem()
    {
        if (boilTimerTotalTime <= 0)
            boilTimerTotalTime = 3f; // ȷ�������ʱ��������һ��Ĭ�ϵ�3��

        boilTimerDuration = boilTimerTotalTime;
        boilTimer = BoilingSystemBehaviour.Instance.boilTimer_1; // ����Ĭ�ϼ�ʱ��
        justRunningBoilTimer_1 = true; // Ĭ��ʹ�ü�ʱ��1
    }

    /// <summary>
    /// ����ʱ���Ƿ�ֵ
    /// </summary>
    private void BoilTimerChecker()
    {
        if (boilTimer == null)
        {
            Debug.LogError("�����ʱ��δ��ֵ��");
        }
        else
        {
            Debug.Log($"��ǰ��ʱ����{boilTimer.name}");
        }
    }
}