using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void OnPlayPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void OnQuitPressed()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void OnNextPressed()
    {
        int a = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        if(a+1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(a + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
