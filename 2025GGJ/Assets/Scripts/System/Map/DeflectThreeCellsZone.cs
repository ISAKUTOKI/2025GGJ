using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectThreeCellsZone : MonoBehaviour
{
    private bool canDeflect = false;

    private void Update()
    {
        if (!PlayerBehaviour.Instance.move.isMoving && canDeflect)
        {
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(2, PlayerBehaviour.Instance.move.deflectDirection));
            canDeflect = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Íæ¼Ò×²Ç½");
            canDeflect = true;
            PlayerBehaviour.Instance.move.MoveBack();
        }
    }
}
