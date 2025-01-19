using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private bool isStayInKillZone = false;
    private float stayInKillTimer = 0.2f;
    [HideInInspector] public bool isMustBeKilled = false;

    private void Update()
    {
        if (isStayInKillZone)
            stayInKillTimer -= Time.deltaTime;

        if (stayInKillTimer <= 0)
            isMustBeKilled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isStayInKillZone = true;
            PlayerBehaviour.Instance.health.TryToDie();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isStayInKillZone = false;
        }
    }
}
