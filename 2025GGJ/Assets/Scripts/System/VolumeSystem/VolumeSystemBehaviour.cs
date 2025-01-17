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
        if (AudioListener.volume < 1.0f) // �������Ϊ 1
        {
            AudioListener.volume += 0.1f; // ����ȫ������
            //Debug.Log("ȫ������������: " + AudioListener.volume);
        }
    }//�Ӵ�����

    public void DecreaseVolume()
    {
        if (AudioListener.volume > 0.0f) // ������СΪ 0
        {
            AudioListener.volume -= 0.1f; // ����ȫ������
            //Debug.Log("ȫ������������: " + AudioListener.volume);
        }
    }//��������
}
