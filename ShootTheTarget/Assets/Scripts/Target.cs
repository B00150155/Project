using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

 

    public int pointValue;
    public int penalty = -200;

    public float timeOnScreen = 1.0f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        transform.position = RandomSpawnPosition(); 
 

    }

    // When target is clicked, destroy it, update score
    private void OnMouseDown()
    {
        if (gameManager.isGameActive){
            Destroy(gameObject);
            if(gameObject.CompareTag("Bad")){
                gameManager.health --;
            } 
            

            if(gameManager.has2xPowerUp){
                pointValue = 2*pointValue;
            }  

            gameManager.UpdateScore(pointValue);

        }
               
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-15, 5); 
        float spawnPosZ = Random.Range(15, -5); 

        Vector3 spawnPosition = new Vector3(spawnPosX, 10, spawnPosZ);
        return spawnPosition;

    }




    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor"))
        {
            gameManager.UpdateScore(penalty);
        } 

    }

    

}
