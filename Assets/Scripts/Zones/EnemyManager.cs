using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("ya perdio");
            PlayerManager1.instance.changePlayerState(PlayerState.Dead);
            LevelManager.instance.playerisDead();
            LevelTwoManager.instance.playerisDead();
        }
    }
}
