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
            _volume = Mathf.Clamp(value, 0, 1); // 限制音量
        }
    }

    void Start()
    {
        if (clipList == null || clipList.Count == 0)
        {
            //Debug.Log("空");
            return;
        }

        // 确保只处理两个音效
        int clipCount = Mathf.Min(clipList.Count, 2);

        for (int i = 0; i < clipCount; i++)
        {
            if (clipList[i] != null)
            {
                // 创建 AudioSource 组件
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = clipList[i]; // 设置音效
                audioSource.volume = volume; // 设置音量
                audioSource.loop = true; // 设置循环播放
                audioSource.Play(); // 开始播放

                audioSources.Add(audioSource); // 将 AudioSource 添加到列表中
            }
            else
            {
                //Debug.Log("无效");
            }
        }
    }
}