using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWinFlag : MonoBehaviour
{
    int sceneIndex, levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sceneIndex == 3)
        {
            SceneManager.LoadScene("WinScreen");
        }
        else
        {
            if (levelPassed < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelPassed", sceneIndex);
                SceneManager.LoadScene("LevelSelect");
            }
            else
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
        
    }
}
