using UnityEngine;
using TMPro;

public class StopwatchTimer : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Drag your TextMeshPro Text object here")]
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Timer State")]
    public float currentTime = 0f;
    public bool isRunning = false;

    void Start()
    {
        UpdateTimerDisplay();
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText == null);
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        int milliseconds = Mathf.FloorToInt((currentTime % 1f) * 1000f);

        // Crazy formatting
        timerText.text = string.Format("<mspace=0.55em>{0:00}:{1:00}.{2:000}</mspace>", minutes, seconds, milliseconds);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateTimerDisplay();
    }
}