using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemehaviour : MonoBehaviour
{
    /// <summary>
    /// 存档系统
    /// </summary>

    public static SaveSystemehaviour Instance; // 单例模式

    [HideInInspector] public List<SaveData> savePoints = new List<SaveData>(); // 存档列表

    [SerializeField] GameObject initialSavePoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

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
        //Debug.Log("Game saved at level " + currentLevel);
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

    //设置为新游戏
    public void NewGame()
    {
        ClearSave();
        InitialSaveData();
        LoadLastSave();
    }

    //清除保存数据
    private void ClearSave()
    {
        savePoints.Clear();
    }

    private void InitialSaveData()
    {
        SaveGame(initialSavePoint.transform.position, 0);
        //Debug.Log("游戏初始化 坐标为 " + PlayerBehaviour.Instance.position.currentPlayerPosition);
        //Debug.Log(initialSavePoint.transform.position);
    }
}
