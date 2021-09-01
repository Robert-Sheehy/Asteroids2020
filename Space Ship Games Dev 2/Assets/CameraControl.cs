using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
   
    float distance_behind = 16f;
    float distance_up = 3f;
    float cross_hair_distance = 1000f;

    Vector3 desired_destination;
    Quaternion desired_orientation;
    // Start is called before the first frame update
    void Start()
    {
        desired_destination = transform.position;
        desired_orientation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

       transform.position = Vector3.Lerp(transform.position, desired_destination, 0.05f);
       transform.rotation = Quaternion.Slerp(transform.rotation, desired_orientation, 0.05f);
        
    }

    internal void updatePosition(Transform transform_of_spaceship)
    {
        desired_destination = transform_of_spaceship.position - distance_behind * transform_of_spaceship.forward + distance_up * transform_of_spaceship.up;
        desired_orientation =  Quaternion.LookRotation((transform_of_spaceship.position + cross_hair_distance * transform_of_spaceship.forward).normalized, transform_of_spaceship.up);
    }
}
