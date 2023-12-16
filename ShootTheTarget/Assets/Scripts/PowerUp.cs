using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{


  
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Destroy(gameObject);
            Debug.Log("George");
        }
    }

    void Start(){
    }

    void Update(){
       
        
    }

}
