using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringCannon : MonoBehaviour
{
    public GameObject cannonBall;    // the cannonball prefab
    private float lastFiringTime;    // stores the last time a cannonball was fired
    [SerializeField] float force = 60.0f;   // store the force required to fire the cannon ball
    [SerializeField] float timeInterval = 20.0f;   // A cannon ball is fired each timeInterval

    // Start is called before the first frame update
    void Start()
    {
        lastFiringTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastFiringTime >= timeInterval)
        {
            FireCannonBall();
            lastFiringTime = Time.time;
        }
    }

    void FireCannonBall()
    {
        GameObject newCannonBall;   //stores the new instance of the cannonball prefab
        Rigidbody newCannonBallRB;     // store the cannonball instance's rigidbody 
        Vector3 spawnPos;    // cannon ball's instantiation position
        spawnPos = transform.position;
        newCannonBall = Instantiate(cannonBall, spawnPos, Quaternion.identity);
        newCannonBall.tag = "CannonBall";
        newCannonBallRB = newCannonBall.GetComponent<Rigidbody>();
        newCannonBallRB.AddForce(-transform.forward * force, ForceMode.Impulse);
    }
}
