using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemehaviour : MonoBehaviour
{
    /// <summary>
    /// �浵ϵͳ
    /// </summary>

    public static SaveSystemehaviour Instance; // ����ģʽ

    [HideInInspector] public List<SaveData> savePoints = new List<SaveData>(); // �浵�б�

    [SerializeField] GameObject initialSavePoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

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
        //Debug.Log("Game saved at level " + currentLevel);
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

    //����Ϊ����Ϸ
    public void NewGame()
    {
        ClearSave();
        InitialSaveData();
        LoadLastSave();
    }

    //�����������
    private void ClearSave()
    {
        savePoints.Clear();
    }

    private void InitialSaveData()
    {
        SaveGame(initialSavePoint.transform.position, 0);
        //Debug.Log("��Ϸ��ʼ�� ����Ϊ " + PlayerBehaviour.Instance.position.currentPlayerPosition);
        //Debug.Log(initialSavePoint.transform.position);
    }
}
