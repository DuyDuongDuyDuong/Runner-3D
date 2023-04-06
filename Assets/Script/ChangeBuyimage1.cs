using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//40d
public class ChangeBuyimage1 : MonoBehaviour
{
    public Button myButton;
    public Sprite defaultImage;
    public Sprite newImage;
 
  
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        if ( FindObjectOfType<UiManager>()._Score < 30)
        {
          myButton.GetComponent<Image>().sprite =newImage ; // konh mua dc
        }
        else
        {
         
          
          myButton.GetComponent<Image>().sprite = defaultImage; // mua dc
        }
        
        
    }
}
