using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetX : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    public int pointValue;

    public float timeOnScreen = 1.0f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        transform.position = RandomSpawnPosition(); 
 

    }

    // When target is clicked, destroy it, update score, and generate explosion
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            if(gameObject.CompareTag("Bad")){
                Debug.Log("Fuck You");
                gameManager.health --;
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

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex ()
    {
        return Random.Range(0, 4);
    }


    // If target that is NOT the bad object collides with sensor, trigger game over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") /*&& !gameObject.CompareTag("Bad")*/)
        {
            gameManager.GameOver();
        } 

    }

    // Display explosion particle at object's position
    /*void Explode ()
    {
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
    }*/

    // After a delay, Moves the object behind background so it collides with the Sensor object
    IEnumerator RemoveObjectRoutine ()
    {
        yield return new WaitForSeconds(timeOnScreen);
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }

    }

}
