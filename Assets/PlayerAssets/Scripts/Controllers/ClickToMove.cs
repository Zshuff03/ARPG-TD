using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
	// public GameObject playerBodyRef;
	NavMeshAgent playerNavMeshAgent;					//Reference to the player
	Transform target;									//Target for following
	float stoppingDistanceMultiplier;					//Multiply this by the radius of the object to get a stopping point for interacting

	void Start () {
		stoppingDistanceMultiplier = 0.8f;
		playerNavMeshAgent = transform.parent.GetComponent<NavMeshAgent>();
	}

	///Move the player
	public void movePlayer(Vector3 destination) {
		playerNavMeshAgent.SetDestination(destination);
	}

	///Move to an object
	public void moveToObject(Interactable destinationObject) {
		playerNavMeshAgent.stoppingDistance = destinationObject.radius * stoppingDistanceMultiplier;
		target = destinationObject.interactionTransform;
		playerNavMeshAgent.SetDestination(target.position);
	}
	///Follow the target
	public void FollowTarget(Interactable newTarget) {
		playerNavMeshAgent.stoppingDistance = newTarget.radius * stoppingDistanceMultiplier;		
		target = newTarget.interactionTransform;
		StartCoroutine(Follow());
	}

	///Coroutine for following in case something is moving
	public IEnumerator Follow() {
		if(target != null){
			playerNavMeshAgent.SetDestination(target.position);
			yield return true;
		}
	}

	///Stop following the target by clearing target and reset the stopping distance
	public void StopFollowingTarget() {
		StopCoroutine(Follow());
		target = null;
		playerNavMeshAgent.stoppingDistance = 0;
	}
}
