using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;										//how close to interact - default 3 units

	public Transform interactionTransform;							//the transform of the interaction object
																	//For example - a chest will have an interactable empty out in front of the model
	bool isFocus = false;											//If the object is the focus of the player's action
	protected Transform player;										//The player interacting with the object
	bool hasInteracted = false;										//To prevent continual interactions

	void Update() {
		if(isFocus && !hasInteracted) {
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if(distance >= radius) {
				Interact();
				hasInteracted = true;
			}
		}
	}

	///This function determines what is done with the object during interaction
	public virtual void Interact() {
		//Overwrite this object
		//Debug.Log("Interacting with " + this.name);
	}

	///When the interactable is focused by the player
	public void OnFocused(Transform playerTransform) {
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	///When the interactable is removed from focus
	public void OnDefocused() {
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	///Show a wire sphere around the interactable
	void OnDrawGizmosSelected() {
		if(interactionTransform == null)
			interactionTransform = transform;
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
}
