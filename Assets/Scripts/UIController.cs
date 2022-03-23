using System.Collections;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text startText;
    public TMP_Text restartText;
    public TMP_Text nextLevelText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        StartCoroutine("SetStartScreen");
    }

    public IEnumerator SetStartScreen()
    {
        startText.gameObject.SetActive(true);
        while (true)
        {
            if (Input.touchCount > 0)
            {
                Input.GetTouch(0);
                
                gameManager.StartGame();
                
                startText.gameObject.SetActive(false);
                
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator SetRestartScreen()
    {
        yield return new WaitForSeconds(1);

        restartText.gameObject.SetActive(true);

        while (true)
        {
            if (Input.touchCount > 0)
            {
                Input.GetTouch(0);
                restartText.gameObject.SetActive(false);

                GameManager.levelFinished = false;
                GameManager.isGameActive = false;
                GameManager.isGameStarted = false;

                gameManager.RestartLevel();
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator SetNextLevelScreen()
    {
        yield return new WaitForSeconds(1);

        nextLevelText.gameObject.SetActive(true);
        while (true)
        {
            if (Input.touchCount > 0)
            {
                Input.GetTouch(0);

                nextLevelText.gameObject.SetActive(false);

                GameManager.levelFinished = false;
                GameManager.isGameActive = false;
                GameManager.isGameStarted = false;

                GameManager.levelWin = true;
                gameManager.LoadNextLevel();
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }
}