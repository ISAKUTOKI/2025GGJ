using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    /// <summary>
    /// ����ϵͳ
    /// </summary>

    [SerializeField] private int checkpointLevel; // ��ǰ���������Ĺؿ�
    private bool isTriggered = false;//�Ѿ���¼���ˣ���ֹ�ظ�������

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OK");
        if (!isTriggered && other.CompareTag("Player"))
        {
            //��¼�Ѿ���������
            isTriggered = true;

            // ��ȡ��ҵ�λ��
            Vector3 playerPosition = transform.position;

            // ���� SaveManager ������Ϸ
            SaveManager.Instance.SaveGame(playerPosition, checkpointLevel);

        }
    }
}
