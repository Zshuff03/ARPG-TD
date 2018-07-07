using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleClicks : MonoBehaviour {
	public GameObject player;
	private GameObject playerScripts;
	public GameObject PauseCanvas;
	public Interactable focus;
	public LayerMask movementMask;
	public LayerMask interactableMask;
	
	ClickToMove clickToMove;
	Camera cam;
	private float maxRaycastHitDistance;
	
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
						clickToMove.moveToObject(interactable);
					}
				}
				//If the Raycast hits the movement mask - keep last
				else if(Physics.Raycast(ray, out hit, maxRaycastHitDistance, movementMask)){
					RemoveFocus();
					//Vector3 destination = new Vector3(hit.point.x, 0, hit.point.z);
					clickToMove.movePlayer(hit.point);
				}
			}
		}
	}

	///Sets an interactable as the players focus and moves to it
	void SetFocus(Interactable newFocus) {
		focus = newFocus;
		clickToMove.movePlayer(focus.transform.position);
		//CURRENTLY BROKEN - switch to this if you want to follow the focus
		// clickToMove.FollowTarget(newFocus);
	}

	///Removes an object from the players focus
	void RemoveFocus() {
		clickToMove.StopFollowingTarget();
		focus = null;
	}
}
