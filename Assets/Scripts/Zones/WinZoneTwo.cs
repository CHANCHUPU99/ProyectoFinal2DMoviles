using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneTwo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {

            LevelManager.instance.levelTwoComplete();
            gameObject.SetActive(false);
            LevelManager.instance.isLevelTwoComp = true;
        }
    }
}