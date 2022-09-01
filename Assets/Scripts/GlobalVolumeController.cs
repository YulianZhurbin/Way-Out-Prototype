using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeController : MonoBehaviour
{
    public ColorAdjustments colorAdjustments;

    public void Start()
    {
        GetComponent<Volume>().profile.TryGet(out colorAdjustments);
    }
    public float PostExposure
    {
        get { return colorAdjustments.postExposure.value; }
        set { colorAdjustments.postExposure.value = value; }
    }
}
