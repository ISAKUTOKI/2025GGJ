using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoilingBarBehaviour : MonoBehaviour
{
    [SerializeField] public List<GameObject> boilingTimerBarList; // 沸腾条列表
    private List<Image> boilingTimerBarImageList; // 沸汤条图像列表
    public List<int> boilingTimerTotalCount; // 沸腾条每一格的总计数

    private bool boilingBarIsEmpty = false; // 是否所有物体都已失效

    void Start()
    {
        InitializeLists(); // 初始化三条
        ShowCurrentBars(); // 初始化显示
    }

    // 初始化列表
    private void InitializeLists()
    {
        boilingTimerBarImageList = new List<Image>();

        foreach (var bar in boilingTimerBarList)
        {
            boilingTimerBarImageList.Add(bar.GetComponent<Image>());
        }

        if (boilingTimerBarList.Count != boilingTimerTotalCount.Count || boilingTimerBarList.Count != boilingTimerBarImageList.Count)
        {
            Debug.LogError("列表元素数量不一致！");
        } // 总数检查。虽然没什么用
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
            OnBoilingBarEmpty(); // 调用沸腾条为空时的逻辑
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
                OnBoilingBarEmpty(); // 调用沸腾条为空时的逻辑
            } // 当总条数小于等于0时，
        }

        return boilingBarIsEmpty;
    }

    // 当沸腾条为空时调用
    private void OnBoilingBarEmpty()
    {
        if (boilingBarIsEmpty)
        {
            // 检查 PlayerBehaviour.Instance 和 PlayerBehaviour.Instance.health 是否为 null
            if (PlayerBehaviour.Instance != null && PlayerBehaviour.Instance.health != null)
            {
                PlayerBehaviour.Instance.health.TryToDie();
            }
            else
            {
                Debug.LogWarning("PlayerBehaviour.Instance 或 PlayerBehaviour.Instance.health 为 null，无法调用 TryToDie。");
            }
        }
    }
}