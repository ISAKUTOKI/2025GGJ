using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlowDownZone : MonoBehaviour
{
    private bool playerCanBeBlewToBottom;
    [SerializeField] private int moveCellCount;

    private void Update()
    {
        if (playerCanBeBlewToBottom && !PlayerBehaviour.Instance.move.isMoving)
        {
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(moveCellCount, Vector3.down));
            playerCanBeBlewToBottom = false; // 重置标记，等待下一次触发
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlewToBottom = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlewToBottom = false;
        }
    }
}
