using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public bool isLevelOneComp;
    public bool isLevelTwoComp;
    public bool isLevelThreeComp;
    private string sceneNameLvlOne = "SampleScene";
    private string sceneNameLvlTwo = "LevelTwo";
    private string sceneNameLvlThree = "LevelThree";

    private void Awake() {
        instance = this;
    }
    
    public void playerisDead() {
        GameManager.s_instance.changeGameState(GameState.GameOver);
    }
    public void levelOneComplete() {
            GameManager.s_instance.changeGameState(GameState.LoadLevel);
            GameManager.s_instance.newLevelName(sceneNameLvlTwo);
    }
    public void levelTwoComplete() {
        GameManager.s_instance.changeGameState(GameState.LoadLevel);
        GameManager.s_instance.newLevelName(sceneNameLvlThree);
    }
    public void levelThreeComplete() {
        GameManager.s_instance.newLevelName(sceneNameLvlThree);
    }
}

