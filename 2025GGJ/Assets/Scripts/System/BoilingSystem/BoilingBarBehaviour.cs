using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingBarBehaviour : MonoBehaviour
{
    [SerializeField] public List<GameObject> boilingTimerBarList; // �������б�
    private List<Image> boilingTimerBarImageList; // ������ͼ���б�
    public List<int> boilingTimerTotalCount; // ������ÿһ����ܼ���

    private bool boilingBarIsEmpty = false; // �Ƿ��������嶼��ʧЧ

    void Start()
    {
        InitializeLists(); // ��ʼ������
        ShowCurrentBars(); // ��ʼ����ʾ
    }

    // ��ʼ���б�
    private void InitializeLists()
    {
        boilingTimerBarImageList = new List<Image>();

        foreach (var bar in boilingTimerBarList)
        {
            boilingTimerBarImageList.Add(bar.GetComponent<Image>());
        }

        if (boilingTimerBarList.Count != boilingTimerTotalCount.Count || boilingTimerBarList.Count != boilingTimerBarImageList.Count)
        {
            Debug.LogError("�б�Ԫ��������һ�£�");
        } // ������顣��Ȼûʲô��
    }

    private void ShowCurrentBars()
    {
        for (int i = 0; i < boilingTimerBarList.Count; i++)
        {
            boilingTimerBarList[i].SetActive(i == 0 || i == 1);
        }
    }

    public bool CurrentFullBarDropBy(int dropByCount)
    {
        if (boilingBarIsEmpty || boilingTimerBarList.Count == 0)
        {
            boilingBarIsEmpty = true;
            OnBoilingBarEmpty(); // ���÷�����Ϊ��ʱ���߼�
            return boilingBarIsEmpty;
        }

        Image currentImage = boilingTimerBarImageList[0];
        int currentTotalCount = boilingTimerTotalCount[0];

        float fillAmountReduction = (float)dropByCount / currentTotalCount;
        currentImage.fillAmount = Mathf.Clamp(currentImage.fillAmount - fillAmountReduction, 0, 1);

        if (currentImage.fillAmount <= 0)
        {
            boilingTimerBarList.RemoveAt(0);
            boilingTimerBarImageList.RemoveAt(0);
            boilingTimerTotalCount.RemoveAt(0);

            if (boilingTimerBarList.Count > 0)
            {
                ShowCurrentBars();
            }
            else
            {
                boilingBarIsEmpty = true;
                OnBoilingBarEmpty(); // ���÷�����Ϊ��ʱ���߼�
            } // ��������С�ڵ���0ʱ��
        }

        return boilingBarIsEmpty;
    }

    // ��������Ϊ��ʱ����
    private void OnBoilingBarEmpty()
    {
        if (boilingBarIsEmpty)
        {
            // ��� PlayerBehaviour.Instance �� PlayerBehaviour.Instance.health �Ƿ�Ϊ null
            if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.health != null)
            {
                PlayerBehaviour.Instance.health.TryToDie();
            }
            else
            {
                Debug.LogWarning("PlayerBehaviour.Instance �� PlayerBehaviour.Instance.health Ϊ null���޷����� TryToDie��");
            }
        }
    }
}