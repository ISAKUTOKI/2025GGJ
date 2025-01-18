using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private int CrossedCount;
    private bool isStayIn;
    private float reduceCountTimer = 0.15f;

    private void Start()
    {
        CrossedCount = 0;
        isStayIn = false;
    }
    private void Update()
    {
        if (!isStayIn)
            reduceCountTimer -= Time.deltaTime;

        if (reduceCountTimer <= 0)
            Debug.Log("计数清零");
            CrossedCount = 0;

        if (CrossedCount == 2)
        {
            PlayerBehaviour.Instance.health.Die();
            Debug.Log("欸你怎么似了");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CrossedCount++;
        isStayIn = true;
        Debug.Log(CrossedCount);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStayIn = false;
    }
}
