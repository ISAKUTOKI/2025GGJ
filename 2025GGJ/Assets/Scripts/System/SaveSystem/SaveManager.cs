using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    /// <summary>
    /// �浵ϵͳ
    /// </summary>

    public static SaveManager Instance; // ����ģʽ

    private List<SaveData> savePoints = new List<SaveData>(); // �浵�б�

    private void Awake()
    {
            Instance = this;
    }

    // �����浵��
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

    // ������һ���浵��
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

    // ɾ����һ���浵�㣨������������ݣ�
    public void RemoveLastSave()
    {
        if (savePoints.Count > 0)
        {
            savePoints.RemoveAt(savePoints.Count - 1);
            Debug.Log("Last save point removed.");
        }
    }

}
