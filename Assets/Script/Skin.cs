using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public static GameObject skinToLoad;
    
   public GameObject defauSkin;


    private void Awake()
    {
    
        if (skinToLoad != null)
        {
           defauSkin.SetActive(false);
            Instantiate(skinToLoad, transform);
        }
      
    }
    
}
