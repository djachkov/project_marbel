using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerNameText;

    [SerializeField]
    private TMP_Text Player1Score;
    [SerializeField]

    private TMP_Text Player2Score;

    // This method updates the player name displayed on the UI
    public void Start()
    {
        Debug.Log("PlayerUIManager: Start");
        // playerNameText.text = "No Player";
        Player1Score.text = "00";
        Player2Score.text = "00";
    }
    public void UpdatePlayerName(string playerName)
    {
        Debug.Log("PlayerUIManager: UpdatePlayerName: " + playerName);
        if (playerNameText != null)
        {
            playerNameText.text = playerName;
        }
    }
    public void UpdatePlayerScore(int playerIndex, string score)
    {
        if (playerNameText != null)
        {
            if (playerIndex == 1)
                Player1Score.text = "Score: " + score;
            else
                Player2Score.text = "Score: " + score;
        }
    }
}
