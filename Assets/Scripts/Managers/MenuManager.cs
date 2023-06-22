using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {
    private string levelOne = "LevelOne";
    public void startGame() {
       // SceneManager.LoadScene(levelOne);
        GameManager.s_instance.newLevelName(levelOne);
        GameManager.s_instance.changeGameState(GameState.LoadLevel);
    }
    public void exitGame() {
        Application.Quit();
        Debug.Log("Se salio");
    }
}
