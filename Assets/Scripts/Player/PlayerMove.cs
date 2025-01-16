using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ���ƶ�ϵͳ
    /// </summary>

    public float moveSpeed = 5f; // ����ƶ��ٶ�
    private Rigidbody2D rb; // ��ҵ� Rigidbody2D ���

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FlipCheck();
    }

    private void FlipCheck()
    {
        float moveInput = Input.GetAxis("Horizontal");

        Vector2 velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        rb.velocity = velocity;

        if (moveInput > 0) // �����ƶ�
        {
            FlipRight();
        }
        else if (moveInput < 0) // �����ƶ�
        {
            FlipLeft();
        }
    }

    private void FlipRight()
    {
        PlayerBehaviour.Instance.view.transform.localScale = new Vector3(1, 1, 1);
    }

    private void FlipLeft()
    {
        PlayerBehaviour.Instance.view.transform.localScale = new Vector3(-1, 1, 1);
    }
}
