using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Config", menuName = "Guns/Audio Config", order = 5)]

public class AudioConfig : ScriptableObject
{
    [Range (0, 1f)]
    public float Volume = 1f;
    public AudioClip[] FireClips;

    public void PlayShootingClip(AudioSource AudioSource){
        AudioSource.PlayOneShot(FireClips[Random.Range(0, FireClips.Length)], Volume);
    }
}
