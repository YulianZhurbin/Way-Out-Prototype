using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropManager : MonoBehaviour
{
    [SerializeField] AudioClip[] dropSounds;
    [SerializeField] AudioSource audioSource;

    public void Play()
    {
        int soundIndex = Random.Range(0, dropSounds.Length);
        audioSource.PlayOneShot(dropSounds[soundIndex]);
    }
}
