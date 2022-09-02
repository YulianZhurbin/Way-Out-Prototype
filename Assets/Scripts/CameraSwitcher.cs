using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject prisonCamera;
    [SerializeField] GameObject prisonCameraVolume;
    [SerializeField] Volume globalVolume;

    private bool canPrCameraBeTurnedOff;

    Mouse mouse;
    Keyboard keyboard;
    MotionBlur motionBlur;

    private void Start()
    {
        mouse = Mouse.current;
        keyboard = Keyboard.current;
        globalVolume.GetComponent<Volume>().profile.TryGet(out motionBlur);
    }

    public void Switch()
    {
        player.SetActive(false);
        prisonCamera.SetActive(true);
        prisonCameraVolume.SetActive(true);
        motionBlur.active = false;
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
            motionBlur.active = true;
        }
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.2f);

        canPrCameraBeTurnedOff = true;
    }
}
