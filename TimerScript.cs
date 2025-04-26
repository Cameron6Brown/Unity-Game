using UnityEngine;
using TMPro; // Add this to use TextMeshPro

public class TimerScript : MonoBehaviour
{
    public float TimeLeft = 60f; // Default starting time (in seconds)
    public bool TimerOn = false;
    public TextMeshProUGUI TimerTxt; // Changed to TextMeshProUGUI
    public TextMeshProUGUI WinText; // New text component for the win message
    public GameObject finishObject; // Reference to the Finish object
    private bool hasFinished = false;

    void Start()
    {
        TimerOn = true;

        // Find the Finish object if not assigned
        if (finishObject == null)
        {
            finishObject = GameObject.Find("Finish");
        }

        // Hide win text at start if it exists
        if (WinText != null)
        {
            WinText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the Finish object has been destroyed
        if (finishObject == null && !hasFinished)
        {
            StopTimer();
            ShowWinMessage();
            hasFinished = true;
            Debug.Log("Finish reached! Timer stopped at: " + TimerTxt.text);
            // You can add additional actions here when the finish is reached
        }

        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft); // Fixed variable name
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        // Don't add 1 if you want a countdown timer
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StopTimer()
    {
        TimerOn = false;
        // The timer has been stopped, but the display keeps showing the time when it stopped
    }

    void ShowWinMessage()
    {
        // Show win message if the text component exists
        if (WinText != null)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "YOU WIN!";
        }
        else
        {
            Debug.LogWarning("Win Text component is not assigned!");
        }
    }
}