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
            Debug.Log("����ƶ���ɣ�����������Ч��");
            PlayerBehaviour.Instance.move.currentMoveCoroutine = StartCoroutine(PlayerBehaviour.Instance.move.PlayerMoveCells(1, Vector3.down));
            playerCanBeBlew = false; // ���ñ�ǣ��ȴ���һ�δ���
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlew = true;
            Debug.Log("��ҽ����������");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCanBeBlew = false;
            Debug.Log("����뿪��������");
        }
    }
}
