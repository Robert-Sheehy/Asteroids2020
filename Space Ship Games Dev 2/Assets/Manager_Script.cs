using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Script : MonoBehaviour
{
    List<Asteroid_Control> asteroids;
    int currently_selected_asterois_index = 0;
    int number_od_asteroids = 100;

    public GameObject asteroid_clone_template;
    // Start is called before the first frame update
    void Start()
    {   asteroids = new List<Asteroid_Control>();
        for (int i = 0; i < number_od_asteroids; i++)
        {  
           GameObject new_asteroid =  Instantiate(asteroid_clone_template);
            Asteroid_Control new_asteroid_script = new_asteroid.GetComponent<Asteroid_Control>();
            new_asteroid_script.I_am_the_Manager(this);
            new_asteroid_script.set_to_random_position_and_rotation();
            asteroids.Add(new_asteroid_script);
        }
        
    }

    internal void Ive_been_destroyed(Asteroid_Control asteroid_Control)
    {
        throw new NotImplementedException();
    }

        //Debug.DrawRay(transform.position, 50* transform.forward);
       // Debug.DrawLine(transform.position, theCube.transform.position);
      //  Vector3 spaceship_to_cube = theCube.transform.position - transform.position;

      //  if ((Vector3.Dot(spaceship_to_cube, transform.forward) / (spaceship_to_cube.magnitude * transform.forward.magnitude)) > 0.8f)
            //print("Locking On");
        //else
            //print("Cannot Lock on");
       // print((Vector3.Dot(spaceship_to_cube, transform.forward)/(spaceship_to_cube.magnitude * transform.forward.magnitude)));

             
    internal Asteroid_Control get_me_any_asteroid(ShipControl ship)
    {
        currently_selected_asterois_index++;
    int starting_index = currently_selected_asterois_index;
    bool finished = false;

        while(!finished)
        {
        Vector3 spaceship_to_asteriod = asteroids[currently_selected_asterois_index].transform.position - ship.transform.position;
        if ((Vector3.Dot(ship.transform.forward,spaceship_to_asteriod)/(spaceship_to_asteriod.magnitude)) >0.8f)
            {
        Debug.DrawLine(ship.transform.position, 50* ship.transform.forward);

        Debug.DrawLine(ship.transform.position, spaceship_to_asteriod, Color.red, 5.0f);
        finished = true;
        return asteroids[currently_selected_asterois_index];
            }
        else{

        
            currently_selected_asterois_index++;
            if (currently_selected_asterois_index >= asteroids.Count)
                currently_selected_asterois_index = 0;

            if (currently_selected_asterois_index == starting_index)
            {
                finished = true;
                return null;
            }
        }
        
        }
       
         
        
        // for(int i = 0; i < number_od_asteroids; i++)
        // {
        //     currently_selected_asterois_index++;
      
        // }
     return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
