using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StartPostProcessing : MonoBehaviour
{
    Vignette vignette;
    WhiteBalance whiteBalance;

    void Start()
    {
        Volume startVolume = GetComponent<Volume>();

        startVolume.profile.TryGet(out vignette);
        vignette.intensity.value = 1.0f;

        startVolume.profile.TryGet(out whiteBalance);
        whiteBalance.temperature.value = 100.0f;
    }

    void Update()
    {
        vignette.intensity.value -= Time.deltaTime / 3;

        whiteBalance.temperature.value -= Time.deltaTime * 30;

        if(whiteBalance.temperature.value < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
