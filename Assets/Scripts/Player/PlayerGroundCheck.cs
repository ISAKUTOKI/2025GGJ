using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ�ĵ�����ϵͳ
    /// </summary>

    [HideInInspector]public bool isOnGround;

    private void Start()
    {
        isOnGround = false;
    }

    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = false;
    }

    private void GroundCheckDebug()
    {
        if (isOnGround) Debug.Log("�ڵ���");
        if (!isOnGround) Debug.Log("���ڵ���");
    }
}
