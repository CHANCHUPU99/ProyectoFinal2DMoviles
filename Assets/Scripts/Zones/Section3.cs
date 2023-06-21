using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            DeadZoneBehaviour.instance.sectionIndex = 3;
            Debug.Log("se sumo el index");
        }
    }
}
