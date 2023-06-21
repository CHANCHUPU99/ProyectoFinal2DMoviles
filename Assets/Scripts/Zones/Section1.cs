using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            DeadZoneBehaviour.instance.sectionIndex = 1;
            //Debug.Log("se sumo el index");
        }
    }
}
