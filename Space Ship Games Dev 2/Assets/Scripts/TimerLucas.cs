using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class TimerLucas : MonoBehaviour
{
    public Text timerFloat;
    private float gameTime;
    private bool timerPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameTime = Time.time;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - gameTime;
        string hours = ((int)t / 3600).ToString("f0");
        string minutes = ((int)t / 60).ToString("f0");
        string seconds      = (t % 60).ToString("f3");
        timerFloat.text = hours + ":" + minutes + ":" + seconds;
            
        }
         
     

        
    
}
