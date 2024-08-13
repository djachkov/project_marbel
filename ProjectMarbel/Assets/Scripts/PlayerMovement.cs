using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;    // makes it shorter to call the camera in the code
    Ray mouseRay;    // the ray coming from the camera to the marble
    Vector3 forceDirection;    // sets the direction of the applied force on the marble 
    Rigidbody marbleRB;    // stores the rigidbody of the body hit by the ray
    [SerializeField] float force = 1.0f;    // multiplier for the acting force on the marble

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    // now "cam" is short for "Camera"
    }

    // Update is called once per frame
    void Update()
    {
        mouseRay= cam.ScreenPointToRay(Input.mousePosition);    // creating the ray
        RaycastHit hitInfo;    // stores the information of the gameobject hit by the raycast
        if(Physics.Raycast(mouseRay,out hitInfo, 100f))    // cast the ray from the camera and passing through mouse position on the screen
        {
            if (hitInfo.transform.tag == "Player")    // checks the ray hit the marble of player 1 or 2 (both are tagged by "Player")
            {
                forceDirection = -hitInfo.normal;    // makes the force direction acts normal to the hitting point and in the direction of the ball.
                marbleRB = hitInfo.rigidbody;    // stores the rigidbody of the hit gameobject
                // if(Input.GetMouseButton(0) && MarbleSpeed(rb) <=  0.01)
                if (Input.GetMouseButton(0)  && marbleRB.velocity.magnitude <=0.1)
                {
                    marbleRB.AddForce(forceDirection * force, ForceMode.Impulse);    // applying the force
                }
            }
        }
    }
}
