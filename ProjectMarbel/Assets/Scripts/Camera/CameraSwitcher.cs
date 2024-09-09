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
            currentCamera = playerCameras[0];
            currentCamera.gameObject.SetActive(true);
            playerCameras[1].gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("No player cameras assigned!");
        }
    }

    public void SwitchToNextPlayer(int playerIndex)
    {
        Debug.Log("Switching camera to Player: " + playerIndex);
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

}
