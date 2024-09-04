using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI winsText;
    [SerializeField] private TextMeshProUGUI player1NameText;  
    [SerializeField] private TextMeshProUGUI player1ScoreText; 
    [SerializeField] private TextMeshProUGUI player2NameText;  
    [SerializeField] private TextMeshProUGUI player2ScoreText; 
    
    private void Start()
    {
        if (winnerText == null || player1NameText == null || player1ScoreText == null ||
            player2NameText == null || player2ScoreText == null)
        {
            Debug.LogError("One or more TextMeshProUGUI fields are not assigned in the Inspector.");
            return;
        }

        DisplayScoresAndWinner();
    }


    // Function to display scores and determine the winner
    private void DisplayScoresAndWinner()
    {
        int player1Score = PersistentDataManager.Instance.player1Score;
        int player2Score = PersistentDataManager.Instance.player2Score;
        string player1Name = PersistentDataManager.Instance.player1Name;
        string player2Name = PersistentDataManager.Instance.player2Name;

        // Display player names and scores in the corresponding UI fields
        player1NameText.text = player1Name;
        player1ScoreText.text = player1Score.ToString();
        player2NameText.text = player2Name;
        player2ScoreText.text = player2Score.ToString();

        // Determine and display the winner or tie in the winnerText field
        if (player1Score > player2Score)
        {
            winnerText.text = player1Name + " Wins!";
        }
        else if (player2Score > player1Score)
        {
            winnerText.text = player2Name + " Wins!";
        }
        else
        {
            winnerText.text = "It is a tie!";
            winsText.gameObject.SetActive(false);
        }
    }

    // Function to reset scores and go to the main menu
    public void GoToMainMenu()
    {
        ResetScores();
        SceneManager.LoadScene("MainMenu");
    }

    // Function to reset player scores
    private void ResetScores()
    {
        PersistentDataManager.Instance.player1Score = 0;
        PersistentDataManager.Instance.player2Score = 0;
    }
}
