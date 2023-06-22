using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Cinemachine;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    private string sceneNameLvlOne = "LevelOne";
    private string sceneNameLvlTwo = "LevelTwo";
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CinemachineVirtualCamera cmVirtualCamera;
    private void Awake() {
        GameManager.s_instance.changeGameState(GameState.Playing);
        instance = this;
        if(FindObjectOfType<PlayerManager1>() == null) {     
            Instantiate(playerPrefab);
        }
            GameManager.s_instance.setNewCurrentLevelName(sceneNameLvlOne);
            PlayerManager1.instance.changePlayerState(PlayerState.Idle);
            GameManager.s_instance.setPlayerSpawn();
        cmVirtualCamera.Follow = PlayerController2.instance.transform;
    }

    public void playerisDead() {
        GameManager.s_instance.changeGameState(GameState.GameOver);
    }
    public void levelOneComplete() {
        GameManager.s_instance.setNewCurrentLevelName(sceneNameLvlTwo);
        GameManager.s_instance.changeGameState(GameState.LevelComplete);
    }
}

