using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    /// <summary>
    /// 检查点系统
    /// </summary>

    [SerializeField] private int checkpointLevel; // 当前检查点所属的关卡
    private bool isTriggered = false;//已经记录过了，防止重复触发用

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OK");
        if (!isTriggered && other.CompareTag("Player"))
        {
            //记录已经触发过了
            isTriggered = true;

            // 获取玩家的位置
            Vector3 playerPosition = transform.position;

            // 调用 SaveManager 保存游戏
            SaveManager.Instance.SaveGame(playerPosition, checkpointLevel);

        }
    }
}
