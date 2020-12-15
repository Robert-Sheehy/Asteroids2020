using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Script : MonoBehaviour
{
    internal static ShipControl players_ship;
    //Text testText;
    List<Asteroid_Control> asteroids;

    int currently_selected_asterois_index = 0;

    PutTextHere ScreenText;

    int game_radius=500;
    Text asteroid_display, score_display, shield_display;

    int number_od_asteroids = 10;

    public GameObject asteroid_clone_template;
    private float MAX_LOC_ON_DISTANCE = 300f;

    // Start is called before the first frame update
    void Start()


    {   
        
        
        asteroids = new List<Asteroid_Control>();
        
        ScreenText = FindObjectOfType<PutTextHere>();

        asteroid_display = ScreenText.createText("Asteroids: ", PutTextHere.Screen_Placements.Up);
        
        score_display = ScreenText.createText("Score: ", PutTextHere.Screen_Placements.Down);
        shield_display = ScreenText.createText("Shield: ",PutTextHere.Screen_Placements.Down, PutTextHere.Screen_Placements.Left);

        for (int i = 0; i < number_od_asteroids; i++)
        {
            asteroids.Add(spawnNewAsteroid());
        }

        players_ship = FindObjectOfType<ShipControl>();

    }

    private Asteroid_Control spawnNewAsteroid()
    {
        GameObject new_asteroid = Instantiate(asteroid_clone_template);

        Asteroid_Control new_asteroid_script = new_asteroid.GetComponent<Asteroid_Control>();
        new_asteroid_script.I_am_the_Manager(this);
        new_asteroid_script.set_to_random_position_and_rotation(game_radius);
        return new_asteroid_script;
    }

    //test
    private Asteroid_Control spawnNewAsteroid(Asteroid_Control asteroid_Control)
    {
        GameObject new_asteroid = Instantiate(asteroid_clone_template);

        Asteroid_Control new_asteroid_script = new_asteroid.GetComponent<Asteroid_Control>();
        new_asteroid_script.I_am_the_Manager(this);
        new_asteroid_script.spawn_children_o_parent_asteroid(asteroid_Control);
        return new_asteroid_script;
    }

    //test
    public ParticleSystem big_bada_boom;
    
    internal void Ive_been_destroyed(Asteroid_Control asteroid_being_destroyed)
    {
        ParticleSystem explosion = Instantiate(big_bada_boom);
        explosion.transform.position=asteroid_being_destroyed.transform.position;
        explosion.Play();
        
        asteroids.Remove(asteroid_being_destroyed);
        
        if (asteroid_being_destroyed.Astroid_Level > 0)
        {
            Vector3 parent_Velocity = asteroid_being_destroyed.velocity;
            Vector3 perp_Velocity = Vector3.Cross(parent_Velocity, Vector3.up).normalized;

            Asteroid_Control astroid1=spawnNewAsteroid(), astroid2=spawnNewAsteroid();
            astroid1.transform.position = asteroid_being_destroyed.transform.position;
            astroid2.transform.position = asteroid_being_destroyed.transform.position;

            astroid1.velocity = (parent_Velocity + perp_Velocity)*1.25f;
            astroid2.velocity = (parent_Velocity - perp_Velocity)*1.25f;

            asteroids.Add(astroid1);
            asteroids.Add(astroid2);

            astroid1.transform.localScale = (new Vector3(.5f, .5f, .5f));
            astroid2.transform.localScale = (new Vector3(.5f, .5f, .5f));

            astroid1.Astroid_Level = asteroid_being_destroyed.Astroid_Level -1;
            astroid2.Astroid_Level = asteroid_being_destroyed.Astroid_Level - 1;
        }

        asteroid_display.text = " Asteroids " + asteroids.Count;
    }

    internal void updateShieldDisplay(int shield)
    {
        shield_display.text = "Shield: " + shield.ToString();
        print("Shield is now " + shield.ToString());
    }

    internal Asteroid_Control get_me_any_asteroid(ShipControl ship)
    {
        currently_selected_asterois_index++;
        if (currently_selected_asterois_index >= asteroids.Count)
            currently_selected_asterois_index = 0;
        int starting_index = currently_selected_asterois_index;
      

        while(true)
        {
        
            if (CanLockOn(ship, asteroids[currently_selected_asterois_index]))
            {
                Debug.DrawLine(ship.transform.position, 50 * ship.transform.forward);

                //Debug.DrawLine(ship.transform.position, spaceship_to_asteriod, Color.red, 5.0f);
                
                asteroids[currently_selected_asterois_index].you_are_selected();
                return asteroids[currently_selected_asterois_index];
            }
            else
            {
                currently_selected_asterois_index++;
                if (currently_selected_asterois_index >= asteroids.Count)
                    currently_selected_asterois_index = 0;

                if (currently_selected_asterois_index == starting_index)
                {
                 
                    return null;
                }
            }

            
        }


       

    }

    private bool CanLockOn(ShipControl ship, Asteroid_Control asteroid)
    {
        Vector3 spaceship_to_asteriod = asteroid.transform.position - ship.transform.position;
        return ((Vector3.Dot(ship.transform.forward, spaceship_to_asteriod) / (spaceship_to_asteriod.magnitude)) > 0.8f) 
               && (Vector3.Distance(ship.transform.position,asteroid.transform.position) <  MAX_LOC_ON_DISTANCE);
    }

    


    // Update is called once per frame
    void Update()
    {

        

        foreach (Asteroid_Control asteroid in asteroids)
        {
            Vector3 spaceship_to_asteroid = asteroid.transform.position - players_ship.transform.position;

            if (spaceship_to_asteroid.magnitude > game_radius)
            {
                asteroid.transform.position = (players_ship.transform.position - (spaceship_to_asteroid*.9f));
                
            }

        }
        
    }
}
