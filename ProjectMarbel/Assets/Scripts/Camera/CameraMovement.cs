using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    private float attackDistance = 45f; // Distance for the 'attack' view
    private float normalDistance = 30f; // Default distance for 'FreeLook' view
    private float viewDistance = 35f; // Default distance for 'FreeLook' view
    private float transitionSpeed = 15f; // Speed of the transition between distances

    private void Start()
    {
        // Ensure the camera starts at the normal distance
        UpdateCameraDistance(normalDistance);
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            // Allow rotation when right mouse button is pressed
            UpdateCameraDistance(viewDistance);
            Debug.Log("Rotating camera: " + freeLookCamera.name);
            freeLookCamera.m_XAxis.m_MaxSpeed = 200f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 2f; // Adjust speed as needed
        }
        else if (Input.GetMouseButton(0))
        {
            // Transition to the 'attack' view (closer to the marble)
            UpdateCameraDistance(attackDistance);
        }
        else
        {
            // Disable rotation when right mouse button is not pressed
            UpdateCameraDistance(normalDistance);
            freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0f;
        }

    }

    private void UpdateCameraDistance(float targetDistance)
    {
        // Smoothly transition the camera distance to the target distance
        float currentDistance = freeLookCamera.m_Lens.FieldOfView;
        float newDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * transitionSpeed);
        freeLookCamera.m_Lens.FieldOfView = newDistance;
    }
}