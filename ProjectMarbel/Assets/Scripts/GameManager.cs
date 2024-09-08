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
    private float switchTimer = 10f;
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
        activePlayer.DeactivatePlayer();
        SwitchPlayer();
        activePlayer.ChangeLevel(activePlayer.GetPlayerIndex(), currentDeathCase);
    }

    void SwitchPlayer()
    {
        CancelInvoke("SwitchPlayer");
        Debug.Log("Switching player");
        Debug.Log("Active player: " + activePlayer.GetPlayerName());
        // Switch active player
        if (activePlayer == player1)
        {
            activePlayer = player2;
        }
        else
        {
            activePlayer = player1;
        }
        // int nextPlayer = PersistentDataManager.Instance.GetCurrentPlayer() == 1 ? 2 : 1;
        // PersistentDataManager.Instance.SetCurrentPlayer(nextPlayer);
        // Debug.Log("CURRENT PLAYER " + nextPlayer);


        player1.DeactivatePlayer();
        player2.DeactivatePlayer();
        activePlayer.ActivatePlayer();
        if (cameraSwitcher != null)
        {
            cameraSwitcher.SwitchToNextPlayer(activePlayer.GetPlayerIndex());
        }
        playerUIManager.UpdatePlayerName(activePlayer.GetPlayerName());
        // Reset the timer
        Invoke("SwitchPlayer", switchTimer);
    }
}