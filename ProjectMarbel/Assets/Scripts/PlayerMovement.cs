using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    Ray mouseRay;
    Vector3 forceDirection;
    Rigidbody rb;
    [SerializeField]
    float force = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRay= cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(mouseRay,out hitInfo, 100f))
        {
            if (hitInfo.transform.tag == "Player")
            {
                forceDirection = -hitInfo.normal;
                rb = hitInfo.rigidbody;
                if(Input.GetMouseButton(0))
                {
                    rb.AddForce(forceDirection * force, ForceMode.Impulse);
                }
            }
        }
    }
}
