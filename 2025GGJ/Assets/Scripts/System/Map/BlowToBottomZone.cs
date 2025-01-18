using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowToBottomZone : MonoBehaviour
{
    [SerializeField] private Vector3 BlowToDirection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            while (PlayerBehaviour.Instance.move.isBackMoved == false)
            {
                PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(1, BlowToDirection));
            }
        }
    }
}
