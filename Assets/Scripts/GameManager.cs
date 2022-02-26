using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameActive;
    public static bool levelFinished;
    public static bool isGameStarted;
    
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        levelFinished = false;
        
    }
    
    public void StartGame()
    {
        isGameActive = true;
    }
    
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        
    }
}
