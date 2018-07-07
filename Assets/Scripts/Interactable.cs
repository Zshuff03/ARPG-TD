using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;										//how close to interact - default 3 units

	public Transform interactionTransform;
	bool isFocus = false;
	Transform player;
	bool hasInteracted = false;

	void Update() {
		if(isFocus && !hasInteracted) {
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if(distance >= radius) {
				Interact();
				hasInteracted = true;
			}
		}
	}

	///Set this to determine what is done with the object during interaction
	public virtual void Interact() {
		//Overwrite this object
		Debug.Log("Interacting with " + this.name);
	}

	public void OnFocused(Transform playerTransform) {
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	public void OnDefocused() {
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
}
