using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    bool asteroidSize; //Size 1 means big, size 0 means small.

    float rotationSpeed, minRotationSpeed, maxRotationSpeed, healthPoints;
    Vector3 rotationAxis, velocity;


    // Start is called before the first frame update
    void Start()
    {
        asteroidSize = Random.value < 0.5; //50% chance to get a big or a small asteroid
        if (asteroidSize)
            healthPoints = 10;
        else
            healthPoints = 5;

        minRotationSpeed = 30;
        maxRotationSpeed = 180;

        velocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        rotationAxis = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        transform.position += velocity * Time.deltaTime;

        if ((asteroidSize) && healthPoints <= 0)
        {
            GameObject.Destroy(this.gameObject);
            Object.Destroy(this);
        }
    }
}