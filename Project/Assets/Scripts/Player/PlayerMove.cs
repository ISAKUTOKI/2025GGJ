using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的移动系统
    /// </summary>

    public float moveSpeed = 5f; // 玩家移动速度
    private Rigidbody2D rb; // 玩家的 Rigidbody2D 组件

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

        if (moveInput > 0) // 向右移动
        {
            FlipRight();
        }
        else if (moveInput < 0) // 向左移动
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
