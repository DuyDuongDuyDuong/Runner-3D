using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroudCamera : MonoBehaviour
{
  
    public Color backgroundColor;

    void Start()
    {
         UnityEngine.Camera.main.backgroundColor = backgroundColor;
    }

    private void Update()
    {
        UnityEngine.Camera.main.backgroundColor = backgroundColor;
    }
}
