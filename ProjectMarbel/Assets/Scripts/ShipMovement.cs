using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ShipMovement : MonoBehaviour
{
    public Transform target;    // Specify the target object to rotate around
    [SerializeField] float speed = 0.05f;    // movement speed
    [SerializeField] float raduis = 24.0f;    // raduis of the circular path around the target
    [SerializeField] float angle = 0.0f;    // current angel of the ship
    [SerializeField] float x, y, z = 0.0f;    // for ship position calculations
    [SerializeField] int completeRounds = 0;
    [SerializeField] float timeInterval = 10.0f;
    private float lastStopTime = 0.0f;

    //[SerializeField] float timeTracker = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastStopTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculating the new postion of the ship

        x = target.position.x + Mathf.Sin(angle) * raduis;
        y = target.position.y;
        z = target.position.z + Mathf.Cos(angle) * raduis;

        // Update the position of the ship

        transform.position = new Vector3(x, y, z);

        // increment the angle to move the ship on the circular path

        angle -= speed * Time.deltaTime;

        // keep the cannon aimed at the castle during ship movement

        transform.LookAt(target.position);

        //timeTracker = Time.time;

        //if (transform.position.z >= raduis-0.0015 && Time.time > 1.0)
        //{
        //    completeRounds++;

        //    while(timeInterval > 0)
        //    {
        //        speed = 0;
        //        timeInterval-=Time.deltaTime;
        //    }
        //    timeInterval = 10.0f;
        //    speed = 0.05f;
        //}
    }
}
