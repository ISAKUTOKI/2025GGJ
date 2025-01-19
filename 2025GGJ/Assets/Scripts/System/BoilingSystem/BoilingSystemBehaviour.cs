using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingSystemBehaviour : MonoBehaviour
{
    /// <summary>
    /// �����ʱ���ͷ��ڼ�ʱ����Behaviourϵͳ
    /// </summary>
    public static BoilingSystemBehaviour Instance;

    // �����ʱ���ı���
    [SerializeField] public Image boilTimer_1;
    [SerializeField] public Image boilTimer_2;
    [SerializeField] public GameObject boilTimer_1Bottom;
    [SerializeField] public GameObject boilTimer_2Bottom;

    // ���ڼ�ʱ���ı���

    [HideInInspector] public BoilTimer boilTimer;
    [HideInInspector] public BoilingBarBehaviour boilBarBehaviour;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        boilTimer = GetComponent<BoilTimer>();
        boilBarBehaviour = GetComponent<BoilingBarBehaviour>();
    }

    void Update()
    {

    }


}