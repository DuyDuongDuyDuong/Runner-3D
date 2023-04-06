using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionOver : MonoBehaviour
{
       public static bool isGameOver;
       public GameObject gameOver;


       private void Awake()
       {
           isGameOver = false;
       }

       void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (isGameOver)
        {
            gameOver.SetActive(true);
        }
    }
    
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       // gameObject.SetActive(true);

    }
}
