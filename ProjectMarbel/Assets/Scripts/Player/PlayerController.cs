using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    [Header("Scene objects")]

    [SerializeField]
    private Camera Camera;

    [SerializeField]
    private TrajectoryDrawer trajectoryDrawer;
    [SerializeField]
    // TODO: auto-assign this parameter!
    private Transform MarbelPosition;

    [Header("Force Parameters")]

    [SerializeField]
    private float forceIncrement = 5f;

    [SerializeField]
    private float MinThrowStrength = 15f;

    [SerializeField]
    private float MaxThrowStrength = 150f;

    // Internal parameters
    private int playerIndex;
    private int score = 0;
    private string playerName = "";
    private Rigidbody Marbel;
    private bool isActive = false;

    // Default starting force
    private float currentForce = 50f;

    // Aim tracking
    private Vector3 initialMousePosition;
    private Vector3 aimDirection;
    private Vector3 forceDirection;


    void Start()
    {
        Marbel = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isActive) return;

        if (Input.GetKey(KeyCode.W))
        {
            IncreaseForce();
        }
        if (Input.GetKey(KeyCode.S))
        {
            DecreaseForce();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Controlling Player: " + playerName);
            initialMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Aim();  // Calculating trajectory based on Mouse input and force
            Vector3 marbelVelocity = aimDirection / Marbel.mass;  // Pre-calculate trajectory with current Marbel mass
            trajectoryDrawer.DrawTrajectory(marbelVelocity, MarbelPosition.position);  // Draw trajectory
        }
        if (Input.GetMouseButtonUp(0))
        {
            // Applying force to Marbel and resetting the trajectory drawer. 
            ApplyForce(aimDirection);
            trajectoryDrawer.DisableLineRenderer();
        }
    }

    private void Aim()
    {
        // Getting current camera direction and normilizing value
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        // Getting current Mouse position to compare with the initial one
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 mouseDelta = currentMousePosition - initialMousePosition;

        // Calculating X and Y directions comparing to screen. Limiting by 90 degrees for better user experience.  
        float rotationAngleX = mouseDelta.x * 90f / Screen.width;
        float rotationAngleY = mouseDelta.y * 90f / Screen.height;
        Quaternion rotationX = Quaternion.Euler(0, -rotationAngleX, 0);
        Quaternion rotationY = Quaternion.Euler(-rotationAngleY, 0, 0);

        // Calculating direction and applying force amount
        forceDirection = rotationX * cameraForward;
        forceDirection = rotationY * forceDirection;

        aimDirection = forceDirection * currentForce;

    }

    public void LoadPlayerData(int index)
    {
        Debug.Log("Loading player data");
        playerIndex = index;
        playerName = PersistentDataManager.Instance.GetPlayerName(playerIndex);
        score = PersistentDataManager.Instance.GetPlayerScore(playerIndex);
        Debug.Log($"Player {playerIndex} loaded: {playerName}, {score}");
    }

    void ApplyForce(Vector3 force)
    {
        // Applying calculated force to Marbel 
        Marbel.AddForce(force, ForceMode.Impulse);
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
        // TODO: switching level position after "death". 
        GameManager.Instance.PlayerDied();
    }
    void IncreaseForce()
    {
        currentForce = Mathf.Clamp(currentForce + forceIncrement, MinThrowStrength, MaxThrowStrength);
    }

    void DecreaseForce()
    {
        currentForce = Mathf.Clamp(currentForce - forceIncrement, MinThrowStrength, MaxThrowStrength);
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
}