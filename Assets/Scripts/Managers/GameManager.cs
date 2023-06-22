using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;


public class GameManager : MonoBehaviour {
    public static GameManager s_instance;
    //public GameObject canvas;
    //public GameObject canvas2;
    [SerializeField] GameObject nextLevelI, youLoseI;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject playerSpawnPoint;
    private string newLevelScene;
    GameState m_gameState;
    public string currentLevel;


    void Awake() {
        if ((FindObjectOfType<GameManager>() != null) &&
           FindObjectOfType<GameManager>().gameObject != gameObject) {
            Destroy(gameObject);
            return;
        }
        s_instance = this;
        m_gameState = GameState.Playing;
        DontDestroyOnLoad(gameObject);
    }

    public void changeGameState(GameState newGameState) {
        if (m_gameState == newGameState) {
            return;
        }
        m_gameState = newGameState;
        switch (m_gameState) {
            case GameState.None:
                break;
            case GameState.LoadMainMenu:
                loadMainMenu();
                break;
            case GameState.MainMenu:
                loadMainMenu();
                break;
            case GameState.LoadLevel:
                startLevel();
                break;
            case GameState.Playing:
                break;
            case GameState.LevelComplete:
                nextLevel();
                break;
            case GameState.GameOver:
               gameOver();
                break;
            case GameState.Win:
                finalCredits();
                break;
            default:
                throw new UnityException("null Game State");
        }
    }
 

    public void changeGameStateFromEditor(string newState) {
        changeGameState((GameState)System.Enum.Parse(typeof(GameState), newState));
    }

    public void startGame() {
        changeGameState(GameState.Playing);
    }

    public void gameOver() {
        SceneManager.LoadScene("YouLoseScene");
    }
 
    public void restartGame() {
        SceneManager.LoadScene(currentLevel);
        setPlayerSpawn();
    }
    public GameState getGameState() {
        return m_gameState;
    }
    public void newLevelName(string t_newLevel) {
        newLevelScene = t_newLevel;
    }
    public void setNewCurrentLevelName(string newCurrentL) {
        currentLevel = newCurrentL;
    }
    public void loadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    private void nextLevel() {
        SceneManager.LoadScene(currentLevel);
        setPlayerSpawn();
    }
    private void startLevel() {
        SceneManager.LoadScene(newLevelScene);
        setPlayerSpawn();
    }
    private void finalCredits() {
        creditsPanel.SetActive(true);
    }
    public void setPlayerSpawn() {
        PlayerManager1.instance.transform.position = playerSpawnPoint.transform.position;
    }
    //lo que ya tenia 
    //public IEnumerator LoadImage()
    //{
    //    yield return new WaitForSeconds(1f);
    //    LoadYouLose();
    //}
    //public void LoadYouLose()
    //{
    //    canvas.SetActive(true);
    //    Debug.Log("se murio");
    //}

    //public void YouWin()
    //{
    //    canvas2.SetActive(true);
    //    Debug.Log("Ganaste");
    //}

}

public enum GameState {
    None,
    LoadMainMenu,
    MainMenu,
    LoadLevel,
    Playing,
    LevelComplete,
    GameOver,
    Win
}