using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoManager : MonoBehaviour
{
    public static LevelTwoManager instance;
    public bool isLevelTwoComp;
    private string sceneNameLvlThree = "LevelThree";

    private void Awake() {
        instance = this;
    }

    public void playerisDead() {
        GameManager.s_instance.changeGameState(GameState.GameOver);
    }
    public void levelTwoComplete() {
        GameManager.s_instance.changeGameState(GameState.LoadLevel);
        GameManager.s_instance.newLevelName(sceneNameLvlThree);
    }
}
