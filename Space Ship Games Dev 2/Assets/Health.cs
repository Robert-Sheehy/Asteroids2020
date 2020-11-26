using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    TextMeshPro ourHealthDisplay;
    internal int health = 100;
    bool isDisplayed = true;

    Asteroid_Control my_asteroid;

    //TMPro Text health_Display;
    // Start is called before the first frame update
    void Start()
    {

        my_asteroid = gameObject.GetComponent<Asteroid_Control>();
        GameObject newGO = new GameObject("Health Text");
        newGO.transform.parent = transform;

        newGO.transform.localPosition = new Vector3(0, 8, 0);
        ourHealthDisplay = newGO.AddComponent<TextMeshPro>();
        if (ourHealthDisplay)
        { ourHealthDisplay.text = health.ToString(); }
        else print("Warning: No TMP component found");

        
        ourHealthDisplay.rectTransform.sizeDelta = new Vector2(10, 20);
        //ourHealthDisplay.transform.position = new Vector3(0, 8, 0);
        ourHealthDisplay.alignment = TextAlignmentOptions.Top;

        ourHealthDisplay.enabled = isDisplayed;
    }

    // Update is called once per frame
    void Update()
    {
        ourHealthDisplay.transform.position = transform.position + 8 * Camera.main.transform.up;
        ourHealthDisplay.transform.rotation =
            Quaternion.LookRotation(
                -(Camera.main.transform.position - ourHealthDisplay.transform.position).normalized, Camera.main.transform.up
                                    );


    }
    internal void Lock_on()
    {
        ourHealthDisplay.text = "Aquiring Lock";
        ourHealthDisplay.color = Color.red;
    }
    internal void adjust_health(int adjustment)
    {
        health += adjustment;
        ourHealthDisplay.enabled = true;
        ourHealthDisplay.text = health.ToString();

        //   health_Display.Text = health.ToString();
        if (health < 0)
            my_asteroid.destroy_game_object();

    }

    internal void Lock_off()
    {
        ourHealthDisplay.text = "";
        ourHealthDisplay.color = Color.white;
    }
}
