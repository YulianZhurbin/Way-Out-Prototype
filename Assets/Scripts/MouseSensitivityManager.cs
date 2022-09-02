using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MouseSensitivityManager : MonoBehaviour
{
    [SerializeField] FirstPersonController personContoller;

    public float mouseSensitivity = 0.2f;

    public void SetMouseSensitivity(float mouseSensitivity)
    {
        this.mouseSensitivity = mouseSensitivity;
    }

    public void SetRotationSpeed()
    {
        personContoller.RotationSpeed = mouseSensitivity;
    }
}
