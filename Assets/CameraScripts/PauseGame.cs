using UnityEngine;

public class PauseGame : MonoBehaviour {

protected GameObject pauseCanvas;
	void Start(){
		pauseCanvas = GameObject.Find("PauseCanvas");
		pauseCanvas.SetActive(false);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (!pauseCanvas.activeInHierarchy){
				Pause();
			}
			else if(pauseCanvas.activeInHierarchy){
				Resume();
			}
		}
	}

	public void Pause(){
		Debug.Log("Pausing game.");
		Time.timeScale = 0;
		pauseCanvas.SetActive(true);

		//Add things to disable here
	}

	public void Resume(){
		Debug.Log("Unpausing game.");
		Time.timeScale = 1;
		pauseCanvas.SetActive(false);

		//Add things to resume here
	}
}
