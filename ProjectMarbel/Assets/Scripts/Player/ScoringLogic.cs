using UnityEngine;

public class ScoringLogic : MonoBehaviour
{
    // Public variables to hold the tags for players
    public string player1Tag = "Player_1";
    public string player2Tag = "Player_2";

    // Public variables to hold the tags for buildings
    public string buildingSmallTag = "Building_Small";
    public string buildingMediumTag = "Building_Medium";
    public string buildingBigTag = "Building_Big";
    public string buildingHugeTag = "Building_Huge";

    // Points assigned to each building
    public int buildingSmallPoints = 1;
    public int buildingMediumPoints = 2;
    public int buildingBigPoints = 4;
    public int buildingHugePoints = 6;

    private PersistentDataManager dataManager;

    private void Start()
    {
        // Get reference to PersistentDataManager instance
        dataManager = PersistentDataManager.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a player and a building
        GameObject player = null;
        GameObject building = null;

        // Determine which is the player and which is the building
        if (collision.collider.CompareTag(player1Tag) || collision.collider.CompareTag(player2Tag))
        {
            player = collision.collider.gameObject;
            building = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag(player1Tag) || collision.gameObject.CompareTag(player2Tag))
        {
            player = collision.gameObject;
            building = collision.collider.gameObject;
        }

        // If a player and a building are involved, update the score
        if (player != null && building != null && IsBuilding(building.tag))
        {
            HandleCollision(player.tag, building.tag);
        }
    }

    private bool IsBuilding(string tag)
    {
        return tag == buildingSmallTag || tag == buildingMediumTag || tag == buildingBigTag || tag == buildingHugeTag;
    }

    private void HandleCollision(string playerTag, string buildingTag)
    {
        int pointsToAdd = GetPointsForBuilding(buildingTag);

        if (playerTag == player1Tag)
        {
            dataManager.player1Score += pointsToAdd;
            Debug.Log("Player 1 Score: " + dataManager.player1Score);
        }
        else if (playerTag == player2Tag)
        {
            dataManager.player2Score += pointsToAdd;
            Debug.Log("Player 2 Score: " + dataManager.player2Score);
        }
    }

    private int GetPointsForBuilding(string buildingTag)
    {
        if (buildingTag == buildingSmallTag)
            return buildingSmallPoints;
        else if (buildingTag == buildingMediumTag)
            return buildingMediumPoints;
        else if (buildingTag == buildingBigTag)
            return buildingBigPoints;
        else if (buildingTag == buildingHugeTag)
            return buildingHugePoints;

        return 0;
    }
}
