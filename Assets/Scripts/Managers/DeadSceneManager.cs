using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeadSceneManager : MonoBehaviour
{
   public void restartCurrentLevel() {
        GameManager.s_instance.restartGame();
    }
    public void mainMenu() {
        GameManager.s_instance.loadMainMenu();
    }
}
