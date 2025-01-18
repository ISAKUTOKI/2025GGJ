using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] List<AudioClip> clipList;
    private float _volume = 0.2f; // 私有字段，用于存储音量值

    float volume
    {
        get
        {
            return _volume; // 返回私有字段的值
        }
        set
        {
            _volume = Mathf.Clamp(value, 0, 1); // 限制音量范围在 0 到 1 之间
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
            // 播放音效，并设置音量
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