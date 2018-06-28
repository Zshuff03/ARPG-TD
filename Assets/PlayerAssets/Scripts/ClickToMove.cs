using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
	// public GameObject playerBodyRef;
	Camera cam;
	NavMeshAgent playerNavMeshAgent;
	public LayerMask movementMask;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		playerNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		// set location of parent to follow
		// transform.parent.transform.position = playerBodyRef.transform.position;

		if (Input.GetMouseButtonDown(1)) {
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100, movementMask)) {
				movePlayer(hit.point);
			}
		}
	}

	void movePlayer(Vector3 hit) {
		playerNavMeshAgent.SetDestination(hit);
	}
}
