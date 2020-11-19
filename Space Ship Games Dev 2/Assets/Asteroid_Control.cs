using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Control : MonoBehaviour

{
    Renderer render;
    float WORLD_DIMENSION = 50;


    Vector3 velocity, axis_od_rotation;
    float speed_of_rotation;
    float speed = 10;
    Manager_Script the_manager;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<Renderer>();
        speed_of_rotation = 18f;
  

    }

    // Update is called once per frame
    void Update()
    {



        transform.Rotate(axis_od_rotation, speed_of_rotation * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;

        Health objectHealth = this.gameObject.GetComponent<Health>();

        
        if (objectHealth.health <= 0)
            destroy_game_object();


        if (Input.GetKeyDown(KeyCode.B))
            objectHealth.health = 0;






    }


    internal void destroy_game_object()
    {
        the_manager.Ive_been_destroyed(this);

        GameObject.Destroy(this.gameObject);
    }



    internal void I_am_the_Manager(Manager_Script manager_Script)
    {
        the_manager = manager_Script;
    }

    internal void set_to_random_position_and_rotation()
    {

        transform.position = new Vector3(UnityEngine.Random.Range(-WORLD_DIMENSION, WORLD_DIMENSION), UnityEngine.Random.Range(-WORLD_DIMENSION, WORLD_DIMENSION), UnityEngine.Random.Range(-WORLD_DIMENSION, WORLD_DIMENSION));
        axis_od_rotation = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        axis_od_rotation.Normalize();
        velocity = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        velocity.Normalize();
        velocity *= speed;
        transform.localScale = UnityEngine.Random.Range(0.5f, 3.0f) * Vector3.one;
    }

    internal void you_are_selected()
    {
        render.material.color = Color.red;
    }
}
