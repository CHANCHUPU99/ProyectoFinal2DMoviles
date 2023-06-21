using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;


public class GameManager : MonoBehaviour
{
    public static GameManager s_instance;
    //public GameObject canvas;
    //public GameObject canvas2;
    [SerializeField] GameObject nextLevelI, youLoseI;
    [SerializeField] GameObject mainMenuPanel, creditsPanel;
    [SerializeField] GameObject playerSpawnPoint;
    private string n_newLevelScene;
    GameState m_gameState;
    public int levelIndex;

    void Awake()
    {
        if (FindObjectOfType<GameManager>() != null &&
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
                StartCoroutine(loadNextLevel());
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                StartCoroutine(gameOvertrue());
                //StartCoroutine(resetLevel());
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

    public IEnumerator gameOvertrue() {
        yield return new WaitForSeconds(2f);
        gameOver();
    }
    public void gameOver() {
        youLoseI.SetActive(true);
    }
    //public IEnumerator resetLevel() {
    //    yield return new WaitForSeconds(6);
    //    restartGame();
    //}
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        setPlayerSpawn();      
    }
    public GameState getGameState() {
        return m_gameState;
    }
    public void newLevelName(string t_newLevel) {
        n_newLevelScene = t_newLevel;
    }
    public void loadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public IEnumerator loadNextLevel() {
        levelIndex++;
        nextLevelI.SetActive(true);
        yield return new WaitForSeconds(5f);
        nextLevel();
    }
   
    private void nextLevel() {
        SceneManager.LoadScene(n_newLevelScene);
        setPlayerSpawn();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void finalCredits() {
        creditsPanel.SetActive(true);
    }
    private void setPlayerSpawn() {
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
    GameOver,
    Win
}