using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTextScript : MonoBehaviour
{
    Text text;
    public static int coinAmout;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinAmout > 0)
        {
            text.text = "SCORE: " + coinAmout.ToString();
        }
        

        if(coinAmout<0)
        {
            coinAmout = 0;
            SceneManager.LoadScene("MainMenu");
        }
        
        if (coinAmout==10 && SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");

            //PlayerPrefs.SetInt("score",coinAmout);
        }

        if (coinAmout >=40 && SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("EndMenu");

        }
    }
}
