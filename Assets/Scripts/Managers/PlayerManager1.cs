using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager1 : MonoBehaviour
{
    /// <summary>
    /// Instncia publica de la clase PlayerManager
    /// </summary>
    public static PlayerManager1 instance;
    Animator animator;
    PlayerState playerState;

    void Awake()
    {
        instance = this;
        playerState = PlayerState.None;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

    }
    public void changePlayerState(PlayerState newState)
    {
        playerState = newState;
        switch (playerState)
        {
            case PlayerState.None:
                break;
            case PlayerState.Idle:
                animator.SetBool("IsIdleing", true);
                break;
            case PlayerState.Running:
                animator.SetBool("IsRunning", true);
                break;
        }
    }
}

public enum PlayerState
{
    None,
    Idle,
    Running
}
