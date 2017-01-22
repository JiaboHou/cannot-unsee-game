using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	enum WaveStates { Deactivated, Spawning, WaitingForPlayer, WaitingForNextWave };
	public static int[] enemiesPerWave = { 5, 10, 15, 20, 25 };
	private static WaveStates _currState = WaveStates.Deactivated;
	private static short _waveNumber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
