using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeSoundOnTriggered : MonoBehaviour
{
    [SerializeField] List<AudioClip> clipList; // ��Ч�б�
    [SerializeField]private float _volume = 1.0f; // ˽���ֶΣ����ڴ洢����ֵ

    // �������ԣ����Ʒ�Χ�� 0 �� 1 ֮��
    float volume
    {
        get => _volume;
        set => _volume = Mathf.Clamp(value, 0, 1);
    }

    private void Start()
    {
        // ��ʼ�� clipList�������ڴ���ʱ�ظ����
        if (clipList == null)
        {
            clipList = new List<AudioClip>();
            Debug.LogWarning("Clip list is null. Initialized an empty list.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ��鴥�������Ƿ������
        if (other.gameObject.CompareTag("Player"))
        {
            // ��� clipList Ϊ�գ�ֱ�ӷ���
            if (clipList == null || clipList.Count == 0)
            {
                Debug.LogWarning("No audio clips available in the list.");
                return;
            }

            // ���ѡ��һ����Ч����
            AudioClip randomClip = clipList[Random.Range(0, clipList.Count)];
            if (randomClip != null)
            {
                // ������Ч����������
                if (AudioSystemBehaviour.Instance != null)
                {
                    AudioSystemBehaviour.Instance.PlayerSound(randomClip, volume);
                }
                else
                {
                    Debug.LogError("AudioSystemBehaviour instance is null.");
                }
            }
            else
            {
                Debug.LogWarning("Selected audio clip is null.");
            }
        }
    }
}