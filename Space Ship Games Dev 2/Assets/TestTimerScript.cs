using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimerScript : MonoBehaviour
{
    private Timer my_timer, coundown_timer;

    // Start is called before the first frame update
    void Start()
    {
  
        my_timer = gameObject.AddComponent<Timer>();
        my_timer.Timer_Setup();
        coundown_timer = gameObject.AddComponent<Timer>();
        coundown_timer.Timer_Setup(true, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //print(my_timer.current_time());
        if (Input.GetKeyDown(KeyCode.Space)) my_timer.Reset();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.AddComponent<Timer>();
            my_timer.Timer_Setup(true, 5);
        }

        if (coundown_timer.current_time() <0)
        {
            print("Countdown Over");
            coundown_timer.Reset();
        }
        
    }
}
