using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;

    // marbles selected by players
    [Header("Player Marbles")]
    public GameObject player1CurrentMarble;
    public GameObject player2CurrentMarble;

    [Header("Audio Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip inGameMusic;
    public AudioClip victoryMusic;

    // [Space(10)]
    [Header("Player Scores")]
    public int player1Score;
    public int player2Score;

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
}
