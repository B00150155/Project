using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{   
    Animator m_animator;
    AudioSource m_shootingSound;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_shootingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            m_animator.SetTrigger("Shoot");
            m_shootingSound.Play();
            muzzleFlash.Play();
        }
    }
}
