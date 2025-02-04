using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// 所操控角色的总系统
    /// </summary>

    public static PlayerBehaviour Instance;

    public PlayerMove move { get; private set; }

    //public PlayerJump jump { get; private set; }

    //public PlayerGroundCheck groundCheck { get; private set; }

    public PlayerPosition position { get; private set; }

    public PlayerHealthBehaviour health { get; private set; }

    public PlayerSound playerSound { get; private set; }

    public PlayerAnimator playerAnimator { get; private set; }

    public Animator animator { get; private set; }


    public GameObject view;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        move = GetComponent<PlayerMove>();
        //jump = GetComponent<PlayerJump>();
        //groundCheck = GetComponentInChildren<PlayerGroundCheck>();
        position = GetComponent<PlayerPosition>();
        health = GetComponent<PlayerHealthBehaviour>();
        playerSound = GetComponent<PlayerSound>();
        playerAnimator = GetComponent<PlayerAnimator>();
        animator = GetComponentInChildren<Animator>();
    }

}
