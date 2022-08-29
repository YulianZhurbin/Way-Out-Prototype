using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ExitPostProcessing : MonoBehaviour
{
    Bloom bloom;
    bool isPlayerEntered;

    void Start()
    {
        Volume exitVolume = GetComponent<Volume>();

        exitVolume.profile.TryGet(out bloom);
    }

    void Update()
    {
        if(isPlayerEntered == true)
        {
            bloom.intensity.value -= Time.deltaTime * 50;
            bloom.scatter.value -= Time.deltaTime * 0.075f;

            if(bloom.scatter.value < 0.7)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerEntered = true;
            bloom.intensity.value = 200.0f;
            bloom.scatter.value = 1.0f;
        }
    }
}
