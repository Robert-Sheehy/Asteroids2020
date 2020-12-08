using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutTextHere : MonoBehaviour
{
    Text testText;
    Text shipText;

    // Start is called before the first frame update
    void Start()
    {

        GameObject newGO = new GameObject("myTextGO");
        newGO.transform.SetParent(this.transform);
        Text myText = newGO.AddComponent<Text>();
        myText.text = "Ta-dah!";
       
        //Manager_Script.FindObjectsOfType<List<Asteroid_Control>>

        testText = FindObjectOfType<Text>();
        shipText = FindObjectOfType<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void numberOfAsteroidsIs(int count)
    {
        testText.text = count.ToString();
    }

    internal Text createText(string text_start)
    {

        GameObject newGO = new GameObject("myTextGO");
        newGO.transform.SetParent(this.transform);
        Text myText = newGO.AddComponent<Text>();
        myText.text = text_start;

        return myText;
    }

    internal void healthOfShipIs(int health)
    {
        shipText.text = health.ToString();
    }

}
