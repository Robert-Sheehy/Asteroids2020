using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutTextHere : MonoBehaviour
{

    Text testText;

    // Start is called before the first frame update
    void Start()
    {
        
        //Manager_Script.FindObjectsOfType<List<Asteroid_Control>>

        testText = FindObjectOfType<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void numberOfAsteroidsIs(int count)
    {
        testText.text = count.ToString();
    }
}
