using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skinimage : MonoBehaviour
{
 
  
  
  
  public Button myButtonClick;
  public  GameObject skinToEquip;

  public void BuySkin40()
  {
    if ( FindObjectOfType<UiManager>()._Score>= 30 )
    {
      
      Skin.skinToLoad = skinToEquip;
      myButtonClick.interactable = true;
      FindObjectOfType<UiManager>()._Score -= 30;
   

     

    }
    else
    {
      myButtonClick.interactable = false;
    }
    
  }
  
  public void BuySkin0()
  {
    Skin.skinToLoad = skinToEquip;
      myButtonClick.interactable = true;
  }
  
  public void BuySkin70()
  {
    if ( FindObjectOfType<UiManager>()._Score>= 50 )
    {
      Skin.skinToLoad = skinToEquip;
      myButtonClick.interactable = true;
      FindObjectOfType<UiManager>()._Score -= 50;
    
      
      Debug.Log(" mua dc");
    }
    else
    {
     myButtonClick.interactable = false;
     Debug.Log(" k dc");
    }
    
  }


 



}
