using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
   
    public Image[] lifeHearts;
    public TextMeshProUGUI _TextScore;
    public   int _Score = 0;

    
    private void Start()
    {
        _Score = PlayerPrefs.GetInt("_Score");
       
        
    }

    private void Update()
    {
        _TextScore.text = " " + _Score;
        PlayerPrefs.SetInt("_Score", _Score);
       
       
    }


    public  void UpdateLives(int life)
    {
        for (int i = 0; i < lifeHearts.Length; i++)
        {
            if (life >i)
            {
                lifeHearts[i].color = Color.white;
               
            }
            else
            {
                
                lifeHearts[i].color = Color.black;
            }
            
        }
        
    }
    
    

 
}
