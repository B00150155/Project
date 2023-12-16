using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button startButton;
    public Button restartButton;

    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    private FPSController fPSController;

    public List<GameObject> targetPrefabs;
    public List<GameObject> powerUps;

    private int score;

    private float spawnRate = 1.5f;
    public bool isGameActive;

    public bool has2xPowerUp;
    public bool hasHealthPowerUp;

   


    void Start(){
        fPSController = GameObject.Find("Player").GetComponent<FPSController>();
    }

    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnPowerUp());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        score = 0;

        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }

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
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {   
    
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (isGameActive)
        {
            if(health > numberOfHearts){
                health = numberOfHearts;
            }

            for (int i = 0; i < hearts.Length; i++){
                if(i < health){
                    hearts[i].sprite = FullHeart;
                }else{
                    hearts[i].sprite = EmptyHeart;
                }
                
                if(i < numberOfHearts){
                    hearts[i].enabled = true;
                }else{
                    hearts[i].enabled = false;
                }

                if(hasHealthPowerUp){
                    health++;
                    hasHealthPowerUp = false;
                }

                if (has2xPowerUp){
                    StartCoroutine(PowerupCountdownRoutine());
                }
            }

            if(health == 0){
                GameOver();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        
    }

     IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        has2xPowerUp = false;
    }

    IEnumerator SpawnPowerUp(){
        while(isGameActive){
            yield return new WaitForSeconds(30);
            int index = Random.Range(0, powerUps.Count);

            if(isGameActive){
                Instantiate(powerUps[index], RandomPowerSpawnPosition(), powerUps[index].transform.rotation);
            }
        }
    }

    Vector3 RandomPowerSpawnPosition()
    {
        float spawnPosX = Random.Range(-15, 5);  
        float spawnPosZ = Random.Range(15, -5); 

        Vector3 spawnPosition = new(spawnPosX, 1, spawnPosZ);
        return spawnPosition;

    }
}