using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Script : MonoBehaviour
{


    List<Asteroid_Control> asteroids;
    int number_od_asteroids = 10;

    public GameObject asteroid_clone_template;
    // Start is called before the first frame update
    void Start()
    {
        asteroids = new List<Asteroid_Control>();
        for (int i = 0; i < number_od_asteroids; i++)
        {
    
            asteroids.Add(spawnNewAsteroid());
        }

    }

    private Asteroid_Control spawnNewAsteroid()
    {
        GameObject new_asteroid = Instantiate(asteroid_clone_template);

        Asteroid_Control new_asteroid_script = new_asteroid.GetComponent<Asteroid_Control>();
        new_asteroid_script.I_am_the_Manager(this);
        new_asteroid_script.set_to_random_position_and_rotation();
        return new_asteroid_script;
    }

    



    internal void Ive_been_destroyed(Asteroid_Control asteroid_Control)
    {
        // remove from list asteroids;
        print(asteroids.Count);
        asteroids.Remove(asteroid_Control);
        print(asteroids.Count);
        // add explosion


        // check to see if asteroid big enough to split

        // spawn 2 new (smaller) asteroids

        /*
        Asteroid_Control new_asteroid_script = new_asteroid.GetComponent<Asteroid_Control>();
        new_asteroid_script.I_am_the_Manager(this);
        new_asteroid_script.set_to_random_position_and_rotation();
        return new_asteroid_script;
        */
        
        // Add new asteroids to list asteroids

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
