using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            DeadZoneBehaviour.instance.sectionIndex = 2;
            Debug.Log("se sumo el index");
        }
    }
}
