using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int levelIndex = 0;
    public static GameObject[] levels = new GameObject[3];
    
    public static GameObject Level()
    {
        if (levelIndex < 3)
        {
            levelIndex++;
       
        }
        else
        {
            levelIndex = 1;
        
        }

        PlayerPrefs.SetInt("LevelIndex", levelIndex);

        levels[PlayerPrefs.GetInt("LevelIndex") - 1] = Resources.Load<GameObject>("LevelPrefabs/" + "Level " + PlayerPrefs.GetInt("LevelIndex"));

        return levels[PlayerPrefs.GetInt("LevelIndex") - 1];
    }


    private void Start()
    {
        Instantiate(Level());
    }
}