using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTerminator : MonoBehaviour
{
    [SerializeField] float timeBeforeFinalScreen = 15.0f;
    [SerializeField] float timeBeforeEnd = 12.0f;

    [SerializeField] GameObject finalScreen;
    [SerializeField] GameObject player;
    [SerializeField] GameObject uIInputManager;
    [SerializeField] GameObject pauseMenu;


    private void Start()
    {
        StartCoroutine(ShowFinalScreen());
    }

    private IEnumerator ShowFinalScreen()
    {
        yield return new WaitForSeconds(timeBeforeFinalScreen);
        finalScreen.SetActive(true);
        player.SetActive(false);
        uIInputManager.SetActive(false);
        pauseMenu.SetActive(false);
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(timeBeforeEnd);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
