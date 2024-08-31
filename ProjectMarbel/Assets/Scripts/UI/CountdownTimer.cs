using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timerText;  // UI Text element to display the countdown
    public float countdownTime = 300f;  // Initial countdown time in seconds
    public Color normalColor = Color.white;  // Color when time is sufficient
    public Color warningColor = Color.red;  // Color when time is low
    public float warningThreshold = 60f;  // Time in seconds when the color changes to warningColor

    private float remainingTime;

    void Start()
    {
        remainingTime = countdownTime;
        Debug.Log("CountdownTimer: Start");
        Debug.Log(timerText);
        UpdateTimerText();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0) remainingTime = 0;  // Prevent going negative
            UpdateTimerText();

            if (remainingTime == 0)
            {
                TimerEnded();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= warningThreshold) // Change color based on the remaining time
        {
            timerText.color = warningColor;
        }
        else
        {
            timerText.color = normalColor;
        }
    }

    void TimerEnded()
    {
        SceneManager.LoadScene("EndScreen");
    }
}