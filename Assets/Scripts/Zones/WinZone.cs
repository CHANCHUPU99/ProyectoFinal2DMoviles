using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            
            LevelManager.instance.levelOneComplete(); 
            gameObject.SetActive(false);
            LevelManager.instance.isLevelOneComp = true;
           
        }
    }
}
