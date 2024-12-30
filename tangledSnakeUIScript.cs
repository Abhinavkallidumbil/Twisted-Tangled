using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TangledSnakeUIScript : MonoBehaviour
{
    public TextMeshProUGUI Timer; // Reference to the TextMeshProUGUI element
    public float countdownTime = 60f; // Starting time in seconds
    private bool TimerIsRunning = false; // Timer stat
    

    public GameObject SettingsPanel;
    public GameObject loosePanel;
    public GameObject winPanel;

    private void Start()
    {
        StartCountdown(); // Start the countdown automatically
    }

    private void Update()
    {
        if (TimerIsRunning)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime; // Decrease time
                UpdateTimerDisplay();
            }
            else
            {
                TimerIsRunning = false;
                countdownTime = 0; // Ensure the timer doesn't go below 0
                UpdateTimerDisplay();
                OnTimerEnd(); // Call the function when timer reaches 0
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60f);
        int seconds = Mathf.FloorToInt(countdownTime % 60f);
        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartCountdown()
    {
        TimerIsRunning = true; // Start the countdown
    }

    public void StopTimer()
    {
        TimerIsRunning = false; // Stop the timer
    }

    public void ResetTimer(float newTime)
    {
        countdownTime = newTime; // Reset the timer to a new time
        UpdateTimerDisplay();
        TimerIsRunning = false;
    }

    private void OnTimerEnd()
    {
        loosePanel.SetActive(true);
    }public void WinPanelShows()
    {
        winPanel.SetActive(true);
    }
    public void LoadSceneHome()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingsButtonOnoff()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }
    public void LoadSceneSameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
