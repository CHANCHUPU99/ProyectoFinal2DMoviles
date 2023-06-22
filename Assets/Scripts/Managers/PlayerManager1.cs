using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerManager1 : MonoBehaviour {
   
    public static PlayerManager1 instance;
    //public GameObject cmVirtualCamera;
    Animator animator;
    PlayerState playerState;

    void Awake() {
        animator = GetComponent<Animator>(); animator = GetComponent<Animator>();
        if ((FindObjectOfType<PlayerManager1>() != null) &&
             FindObjectOfType<PlayerManager1>().gameObject != gameObject) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        instance = this;
    }
    void Start() {
        playerState = PlayerState.Idle;

    }

    public void changePlayerState(PlayerState newState) {
        if (playerState == newState) {
            return;
        }
        resetAnimatorParameters();
        playerState = newState;
        switch (playerState) {
            case PlayerState.None:
                break;
            case PlayerState.Idle:
                animator.SetBool("IsIdleing", true);
                break;
            case PlayerState.Running:
                animator.SetBool("IsRunning", true);
                break;
            case PlayerState.Jump:
                animator.SetBool("IsJumping", true);
                break;
            case PlayerState.JumpFall:
                animator.SetBool("IsFalling", true);
                break;
            case PlayerState.FreeFall:
                animator.SetBool("IsFalling", true);
                break;
            case PlayerState.Dead:
                animator.SetBool("IsDead", true);
                //StartCoroutine(gameManager.LoadImage());
                break;
        }
    }

    private void resetAnimatorParameters() {
        foreach (AnimatorControllerParameter parameter in animator.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Bool) {
                animator.SetBool(parameter.name, false);
            }
        }
    }

}

public enum PlayerState {
    None,
    Idle,
    Running,
    Jump,
    JumpFall,
    FreeFall,
    Dead
}
