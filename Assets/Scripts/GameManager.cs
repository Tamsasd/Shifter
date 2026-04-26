using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Character controlledObject;

    [SerializeField] private Character mainCharacter;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject controllsCanvas;

    private Pause pauseManager;
    private StopwatchTimer stopwatchTimer;

    public bool isOver = false;

    private void Awake()
    {
        pauseManager = GetComponent<Pause>();
        stopwatchTimer = GetComponent<StopwatchTimer>();
    }

    void Start()
    {
        controlledObject = mainCharacter;
        controlledObject.ToggleControl(true);

        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        controllsCanvas.SetActive(true);
    }

    void Update()
    {
        
    }

    public void setCursorLock(bool isLocked)
    {

        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.Confined;
        Cursor.visible = !isLocked; // giga
    }

    public Character GetControlledObject()
    {
        return controlledObject;
    }

    public Character GetMainCharacter()
    {
        return mainCharacter;
    }

    public void setControlledObject(Character controlledObject)
    {
        this.controlledObject.ToggleControl(false);
        this.controlledObject = controlledObject;
        this.controlledObject.DisableOutline();
        this.controlledObject.ToggleControl(true);
    }

    public void Win()
    {
        Debug.Log("Game won");
        isOver = true;
        setCursorLock(false);
        controllsCanvas.SetActive(false);
        winCanvas.SetActive(true);
        Time.timeScale = 0;
        stopwatchTimer.StopTimer();
        Pause.isPaused = true;
    }

    public void Lose()
    {
        Debug.Log("Game Lost");
        isOver = true; // it's so over...
        setCursorLock(false);
        controllsCanvas.SetActive(false);
        loseCanvas.SetActive(true);
        stopwatchTimer.StopTimer();
    }

}
