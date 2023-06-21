using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeManager : MonoBehaviour
{
    public static LevelThreeManager instance;
    public bool isLevelThreeComp;
    private string sceneNameLvlThree = "LevelThree";

    private void Awake() {
        instance = this;
    }

    public void playerisDead() {
        GameManager.s_instance.changeGameState(GameState.GameOver);
    }
    public void levelThreeComplete() {
        GameManager.s_instance.newLevelName(sceneNameLvlThree);
    }
}
