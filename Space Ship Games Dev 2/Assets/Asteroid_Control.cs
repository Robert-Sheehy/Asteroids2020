using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Control : MonoBehaviour

{
    Renderer render;
    float WORLD_DIMENSION = 50;
    int astroid_level;
    public int Astroid_Level{
        get {return astroid_level;}
        set {astroid_level = value;
            transform.localScale = Chosen_Scale*Mathf.Pow(2, astroid_level-3)*Vector3.one;

        }
    }

    Health objectHealth;



    float MAXSCALE = 2f, MINSCALE = 1f, Chosen_Scale;


    internal Vector3 velocity, axis_od_rotation;
    float speed_of_rotation;
    float speed = 10;
    Manager_Script the_manager;
    private bool is_selected;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<Renderer>();
       // render.material.color = new Color(0, 0, 1, 0.5f);
        speed_of_rotation = 18f;
  

    }

    // Update is called once per frame
    void Update()
    {

        if (is_selected)

            render.material.color = new Color(UnityEngine.Random.Range(0, 1),
                                                UnityEngine.Random.Range(0, 1),
                                                UnityEngine.Random.Range(0, 1), 
                                                UnityEngine.Random.Range(0, 1));
        else
            render.material.color = Color.white;


        transform.Rotate(axis_od_rotation, speed_of_rotation * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;

        objectHealth = this.gameObject.GetComponent<Health>();

        
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

    void OnCollisionEnter(Collision collision)
    {
        MissileControl missile = collision.gameObject.GetComponentInParent<MissileControl>();
        if (missile)
        {
            destroy_game_object();
            Destroy(missile.gameObject);
            Debug.Log("Boom");
        }

        else
            Debug.Log("Not a missile");

    }



    internal void I_am_the_Manager(Manager_Script manager_Script)
    {
        the_manager = manager_Script;
    }

    internal void set_to_random_position_and_rotation(int max_distance)
    {

        transform.position = new Vector3(UnityEngine.Random.Range(-max_distance, max_distance), UnityEngine.Random.Range(-max_distance, max_distance), UnityEngine.Random.Range(-max_distance, max_distance));
        axis_od_rotation = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        axis_od_rotation.Normalize();
        velocity = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        velocity.Normalize();
        velocity *= speed;
       Chosen_Scale = UnityEngine.Random.Range(MINSCALE, MAXSCALE);
        Astroid_Level = 3;
    }

    internal void spawn_children_o_parent_asteroid(Asteroid_Control asteroid_Control)
    {

        transform.position = asteroid_Control.transform.position;
        axis_od_rotation = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        axis_od_rotation.Normalize();
        velocity = new Vector3(UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f), UnityEngine.Random.Range(-1000.0f, 1000.0f));
        
        velocity.Normalize();
        velocity *= speed;
       
        transform.localScale=(new Vector3(.5f, .5f, .5f));
    }

    internal void disselect()
    {
        objectHealth.Lock_off();
    }

    internal void you_are_selected()
    {
        is_selected = true;

        objectHealth.Lock_on();

        
       
    }

    internal void lock_Acquired()
    {
        objectHealth.locked();
    }

}
