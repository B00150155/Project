using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Debug.Log("George");
        }
    }
}
