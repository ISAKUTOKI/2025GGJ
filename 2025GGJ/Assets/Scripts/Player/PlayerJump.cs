using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的跳跃系统
    /// </summary>

    [SerializeField] private float jumpForce=10.0f;
    private Rigidbody2D rb; // 玩家的 Rigidbody2D 组件

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W) && PlayerBehaviour.Instance.groundCheck.isOnGround)
        //{
        //    Jump();
        //}
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


}
