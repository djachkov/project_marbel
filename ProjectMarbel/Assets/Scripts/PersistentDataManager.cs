using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// How to use it to store data when switching between scene changes:
// example: when changing the master volume level that needs to be stored:
// SET:
//  if (MainManager.Instance != null)
// {
//     PersistentDataManager.Instance.masterVolumeLevel = 0.1f;
// }
// GET
// if (PersistentDataManager.Instance != null)
// {
//     float volume = PersistentDataManager.Instance.masterVolumeLevel;
// }

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;

    // marbles selected by players
    public GameObject player1CurrentMarble;
    public GameObject player2CurrentMarble;
    
    // settings menu items, these are saved between sessions as well
    public float masterVolumeLevel;
    public float vfxVolumeLevel;
    public float musicVolumeLevel;

    public int graphicsResolution;
    public bool graphicsFullscreen;
    
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
