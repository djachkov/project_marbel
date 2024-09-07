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
    [Range(0.5f, 10f)]
    private float forceIncrement = 1f;

    [SerializeField]
    [Range(1f, 50f)]
    private float MinThrowStrength = 15f;

    [SerializeField]
    [Range(50f, 250f)]
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
    private float currentHorizontalAngle = 0f;
    private float currentVerticalAngle = 0f;

    [SerializeField]
    [Range(0.05f, 1f)]
    private float aimSensitivity = 0.05f; // TODO: setings? 

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

        // Getting current Mouse position to compare with the initial one
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 mouseDelta = currentMousePosition - initialMousePosition;

        // Getting mouse coord delta and adjusting for better sensicivity. NOTE: screen width/height dependencies removed. 
        float horizontalDelta = -mouseDelta.x * 0.05f;
        float verticalDelta = mouseDelta.y * 0.05f;     // Adjust sensitivity as needed

        // Combining data BEFORE clumping solved the crazy mouse clamping issue.
        currentHorizontalAngle += horizontalDelta;
        currentVerticalAngle += verticalDelta;
        // Clumping to limit the player from backward aiming (better UX)
        currentHorizontalAngle = Mathf.Clamp(horizontalDelta, -90f, 90f);
        currentVerticalAngle = Mathf.Clamp(verticalDelta, -90f, 90f);

        // Rotation rotation
        Quaternion horizontalRotation = Quaternion.AngleAxis(currentHorizontalAngle, Vector3.up);
        Quaternion verticalRotation = Quaternion.AngleAxis(currentVerticalAngle, Camera.main.transform.right);

        //  Here where the force is calculated, finally
        forceDirection = horizontalRotation * verticalRotation * cameraForward;

        // And then - aim corrected by force and we have the result! 
        aimDirection = forceDirection.normalized * currentForce;

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
        trajectoryDrawer.DisableLineRenderer();
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