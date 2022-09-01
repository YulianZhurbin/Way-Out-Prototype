using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeChanger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (audioSource.gameObject.activeInHierarchy)
            {
                StartCoroutine(IncreaseVolume());
            }
            else
            {
                StartCoroutine(AssignAudioSource());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.volume = 0.5f;
        }
    }

    private IEnumerator IncreaseVolume()
    {
        while (audioSource.volume < 0.5)
        {
            yield return new WaitForFixedUpdate();
            audioSource.volume += Time.fixedDeltaTime * 0.25f;
        }
    }

    private IEnumerator AssignAudioSource()
    {
        Debug.Log("AssignAudioSource()");
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(IncreaseVolume());
    }
}
