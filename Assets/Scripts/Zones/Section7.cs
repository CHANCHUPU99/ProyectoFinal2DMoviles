using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section7 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            DeadZoneBehaviour.instance.sectionIndex = 7;
            Debug.Log("se sumo el index");
        }
    }
}
