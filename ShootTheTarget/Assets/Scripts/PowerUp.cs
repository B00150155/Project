using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameManager gameManager;

    public Target target;
    void OnTriggerEnter(Collider other) {
        if(gameObject.CompareTag("2x")){
            if(other.CompareTag("Player")){
                Destroy(gameObject);
                gameManager.has2xPowerUp = true;
            }
        }else if (gameObject.CompareTag("Health")){
            if(other.CompareTag("Player")){
                Destroy(gameObject);
                gameManager.hasHealthPowerUp = true;
            }
        }
        
    }


    void Start(){
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update(){
       
        
    }

}
