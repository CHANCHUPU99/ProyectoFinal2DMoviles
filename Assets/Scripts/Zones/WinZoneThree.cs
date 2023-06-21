using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneThree : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {

            LevelManager.instance.levelThreeComplete();
            gameObject.SetActive(false);
            LevelManager.instance.isLevelThreeComp = true;
        }
    }
}
