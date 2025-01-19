using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeSoundOnTriggered : MonoBehaviour
{
    [SerializeField] List<AudioClip> clipList; // 音效列表
    [SerializeField]private float _volume = 1.0f; // 私有字段，用于存储音量值

    // 音量属性，限制范围在 0 到 1 之间
    float volume
    {
        get => _volume;
        set => _volume = Mathf.Clamp(value, 0, 1);
    }

    private void Start()
    {
        // 初始化 clipList，避免在触发时重复检查
        if (clipList == null)
        {
            clipList = new List<AudioClip>();
            Debug.LogWarning("Clip list is null. Initialized an empty list.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查触发对象是否是玩家
        if (other.gameObject.CompareTag("Player"))
        {
            // 如果 clipList 为空，直接返回
            if (clipList == null || clipList.Count == 0)
            {
                Debug.LogWarning("No audio clips available in the list.");
                return;
            }

            // 随机选择一个音效播放
            AudioClip randomClip = clipList[Random.Range(0, clipList.Count)];
            if (randomClip != null)
            {
                // 播放音效并设置音量
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