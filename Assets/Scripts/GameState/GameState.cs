using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GIJamW2017.GameProperties;

public class GameState : MonoBehaviour {

	private static GameState instance;
    public bool gameWon = false;

	public static GameState Instance {
		get {
			if (instance == null) {
				instance = new GameObject ("GameState").AddComponent<GameState> ();
			}
			return instance;
		}
	}

	public void OnApplicationQuit() {
		instance = null;
	}

    public void startMenuState()
    {
        print("Creating a new game state");

        SceneManager.LoadScene(Constants.SCENE_START_MENU);
    }

	public void startGameState() {
		print ("Creating a new game state");

		SceneManager.LoadScene(Constants.SCENE_LEVELS[0]);
	}

    public void endGameState()
    {
        print("Creating a new game state");

        SceneManager.LoadScene(Constants.SCENE_GAME_END);
    }
}
