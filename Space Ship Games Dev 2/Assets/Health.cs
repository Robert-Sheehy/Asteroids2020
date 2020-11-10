using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{

    internal int health = 100;

    //TMPro Text health_Display;
    // Start is called before the first frame update
    void Start()
    {
     //   health_Display = gameObject.GetComponentinChildren<Text>(); 
     //   health_Display.Text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void adjust_health(int adjustment)
    {
        health += adjustment;
      //   health_Display.Text = health.ToString();
        if (health<0)
        Destroy(gameObject);
    }
}
