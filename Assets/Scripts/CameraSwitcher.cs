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

    private bool isPrisonCameraUsed;
    //private bool isFirstFrame = true;
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
        isPrisonCameraUsed = true;
        prisonCameraVolume.SetActive(true);
    }

    private void Update()
    {
        if (isPrisonCameraUsed && (mouse.leftButton.wasPressedThisFrame || keyboard.anyKey.wasPressedThisFrame))
        {
            player.SetActive(true);
            prisonCamera.SetActive(false);
            isPrisonCameraUsed = false;
            prisonCameraVolume.SetActive(false);
        }
    }
}
