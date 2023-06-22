using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoManager : MonoBehaviour {
    public static LevelTwoManager instance;
    private string sceneNameLvlTwo = "LevelTwo";
    private string sceneNameLvlThree = "LevelThree";
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CinemachineVirtualCamera cmVirtualCamera;
    private void Awake() {
        GameManager.s_instance.changeGameState(GameState.Playing);
        instance = this;
        if (FindObjectOfType<PlayerManager1>() == null) {
            Instantiate(playerPrefab);
        }
        GameManager.s_instance.setNewCurrentLevelName(sceneNameLvlTwo);
        PlayerManager1.instance.changePlayerState(PlayerState.Idle);
        GameManager.s_instance.setPlayerSpawn();
        cmVirtualCamera.Follow = PlayerController2.instance.transform;
    }

    public void playerisDead() {
        GameManager.s_instance.changeGameState(GameState.GameOver);
    }
    public void levelTwoComplete() {
        GameManager.s_instance.setNewCurrentLevelName(sceneNameLvlThree);
        GameManager.s_instance.changeGameState(GameState.LevelComplete);
    }
}
