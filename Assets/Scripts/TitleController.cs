using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleController : MonoBehaviour
{
    [SerializeField] TMP_Text title;

    private void OnEnable()
    {
        title.alpha = 0;
        StartCoroutine(MakeVisible());
    }

    private IEnumerator MakeVisible()
    {
        while (title.alpha < 1)
        {
            yield return new WaitForEndOfFrame();
            title.alpha += Time.deltaTime;
        }
    }
}
