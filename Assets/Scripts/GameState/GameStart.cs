using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStart : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button(new Rect(30, 30, 150, 30), "Start Game")) {
			startGame ();
		}
	}
		
	void startGame() {
		print ("Starting game");

		DontDestroyOnLoad (GameState.Instance);
		GameState.Instance.startGameState ();
	}
	
	// Update is called once per frame
	void Update() {
		
	}
}
