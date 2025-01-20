using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clipList;
    [SerializeField] private float _volume = 0.5f;

    private List<AudioSource> audioSources = new List<AudioSource>();

    float volume
    {
        get
        {
            return _volume;
        }
        set
        {
            _volume = Mathf.Clamp(value, 0, 1); // ��������
        }
    }

    void Start()
    {
        if (clipList == null || clipList.Count == 0)
        {
            //Debug.Log("��");
            return;
        }

        // ȷ��ֻ����������Ч
        int clipCount = Mathf.Min(clipList.Count, 2);

        for (int i = 0; i < clipCount; i++)
        {
            if (clipList[i] != null)
            {
                // ���� AudioSource ���
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = clipList[i]; // ������Ч
                audioSource.volume = volume; // ��������
                audioSource.loop = true; // ����ѭ������
                audioSource.Play(); // ��ʼ����

                audioSources.Add(audioSource); // �� AudioSource ��ӵ��б���
            }
            else
            {
                //Debug.Log("��Ч");
            }
        }
    }
}