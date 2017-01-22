using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GIJamW2017.GameProperties;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private bool playerDead = false;
    private bool allEnemiesDestroyed = false;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public void killPlayer()
    {
        playerDead = true;
    }

    public void allEnemiesAreDestroyed()
    {
        allEnemiesDestroyed = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (playerDead)
        {
            initiateGameOver(false);
        } else if (allEnemiesDestroyed)
        {
            initiateGameOver(true);
        }
	}

    // gameWin == 1 => victory
    // gameWin == 2 => second place
    void initiateGameOver(bool gameWon)
    {
        GameState.Instance.gameWon = gameWon;
        DontDestroyOnLoad(GameState.Instance);
        GameState.Instance.endGameState();
    }
}
