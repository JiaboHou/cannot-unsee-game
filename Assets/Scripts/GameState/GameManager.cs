using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GIJamW2017.GameProperties;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public int playerHealth;
    public ArrayList enemies;

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

    void Start()
    {
        enemies = new ArrayList();
        // Get list of enemies
    }

    // Update is called once per frame
    void Update()
    {
		if (enemies.Count <= 0)
        {
            initiateGameOver(true);
        } else if (playerHealth <= 0)
        {
            initiateGameOver(false);
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
