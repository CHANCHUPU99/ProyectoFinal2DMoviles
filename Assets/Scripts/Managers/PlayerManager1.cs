using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PlayerManager1 : MonoBehaviour {
    /// <summary>
    /// Instncia publica de la clase PlayerManager
    /// </summary>
    public static PlayerManager1 instance;
    public GameManager gameManager;
    Animator animator;
    PlayerState playerState;

    void Awake() {
        if (FindObjectOfType<PlayerManager1>() != null &&
             FindObjectOfType<PlayerManager1>().gameObject != gameObject) {
            Destroy(gameObject);
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
            playerState = PlayerState.None;
        }
    }
        void Start() {
            animator = GetComponent<Animator>();
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
