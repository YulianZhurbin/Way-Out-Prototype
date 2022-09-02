using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    [SerializeField] float terminalVolume = 1.0f;

    private AudioSource audioSource;


    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        StartCoroutine(IncreaseVolume());
    }

    public void TurnOffMusic()
    {
        StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        while(audioSource.volume < terminalVolume)
        {
            yield return new WaitForEndOfFrame();

            audioSource.volume += Time.deltaTime * 0.5f;
        }
    }    
    
    private IEnumerator DecreaseVolume()
    {
        while(audioSource.volume > 0)
        {
            yield return new WaitForEndOfFrame();

            audioSource.volume -= Time.deltaTime;
        }

        gameObject.SetActive(false);
    }
}
