using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossOneCellZone : MonoBehaviour
{
    private bool playerCanBeBlew;
    private void Update()
    {
        if (playerCanBeBlew && !PlayerBehaviour.Instance.move.isMoving)
        {
            Debug.Log("玩家移动完成，触发积雨云效果");
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(1, Vector3.down));
            playerCanBeBlew = false; // 重置标记，等待下一次触发
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlew = true;
            Debug.Log("玩家进入积雨云区");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlew = false;
            Debug.Log("玩家离开积雨云区");
        }
    }
}
