using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEnabler : MonoBehaviour
{
    [SerializeField] GameObject soundToEnable;
    [SerializeField] GameObject soundToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!soundToEnable.activeInHierarchy)
            {
                soundToEnable.SetActive(true);
            }

            if (soundToDisable.activeInHierarchy)
            {
                soundToDisable.SetActive(false);
            }
        }
    }
}
