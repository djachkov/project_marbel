using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;

    [Header("Player Names")]
    public string player1Name;
    public string player2Name;

    // marbles selected by players
    [Header("Player Marbles")]
    public GameObject player1CurrentMarble;
    public GameObject player2CurrentMarble;

    [Header("Audio Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip inGameMusic;
    public AudioClip victoryMusic;

    [Header("Player Scores")]
    public int player1Score;
    public int player2Score;

    [Header("Current Player")]
    public int currentPlayer; // 1 for player 1, 2 for player 2
    private void Awake()
    {
        if (Instance != null) // singleton pattern, only one gameObject with this script can exist
        {
            // Debug.Log("PersistentDataManager instance destroyed");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // gameObject with this script will not be destroyed when switching scenes
    }

    // Method to Get Current Player
    public string GetPlayerName(int playerIndex)
    {
        if (playerIndex == 1)
        {
            return player1Name;
        }
        else if (playerIndex == 2)
        {
            return player2Name;
        }
        else
        {
            Debug.LogError("Invalid player index! Use 1 or 2.");
            return null;
        }
    }
    public void SetPlayerName(int playerIndex, string playerName)
    {
        if (playerIndex == 1)
        {
            player1Name = playerName;
        }
        else if (playerIndex == 2)
        {
            player2Name = playerName;
        }
        else
        {
            Debug.LogError("Invalid player index! Use 1 or 2.");
        }
    }
    public int GetPlayerScore(int playerIndex)
    {
        if (playerIndex == 1)
        {
            return player1Score;
        }
        else if (playerIndex == 2)
        {
            return player2Score;
        }
        else
        {
            Debug.LogError("Invalid player index! Use 1 or 2.");
            return 0;
        }
    }
    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }

    // Method to Set Current Player
    public void SetCurrentPlayer(int playerNumber)
    {
        if (playerNumber == 1 || playerNumber == 2)
        {
            currentPlayer = playerNumber;
            // ManagePlayerControl(); // Update camera and controls when changing player
        }
        else
        {
            Debug.LogError("Invalid player number! Use 1 or 2.");
        }
    }
}
