using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private Text playerNameText; // Reference to the UI Text component

    [SerializeField]
    private Text PlayerScore; // Reference to the UI Text component

    // This method updates the player name displayed on the UI
    public void Start()
    {
        playerNameText.text = "No Player";
        PlayerScore.text = "Score: 0";
    }
    public void UpdatePlayerName(string playerName)
    {
        if (playerNameText != null)
        {
            playerNameText.text = "Player: " + playerName;
        }
    }
    public void UpdatePlayerScore(string score)
    {
        if (playerNameText != null)
        {
            PlayerScore.text = "Score: " + score;
        }
    }
}
