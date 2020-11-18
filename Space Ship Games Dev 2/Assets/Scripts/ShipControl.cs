using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    Vector3 left_wing_spawn = new Vector3(-4.5f, -1.25f, -1.75f);
    Vector3 right_wing_spawn = new Vector3(4.5f, -1.25f, -1.75f);
    float rotationSpeed = 180; // Rotation spped in degrees pre second
    Vector3 velocity = new Vector3(0,0,0);
    Vector3 acceleration = new Vector3(0, 0, 0);
    private float spaceship_thrust_value = 10;
    private float gravity = 4;
    private float drag_constant = 0.3f;
    CubeControl theCube;
    CameraControl myCamera;
    public GameObject missile_clone_template;

    // Start is called before the first frame update
    void Start()
    {
   //     theCube = FindObjectOfType<CubeControl>();
        myCamera = Camera.main.GetComponent<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;
        // acceleration += gravity * Vector3.down;
        Debug.DrawRay(transform.position, 50* transform.forward);
       // Debug.DrawLine(transform.position, theCube.transform.position);
      //  Vector3 spaceship_to_cube = theCube.transform.position - transform.position;

      //  if ((Vector3.Dot(spaceship_to_cube, transform.forward) / (spaceship_to_cube.magnitude * transform.forward.magnitude)) > 0.8f)
            //print("Locking On");
        //else
            //print("Cannot Lock on");
       // print((Vector3.Dot(spaceship_to_cube, transform.forward)/(spaceship_to_cube.magnitude * transform.forward.magnitude)));

        if ( Input.GetKey(KeyCode.LeftArrow))
        transform.Rotate(Vector3.forward, rotationSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

       
       if (Input.GetKey(KeyCode.UpArrow))
                    transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
       if (Input.GetKey(KeyCode.DownArrow))
                    transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
            acceleration += spaceship_thrust_value *  transform.forward;
        acceleration -= drag_constant * velocity;

        // Faun Schutz - changed controls for missiles firing to two separate buttons
        if (Input.GetKeyDown(KeyCode.R))
            fire_MissileRight();
        if (Input.GetKeyDown(KeyCode.E))
            fire_MissileLeft();

        if (Input.GetKey(KeyCode.L))
        fire_laser();


        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


        myCamera.updatePosition(transform);
      


    }


void fire_laser()
{
  Ray laser = new Ray(transform.position, transform.forward);
  RaycastHit hit;
  if (Physics.Raycast(laser, out hit))
  {
    Health objectHealth = hit.collider.gameObject.GetComponent<Health>();
    if (objectHealth) objectHealth.adjust_health(-1);
  
  print("Laser Hit");
  }

}
    // Faun Schutz - changed controls for missiles firing
    private void fire_MissileRight()
    {
        FireMissileFrom(right_wing_spawn);
    }
    private void fire_MissileLeft()
    {
        FireMissileFrom(left_wing_spawn);
    }

    private void FireMissileFrom(Vector3 local_position)
    {
        GameObject missileGO = Instantiate(missile_clone_template, world_position_from_local(local_position), transform.rotation);
        MissileControl newMissile = missileGO.GetComponent<MissileControl>();
        newMissile.setStartVelocity(velocity);
    }

    private Vector3 world_position_from_local(Vector3 local_vector)
    {
        return transform.position + local_vector.x * transform.right + local_vector.y * transform.up + local_vector.z * transform.forward;
    }
}
