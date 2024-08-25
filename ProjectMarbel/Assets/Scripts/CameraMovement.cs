using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    CinemachineBrain brain;
    public GameObject Marble1;
    public GameObject Marble2;
    Rigidbody Marble1RB;
    Rigidbody Marble2RB;

    // Start is called before the first frame update
    void Start()
    {
        brain = GetComponent<CinemachineBrain>();
        Marble1RB = Marble1.GetComponent<Rigidbody>();
        Marble2RB = Marble2.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //locks the camera view when left Control is pressed
        if (Marble1RB.velocity.magnitude <= 0.1 && Marble2RB.velocity.magnitude <= 0.1)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                brain.enabled = false;
            }
            else
            {
                brain.enabled = true;
            }
        } else
        {
            brain.enabled = true;
        }
    }
}
