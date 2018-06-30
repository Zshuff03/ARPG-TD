using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
	// public GameObject playerBodyRef;
	NavMeshAgent playerNavMeshAgent;
	public LayerMask movementMask;

	// Use this for initialization
	void Start () {
		
		playerNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
	}


	public void movePlayer(Ray ray) {
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100, movementMask)) {
				playerNavMeshAgent.SetDestination(hit.point);
			}
		
	}
}
