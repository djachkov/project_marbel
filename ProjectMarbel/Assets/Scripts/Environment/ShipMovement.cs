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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculating the new postion of the ship
        x = target.position.x + Mathf.Sin(angle) * raduis;
        y = target.position.y;
        z = target.position.z + Mathf.Cos(angle) * raduis;

        transform.position = new Vector3(x, y, z);      // Update the position of the ship
        angle -= speed * Time.deltaTime;        // increment the angle to move the ship on the circular path
        transform.LookAt(target.position);      // keep the cannon aimed at the castle during ship movement
    }
}
