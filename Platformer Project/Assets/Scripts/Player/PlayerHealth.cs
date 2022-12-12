using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public Slider slider;
    Rigidbody2D rb;
    bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        if(otherTag == "Enemy")
        { 
                health--;
                slider.value = health;
                if (health <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
            
            }
        if (collision.gameObject.tag == "Lava")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    }

