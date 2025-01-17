using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSystemBehaviour : MonoBehaviour
{
    [SerializeField] public static VolumeSystemBehaviour instance;
    [HideInInspector]public float volume;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseVolume()
    {
        if (AudioListener.volume < 1.0f) // 音量最大为 1
        {
            AudioListener.volume += 0.1f; // 增加全局音量
            //Debug.Log("全局音量增加至: " + AudioListener.volume);
        }
    }//加大音量

    public void DecreaseVolume()
    {
        if (AudioListener.volume > 0.0f) // 音量最小为 0
        {
            AudioListener.volume -= 0.1f; // 降低全局音量
            //Debug.Log("全局音量降低至: " + AudioListener.volume);
        }
    }//减少音量
}
