using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleClicks : MonoBehaviour {
	public GameObject player;
	private GameObject playerScripts;
	
	ClickToMove clickToMove;
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
		playerScripts = player.transform.Find("Scripts").gameObject;
		clickToMove = playerScripts.GetComponent(typeof(ClickToMove)) as ClickToMove;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			clickToMove.movePlayer(ray);
		}
	}
}
