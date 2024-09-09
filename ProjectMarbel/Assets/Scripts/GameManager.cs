using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController player1;
    public PlayerController player2;
    private PlayerController activePlayer;
    private CameraSwitcher cameraSwitcher;

    public PlayerUIManager playerUIManager;
    [SerializeField]
    private float switchTimer = 20f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerUIManager = FindObjectOfType<PlayerUIManager>();
        cameraSwitcher = FindObjectOfType<CameraSwitcher>();
        StartGame();
    }

    void StartGame()
    {
        // Start with player 1
        activePlayer = player1;
        player1.LoadPlayerData(1);
        player2.LoadPlayerData(2);
        player1.ActivatePlayer();
        player2.DeactivatePlayer();
        PersistentDataManager.Instance.SetCurrentPlayer(1);
        Debug.Log("Active player: " + activePlayer.GetPlayerName());
        playerUIManager.UpdatePlayerName(activePlayer.GetPlayerName());
        // TODO: Implement score tracking
        // playerUIManager.UpdatePlayerScore(activePlayer.score);



        // Start the timer
        Invoke("SwitchPlayer", switchTimer);
    }

    public void PlayerDied()
    {
        int currentDeathCase = activePlayer.GetDeathCase();
        SwitchPlayer();
        activePlayer.ChangeLevel(activePlayer.GetPlayerIndex(), currentDeathCase);
    }

    public void SwitchPlayer()
    {
        CancelInvoke("SwitchPlayer");
        Debug.Log("Switching player" + activePlayer.GetPlayerName());
        // Switch active player

        player1.DeactivatePlayer();
        player2.DeactivatePlayer();
        if (PersistentDataManager.Instance.GetCurrentPlayer() == 1)
        {
            activePlayer = player2;
        }
        else
        {
            activePlayer = player1;

        }
        activePlayer.ActivatePlayer();
        PersistentDataManager.Instance.SetCurrentPlayer(activePlayer.GetPlayerIndex());

        Debug.Log("New PLayer: " + activePlayer.GetPlayerName() + " " + activePlayer.GetPlayerIndex());
        if (cameraSwitcher != null)
        {
            cameraSwitcher.SwitchToNextPlayer(activePlayer.GetPlayerIndex());
        }
        playerUIManager.UpdatePlayerName(activePlayer.GetPlayerName());
        // Reset the timer
        Invoke("SwitchPlayer", switchTimer);
    }
}