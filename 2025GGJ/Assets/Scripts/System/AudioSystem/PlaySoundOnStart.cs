using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] List<AudioClip> clipList;
    private float _volume = 0.2f; // ˽���ֶΣ����ڴ洢����ֵ

    float volume
    {
        get
        {
            return _volume; // ����˽���ֶε�ֵ
        }
        set
        {
            _volume = Mathf.Clamp(value, 0, 1); // ����������Χ�� 0 �� 1 ֮��
        }
    }

    void Start()
    {
        if (clipList == null)
        {
            clipList = new List<AudioClip>();
        }
        else
        {
            // ������Ч������������
            foreach (var audioClip in clipList)
            {
                if (audioClip != null)
                {
                    AudioSystemBehaviour.Instance.PlayerSound(audioClip, volume);
                }
            }
        }
    }
}