using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private int CrossedCount; // ��¼��ҽ���Σ������Ĵ���
    private bool isStayOut;   // �������Ƿ���Σ��������
    private float StayOutTimer = 0.2f; // �����������ͣ����ʱ����ֵ

    private void Start()
    {
        CrossedCount = 0;
        isStayOut = true;
        //Debug.Log("��ʼ���������Σ��������");
    }

    private void Update()
    {
        // �������������⣬���ټ�ʱ��
        if (isStayOut)
        {
            StayOutTimer -= Time.deltaTime;
        }

        // �����ʱ�����㣬���ü������ͼ�ʱ��
        if (StayOutTimer <= 0)
        {
            CrossedCount = 0;
            StayOutTimer = 0.2f; // ���ü�ʱ��
            Debug.Log("�����������ͣ��ʱ�����������������");
        }

        // ��������ﵽ2�������������
        if (CrossedCount == 2)
        {
            PlayerBehaviour.Instance.health.Die();
            Debug.Log("�������");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����ҽ���Σ������ʱ�����֮ǰ���������⣬�����Ӽ���
        if (other.gameObject.CompareTag("Player") && isStayOut)
        {
            CrossedCount++;
            isStayOut = false;
            StayOutTimer = 0.2f; // ���ü�ʱ��
            Debug.Log("��ҽ���Σ�����򣬵�ǰ������" + CrossedCount);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ������뿪Σ������ʱ�����Ϊ��������
        if (other.gameObject.CompareTag("Player"))
        {
            isStayOut = true;
            Debug.Log("����뿪Σ������");
        }
    }
}