using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    Vector3 velocity, acceleration;
    float thrust_value = 10;
    float missile_lifetime = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,missile_lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = thrust_value* transform.forward;
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    internal void setStartVelocity(Vector3 velocity_of_spaceship)
    {
        velocity = velocity_of_spaceship;
    }
}
