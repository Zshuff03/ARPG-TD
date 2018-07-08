using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	
	public void quit(){
		Debug.Log("Quitting");
		Application.Quit();
	}
}
