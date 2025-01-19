using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /// <summary>
    /// ���ٿؽ�ɫ����Ծϵͳ
    /// </summary>

    [SerializeField] private float jumpForce=10.0f;
    private Rigidbody2D rb; // ��ҵ� Rigidbody2D ���

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
