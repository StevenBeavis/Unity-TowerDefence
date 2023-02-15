using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameHasEnded;

    public GameObject gameOverUI;
    public GameObject winLevelUI;

    void Start()
    {
        GameHasEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameHasEnded) return;

      
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        
        }
    }

    void EndGame()
    {
        GameHasEnded = true;
        Debug.Log("game end");

        gameOverUI.SetActive(true);
    }

    public void WinLevel() 
    {
        winLevelUI.SetActive(true);
        GameHasEnded = true;
        
    
    
    }
}
