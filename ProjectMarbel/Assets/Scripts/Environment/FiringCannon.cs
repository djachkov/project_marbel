using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringCannon : MonoBehaviour
{
    public GameObject cannonBall;    // the cannon ball prefab
    private Vector3 spawnPos;    // cannon ball's instantiation position
    private Vector3 spawnRot;    // cannon ball's instantiation rotation
    private GameObject newCannonBall;

    Rigidbody newCannonBallRB;     // cannon ball's rigidbody 
    public float force = 60.0f;   // store the force required to fire the cannon ball


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnPos = transform.position;
            //spawnRot = transform.rotation.eulerAngles;
            //Debug.Log(spawnRot);
            //spawnRot = new Vector3(spawnRot.x, spawnRot.y, spawnRot.z + 180);
            //Debug.Log(spawnRot);
            newCannonBall = Instantiate(cannonBall, spawnPos, Quaternion.identity);
            newCannonBall.tag = "CannonBall";
            newCannonBallRB = newCannonBall.GetComponent<Rigidbody>();
            newCannonBallRB.AddForce(-transform.forward * force, ForceMode.Impulse);
        }
    }

}
