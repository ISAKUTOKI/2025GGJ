using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    private int CrossedCount;
    private bool isStayIn;
    private bool haveGotIn;
    private float reduceCountTimer = 3f;

    private void Start()
    {
        CrossedCount = 0;
        isStayIn = false;
        haveGotIn = false;
    }
    private void Update()
    {
        if (haveGotIn && !isStayIn)
        {
            reduceCountTimer -= Time.deltaTime;
        }

        if (reduceCountTimer <= 0)
        {
            Debug.Log("��������");
            CrossedCount = 0;
            haveGotIn = false;
        }

        if (CrossedCount == 2)
        {
            PlayerBehaviour.Instance.health.Die();
            Debug.Log("�G����ô����");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            CrossedCount += 1;
            Debug.Log(CrossedCount);
            isStayIn = true;
            haveGotIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isStayIn = false;
        }
    }
}
