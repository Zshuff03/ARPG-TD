using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;				//Aggro radius

	Transform target;							//Enemy's target for movement/attacking
	NavMeshAgent agent;							//NavMeshAgent for the enemy
	CharacterCombat combat;						//Stores the combat manager for the enemy

	// Use this for initialization
	void Start () {
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		combat = GetComponent<CharacterCombat>();
	}
	
	// Update is called once per frame
	void Update () {
		//This will be changed to use triggers but for now thats what we got.
		float distance = Vector3.Distance(target.position, transform.position);

		if(distance <= lookRadius) {
			agent.SetDestination(target.position);

			if(distance <= agent.stoppingDistance) {
				CharacterStats targetStats = target.GetComponent<CharacterStats>();
				if(targetStats != null){
					combat.Attack(targetStats);
					FaceTarget();
				}
			}
		}
	}

	//Turn the face the target. SLERRRRP
	void FaceTarget() {
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	//Gizmo for the aggro radius. Can be removed once trigger is added
	void OnDrawGizmossSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
