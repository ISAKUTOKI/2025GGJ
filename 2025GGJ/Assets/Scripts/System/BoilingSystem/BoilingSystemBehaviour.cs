using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingSystemBehaviour : MonoBehaviour
{
    /// <summary>
    /// 烧煮计时器和沸腾计时器的Behaviour系统
    /// </summary>
    public static BoilingSystemBehaviour Instance;

    // 烧煮计时器的变量
    [SerializeField] public Image boilTimer_1;
    [SerializeField] public Image boilTimer_2;
    [SerializeField] public GameObject boilTimer_1Bottom;
    [SerializeField] public GameObject boilTimer_2Bottom;

    // 沸腾计时器的变量

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