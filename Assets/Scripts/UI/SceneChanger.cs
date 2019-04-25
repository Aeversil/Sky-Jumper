using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public GameObject Menu;
    private bool paused = false;

    //Hides the menu
    private void Start()
    {
       Menu.SetActive(false);
    }

    //Changes scene
    public void ChangeToScene (int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
        Time.timeScale = 1;
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Shows the menu and pause the game
    public void PauseGame()
    {
        paused = !paused;

        if (paused)
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            Menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //Hides the menu and resume the game
    public void ResumeGame()
    {

        //paused = paused;

        if (paused)
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            Menu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
