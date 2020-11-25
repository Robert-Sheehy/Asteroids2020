using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Control : MonoBehaviour
{   

    Vector3 velocity, axis_od_rotation;
    float speed_of_rotation;
    float speed = 10;
    Manager_Script the_manager;
    // Start is called before the first frame update
    void Start()
    {
       
        speed_of_rotation = 18f;
  

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis_od_rotation, speed_of_rotation * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;
        the_manager.Ive_been_destroyed(this);
        
    }

    internal void I_am_the_Manager(Manager_Script manager_Script)
    {
        the_manager = manager_Script;
    }

    internal void set_to_random_position_and_rotation()
    {
        transform.position = new Vector3(UnityEngine.Random.Range(-500.0f, 500.0f), UnityEngine.Random.Range(-500.0f, 500.0f), UnityEngine.Random.Range(-500.0f, 500.0f));
        axis_od_rotation = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        axis_od_rotation.Normalize();
        velocity = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        velocity.Normalize();
        velocity *= speed;
        transform.localScale = UnityEngine.Random.Range(0.5f, 3.0f) * Vector3.one;
    }
}
