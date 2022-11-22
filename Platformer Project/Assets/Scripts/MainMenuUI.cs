using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
