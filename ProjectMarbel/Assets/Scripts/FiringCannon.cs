using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringCannon : MonoBehaviour
{
    public GameObject cannonBall;
    private Vector3 spawnPos;
    private Vector3 spawnRot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            spawnPos = transform.position;
            spawnRot = transform.rotation.eulerAngles;
            spawnRot = new Vector3(spawnRot.x, spawnRot.y, spawnRot.z + 180);
            Instantiate(cannonBall, spawnPos, Quaternion.Euler(spawnRot));
        }
    }
}
