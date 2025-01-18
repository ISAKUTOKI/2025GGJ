using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendZone : MonoBehaviour
{
    private bool playerMoveCanBeExtended;
    private void Update()
    {
        if (playerMoveCanBeExtended && !PlayerBehaviour.Instance.move.isMoving)
        {
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(1, PlayerBehaviour.Instance.move.currentDirection));
            playerMoveCanBeExtended = false; // ���ñ�ǣ��ȴ���һ�δ���
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMoveCanBeExtended = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMoveCanBeExtended = false;
        }
    }

}
