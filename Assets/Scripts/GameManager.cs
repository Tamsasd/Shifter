using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    private Character controlledObject;

    [SerializeField] private Character mainCharacter;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject controllsCanvas;
    private ControlsUIManager CUM;

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
        CUM = FindObjectOfType<ControlsUIManager>();
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

        AbstractMove moveScript = this.controlledObject.GetComponent<AbstractMove>();

        string objName = this.controlledObject.gameObject.name.ToLower();
        string extra = "";

        if (!string.IsNullOrEmpty(moveScript.extraHUDText))
        {
            extra = moveScript.extraHUDText;
        }
        else if (objName.Contains("fire"))
        {
            extra = "Space: fly";
        }
        else if (objName.Contains("duck"))
        {
            extra = "W, A, S, D, Q, E, Space: Quack";
        }

        //if (mainCharacter == controlledObject)
        //{
        //    CUM.chicken = true;
        //}

        CUM.chicken = (mainCharacter == this.controlledObject);

        CUM.SetHUD(
            moveScript.canMove,
            moveScript.canTurn,
            moveScript.canJump,
            extra
        );
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
