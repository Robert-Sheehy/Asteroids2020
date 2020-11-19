using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    List<Asteroid> asteroids;
    int numberOfAsteroids, spawnRate, time;

    // Start is called before the first frame update
    void Start()
    {
        numberOfAsteroids = 10; //insert here the number of asteroids you want
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfAsteroids != 0)
        {
            SpawnAsteroid();
            numberOfAsteroids--;
        }
        

    }

    void SpawnAsteroid()
    {
        //WORK IN PROGRESS
        GameObject asteroid = new GameObject("Asteroid " + numberOfAsteroids);
        //Asteroid asteroidScript = asteroid.AddComponent( Asteroid);
        

    }
}
