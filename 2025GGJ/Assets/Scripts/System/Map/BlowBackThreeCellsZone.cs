using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowBackThreeCellsZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour.Instance.move.MoveBack();
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(2, PlayerBehaviour.Instance.move.currentMoveDirection * -1));
        }
    }
}
