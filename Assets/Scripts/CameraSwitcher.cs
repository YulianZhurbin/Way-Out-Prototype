using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject prisonCamera;
    [SerializeField] GameObject prisonCameraVolume;

    private bool canPrCameraBeTurnedOff;

    Mouse mouse;
    Keyboard keyboard;

    private void Start()
    {
        mouse = Mouse.current;
        keyboard = Keyboard.current;
    }

    public void Switch()
    {
        player.SetActive(false);
        prisonCamera.SetActive(true);
        prisonCameraVolume.SetActive(true);
        StartCoroutine(Pause());
    }

    private void Update()
    {
        if (canPrCameraBeTurnedOff && (mouse.leftButton.wasPressedThisFrame || keyboard.anyKey.wasPressedThisFrame))
        {
            player.SetActive(true);
            prisonCamera.SetActive(false);
            canPrCameraBeTurnedOff = false;
            prisonCameraVolume.SetActive(false);
        }
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.2f);

        canPrCameraBeTurnedOff = true;
    }
}
