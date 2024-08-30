using UnityEngine;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
    private int playerIndex;

    private string playerName = "";
    private int score = 0;

    private float baseForceAmount = 10f;
    private Rigidbody rb;
    private bool isActive = false;
    public CinemachineFreeLook freeLookCamera; // Reference to the Cinemachine FreeLook camera
    public TrajectoryDrawer trajectoryDrawer;

    private Vector3 initialMousePosition;
    private Vector3 aimDirection;
    public float maxChargeTime = 5f;  // Maximum charge time in seconds

    public float chargeTime = 0f;


    private Vector3 forceDirection;      // Direction in which force will be applied



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forceDirection = Vector3.forward;      // Initialize force direction in local space
    }

    void Update()
    {
        if (!isActive) return;
        if (Input.GetMouseButtonUp(0))
        {
            EndTurn();
        }


    }
    public void LoadPlayerData(int index)
    // Load player data from PersistentDataManager
    {
        Debug.Log("Loading player data");
        playerIndex = index;
        playerName = PersistentDataManager.Instance.GetPlayerName(playerIndex);
        score = PersistentDataManager.Instance.GetPlayerScore(playerIndex);
        Debug.Log($"Player {playerIndex} loaded: {playerName}, {score}");
    }
    // Getters
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public string GetPlayerName()
    {
        return playerName;
    }
    void UpdateTrajectory()
    {
        // TODO: implement
    }
    void DrawTrajectory()
    {
        // TODO: implement
    }
    void UpdateForceDirection()
    {
        // TODO: implement
    }
    void ApplyForce(Vector3 force)
    {
        // TODO: implement
    }

    void EndTurn()
    {
        isActive = false;


    }
    public void ActivatePlayer()
    {
        isActive = true;
        Debug.Log("Player activated: " + playerName);
    }

    public void DeactivatePlayer()
    {
        isActive = false;
    }

    public void Die()
    {
        // Your existing logic for handling player death
        GameManager.Instance.PlayerDied();
    }
}