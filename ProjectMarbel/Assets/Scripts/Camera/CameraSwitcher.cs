using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook[] playerCameras; // Array of CinemachineFreeLook cameras for each player
    private int currentPlayerIndex = 0; // Index for the currently active player

    public Cinemachine.CinemachineFreeLook currentCamera;

    void Start()
    {
        if (playerCameras.Length > 0)
        {
            currentCamera = playerCameras[currentPlayerIndex];
            UpdateCamera();
        }
        else
        {
            Debug.LogError("No player cameras assigned!");
        }
    }

    public void SwitchToAttackCamera()
    {
        // Optionally, you can change camera settings here if needed
        // For example, zoom in or change field of view to simulate 'attack' mode

        currentCamera = playerCameras[currentPlayerIndex];
        UpdateCamera();
    }

    public void SwitchToFreeLookCamera()
    {
        // Optionally, you can change camera settings here if needed
        // For example, zoom out or change field of view to simulate 'FreeLook' mode

        currentCamera = playerCameras[currentPlayerIndex];
        UpdateCamera();
    }

    public void SwitchToNextPlayer(int playerIndex)
    {
        // Disable current camera
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(false);
        }
        // Switch to the next player's camera
        currentCamera = playerCameras[playerIndex - 1];
        currentCamera.gameObject.SetActive(true);
    }

    public Cinemachine.CinemachineFreeLook GetCurrentCamera()
    {
        return currentCamera;
    }

    private void UpdateCamera()
    {
        // Ensure the current camera is active
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(true);
        }
    }
}

// using UnityEngine;
// using Cinemachine;

// public class CameraSwitcher : MonoBehaviour
// {
//     public CinemachineVirtualCamera[] playerCameras;  // Array of player cameras
//     private int currentPlayerIndex = 0;

//     // Method to switch to the next player's camera
//     public void SwitchToNextPlayer()
//     {
//         // Disable current player's camera
//         playerCameras[currentPlayerIndex].Priority = 0;

//         // Move to the next player
//         currentPlayerIndex = (currentPlayerIndex + 1) % playerCameras.Length;

//         // Enable the next player's camera
//         playerCameras[currentPlayerIndex].Priority = 10;
//     }
// }