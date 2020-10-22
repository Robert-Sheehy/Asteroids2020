using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer:MonoBehaviour
/// <summary>
/// Step 1 Add as a component to the appropriate game object   e.g. gameobject.AddComponent<Timer>();
/// Step 2 Setup timer using Timer_Setup (note overload(s)) 
/// Step 3 Access current time via current_time()
/// Step 4 Reset with Reset()
/// Step 5 Countdown timer finished when current_time() < 0
/// 
/// </summary>
{


    float _current_time, default_start_time;
    bool countdown = false;
    
    /// <summary>
    /// No parameters Timer increases
    /// </summary>
    public void Timer_Setup()
    {
        _current_time = 0;
        default_start_time = 0;
    }

    public void Update()
    {
        if (countdown) _current_time -= Time.deltaTime;
        else _current_time += Time.deltaTime;
    }
    /// <summary>
    /// Countdown Timer
    /// </summary>
    /// <param name="isCount_down">True if countdown</param>
    /// <param name="start_time">Cooldown, reset or start value</param>
    public void Timer_Setup(bool isCount_down, float start_time)
    {
        countdown = isCount_down;

        _current_time = start_time;
        default_start_time = start_time;
    }
    public float current_time()
    {
        return _current_time;
    }

    public void Reset()
    {
        _current_time = default_start_time;
        
    }
}
