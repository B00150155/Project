using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHeart;
            } else
            {
                hearts[i].sprite = EmptyHeart;
            }
            
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }



    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bad")){
            Debug.Log("Fuck You");
        }
    }
}