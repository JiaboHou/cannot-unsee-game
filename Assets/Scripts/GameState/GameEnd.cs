using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GIJamW2017.GameProperties;

public class GameEnd : MonoBehaviour {

    public string gameOverText;

    void Start()
    {
        if (GameState.Instance.gameWon)
        {
            this.gameOverText = Constants.TEXT_GAME_WIN;
        }
        else
        {
            this.gameOverText = Constants.TEXT_GAME_LOST;
        }
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(15, 75, 300, 100), gameOverText);
        if (GUI.Button(new Rect(30, 30, 150, 30), "Back to Menu"))
        {
            backToMenu();
        }
    }

    void backToMenu()
    {
        DontDestroyOnLoad(GameState.Instance);
        GameState.Instance.startMenuState();
    }
}
