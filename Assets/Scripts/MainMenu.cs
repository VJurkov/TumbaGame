using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        ScoreTextScript.coinAmout = 0;
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Single);
    }

    public void StoryMenu()
    {
        SceneManager.LoadScene("StoryMenu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
