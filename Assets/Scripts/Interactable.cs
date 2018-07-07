using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;										//how close to interact - default 3 units

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
