using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player;
    bool isPaused;

    //public void TurnOffCanvas()
    //{
    //    StartCoroutine(DisactivateCanvas());
    //}

    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    private IEnumerator DisactivateCanvas()
    {
        yield return new WaitForSeconds(0.1f);
        //canvas.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }    

    public void ResumeGame()
    {
        //Time.timeScale = 1;
        Debug.Log("Resume game");
        pauseMenu.SetActive(false);
        LockMouse();
        player.SetActive(true);
        isPaused = false;
    }

    private void PauseGame()
    {
        //Time.timeScale = 0;
        Debug.Log("Pause game");
        pauseMenu.SetActive(true);
        UnlockMouse();
        player.SetActive(false);
        isPaused = true;
    }

    public void StopGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
