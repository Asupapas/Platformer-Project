using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button level02Button, level03Button, level04Button, level05Button;
    int levelPassed;
    // Start is called before the first frame update
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;
        level05Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                level02Button.interactable = true;
                break;
            case 2:
                level02Button.interactable = true;
                level03Button.interactable = true;
                break;
            case 3:
                level02Button.interactable = true;
                level03Button.interactable = true;
                level04Button.interactable = true;
                break;
            case 4:
                level02Button.interactable = true;
                level03Button.interactable = true;
                level04Button.interactable = true;
                level05Button.interactable = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelToLoad (int level)
    {
        SceneManager.LoadScene(level);
    }

    public void resetPlayerPref()
    {
        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;
        level05Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
    public void loadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    
    public void loadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void loadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    
    public void loadFinalLevel()
    {
        SceneManager.LoadScene("FinalLevel");
    }
}
