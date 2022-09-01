using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDelayer : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;

    private void Start()
    {
        ActivateMainMenu();
    }

    public void ActivateMainMenu()
    {
        StartCoroutine(ShowMainMenu());
    }

    private IEnumerator ShowMainMenu()
    {
        yield return new WaitForSeconds(2.0f);

        mainMenu.SetActive(true);
    }
}
