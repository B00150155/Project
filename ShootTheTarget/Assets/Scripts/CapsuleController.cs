using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{

    public FPSController fPSController;
    public Rigidbody player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        fPSController = GameObject.Find("Player").GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PowerUp")){
            //fPSController.hasPowerUp = true;
            Destroy(other.gameObject);
            Debug.Log("George");
        }    
    }
}
