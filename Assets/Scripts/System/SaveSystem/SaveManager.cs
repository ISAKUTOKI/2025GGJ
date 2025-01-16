using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    /// <summary>
    /// 存档系统
    /// </summary>

    public static SaveManager Instance; // 单例模式

    private List<SaveData> savePoints = new List<SaveData>(); // 存档列表

    private void Awake()
    {
            Instance = this;
    }

    // 创建存档点
    public void SaveGame(Vector3 playerPosition, int currentLevel)
    {
        SaveData savePoint = new SaveData
        {
            playerPosition = playerPosition,
            currentLevel = currentLevel
        };
        savePoints.Add(savePoint);
        Debug.Log("Game saved at level " + currentLevel);
    }

    // 加载上一个存档点
    public SaveData LoadLastSave()
    {
        if (savePoints.Count == 0)
        {
            Debug.LogWarning("No save points available!");
            return null;
        }

        SaveData lastSave = savePoints[savePoints.Count - 1];
        PlayerBehaviour.Instance.position.SetPlayerV3Position(lastSave.playerPosition.x, lastSave.playerPosition.y, lastSave.playerPosition.z);
        transform.position = lastSave.playerPosition;

        Debug.Log("Loaded last save at level " + lastSave.currentLevel);
        return lastSave;
    }

    // 删除上一个存档点（用于死亡后回溯）
    public void RemoveLastSave()
    {
        if (savePoints.Count > 0)
        {
            savePoints.RemoveAt(savePoints.Count - 1);
            Debug.Log("Last save point removed.");
        }
    }

}
