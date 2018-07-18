using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleClicks : MonoBehaviour {
	public GameObject player;												//The player
	private GameObject playerScripts;										//The object holding the scripts for the player
	public GameObject PauseCanvas;											//The pause menu's canvas
	public Interactable focus;												//The interactable that the player is looking to interact with
	public LayerMask movementMask;											//LayerMask for movable terrain
	public LayerMask interactableMask;										//LayerMask for Interactables
	
	ClickToMove clickToMove;												//The ClickToMove script
	Camera cam;																//Main Camera
	private float maxRaycastHitDistance;									//Max distance a Raycast will hit
	
	void Start () {
		cam = Camera.main;
		maxRaycastHitDistance = 100;
		playerScripts = player.transform.Find("Scripts").gameObject;
		clickToMove = playerScripts.GetComponent(typeof(ClickToMove)) as ClickToMove;
	}
	
	void Update () {
		//If the game is not paused
		if(!PauseCanvas.activeInHierarchy) {
			//Left Click
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				//If the Raycast hits
				if(Physics.Raycast(ray, out hit, maxRaycastHitDistance)) {
					//Do things
				}
			}

			//Right Click
			if (Input.GetMouseButtonDown(1)) {
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				//If the Raycast hits an interactable
				if(Physics.Raycast(ray, out hit, maxRaycastHitDistance, interactableMask)) {
					Interactable interactable = hit.collider.GetComponent<Interactable>();
					if(interactable != null) {
						SetFocus(interactable);
					}
				}
				//If the Raycast hits the movement mask - keep last
				else if(Physics.Raycast(ray, out hit, maxRaycastHitDistance, movementMask)) {
					RemoveFocus();
					clickToMove.movePlayer(hit.point);
				}
			}
		}
	}

	///Sets an interactable as the players focus and moves to it
	void SetFocus(Interactable newFocus) {
		if(newFocus != focus){
			if(focus != null)
				focus.OnDefocused();

			focus = newFocus;
			clickToMove.moveToObject(newFocus);
		}

		newFocus.OnFocused(transform);
	}

	///Removes an object from the players focus and stops moving towards it
	void RemoveFocus() {
		if(focus != null) {
			if(focus != null)
				focus.OnDefocused();
		}

		clickToMove.StopFollowingTarget();
		focus = null;
	}
}
