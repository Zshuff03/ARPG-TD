using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	#region Singleton

	public static PlayerManager instance;					//The PlayerManager singleton

	void Awake() {
		instance = this;
	}

	#endregion

	public GameObject player;								//The player GameObejct

	//Make player do things on death
	public void KillPlayer(){
		Debug.Log("Player died. RIP NERD");

		//respawn in town after blah blah blah days
	}
}
