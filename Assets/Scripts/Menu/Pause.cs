using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameManager))]
public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool isPaused = false;

    private GameManager gameManager;

    // Create a static instance of the script
    public static Pause Instance { get; private set; }

    //void Awake()
    //{
    //    // Check if an instance already exists
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject); // Stayin alive, staying alive, ah-ah-ah-ah
    //    }
    //    else
    //    {
    //        // If an instance already exists, destroy this duplicate
    //        Destroy(gameObject);
    //    }
    //}

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        ResumeGame();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) // So it won't open in the menu
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.P))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
        gameManager.setCursorLock(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        gameManager.setCursorLock(true);
    }

    public void QuitToMainMenu()
    {
        ResumeGame();
        gameManager.setCursorLock(false);
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        ResumeGame();
        gameManager.setCursorLock(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}