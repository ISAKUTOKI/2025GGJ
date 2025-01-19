using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private int CrossedCount; // 记录玩家进入危险区域的次数
    private bool isStayOut;   // 标记玩家是否在危险区域外
    private float StayOutTimer = 0.2f; // 玩家在区域外停留的时间阈值

    private void Start()
    {
        CrossedCount = 0;
        isStayOut = true;
        //Debug.Log("初始化：玩家在危险区域外");
    }

    private void Update()
    {
        // 如果玩家在区域外，减少计时器
        if (isStayOut)
        {
            StayOutTimer -= Time.deltaTime;
        }

        // 如果计时器归零，重置计数器和计时器
        if (StayOutTimer <= 0)
        {
            CrossedCount = 0;
            StayOutTimer = 0.2f; // 重置计时器
            Debug.Log("玩家在区域外停留时间过长，计数器重置");
        }

        // 如果计数达到2，触发玩家死亡
        if (CrossedCount == 2)
        {
            PlayerBehaviour.Instance.health.Die();
            Debug.Log("玩家死亡");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 当玩家进入危险区域时，如果之前是在区域外，则增加计数
        if (other.gameObject.CompareTag("Player") && isStayOut)
        {
            CrossedCount++;
            isStayOut = false;
            StayOutTimer = 0.2f; // 重置计时器
            Debug.Log("玩家进入危险区域，当前计数：" + CrossedCount);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 当玩家离开危险区域时，标记为在区域外
        if (other.gameObject.CompareTag("Player"))
        {
            isStayOut = true;
            Debug.Log("玩家离开危险区域");
        }
    }
}