using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject light;
    private GameObject currentLevel;

    public static bool isGameActive;
    public static bool levelFinished;
    public static bool isGameStarted;

    public static bool levelWin = false;

    private string levelName;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(light);

        isGameActive = false;
        levelFinished = false;

        PlayerPrefs.SetInt("LevelIndex", LevelManager.levelIndex);
    }

    public void StartGame()
    {
        isGameActive = true;
        isGameStarted = true;
    }

    public void RestartLevel()
    {
        LevelManager.levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}