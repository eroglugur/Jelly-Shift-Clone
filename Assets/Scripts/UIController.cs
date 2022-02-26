using System.Collections;
using System.Collections.Generic;
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
        startText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameStarted && !GameManager.isGameActive && !GameManager.levelFinished)
        {
            SetStartScreen();
        }

        else if (GameManager.isGameStarted && !GameManager.isGameActive && !GameManager.levelFinished)
        {
            StartCoroutine(SetRestartScreen());
        }

        else if (GameManager.levelFinished)
        {
            SetNextLevelScreen();
        }
    }

    void SetStartScreen()
    {
        startText.gameObject.SetActive(true);
        if (Input.touchCount > 0)
        {
            Input.GetTouch(0);

            gameManager.StartGame();
            startText.gameObject.SetActive(false);
        }
    }

    IEnumerator SetRestartScreen()
    {
        yield return new WaitForSeconds(1);
        restartText.gameObject.SetActive(true);
        if (Input.touchCount > 0)
        {
            Input.GetTouch(0);
            
            GameManager.isGameActive = false;
            GameManager.isGameStarted = false;
            GameManager.levelFinished = false;
            
            gameManager.RestartLevel();
            restartText.gameObject.SetActive(false);
        }
    }

    IEnumerator SetNextLevelScreen()
    {
        yield return new WaitForSeconds(1);
        nextLevelText.gameObject.SetActive(true);
        if (Input.touchCount > 0)
        {
            Input.GetTouch(0);
            
            GameManager.isGameActive = false;
            GameManager.levelFinished = false;
            GameManager.isGameStarted = false;

            gameManager.LoadNextLevel();
            nextLevelText.gameObject.SetActive(false);
        }
    }
}