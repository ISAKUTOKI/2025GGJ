using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerGoBackZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Íæ¼Ò×²Ç½");
            PlayerBehaviour.Instance.move.MoveBackCells(1);
        }
    }
}
