using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlowRightZone : MonoBehaviour
{
    private bool playerCanBeBlewToRight;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume = 1.0f;
    [SerializeField] private int moveCellCount;

    private void Update()
    {
        if (playerCanBeBlewToRight && !PlayerBehaviour.Instance.move.isMoving)
        {
            AudioSystemBehaviour.Instance.PlayerSound(clip, volume);
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(moveCellCount, Vector3.right));
            playerCanBeBlewToRight = false; // 重置标记，等待下一次触发
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlewToRight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlewToRight = false;
        }
    }
}
