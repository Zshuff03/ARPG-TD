using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;

	public Vector3 offset;
	public float zoomSpeed = 4f;
	public float minZoom = 5f;
	public float maxZoom = 15f;
	public float pitch = 2f;

	private float currentZoom = 10f;


	void Update() {
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
	}
	// Update is called once per frame 
	void LateUpdate() {
		transform.position = player.transform.position - offset * currentZoom;
		transform.LookAt(player.transform.position + Vector3.up * pitch);
	}
}
