using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildEnvironment : MonoBehaviour {
	public GameObject helperScripts;
	public GameObject tile;
	FindObjectsOnLayer findObjectsOnLayer;
	private GameObject[] environmentTiles;

	// Use this for initialization
	void Start () {
		findObjectsOnLayer = helperScripts.GetComponent(typeof(FindObjectsOnLayer)) as FindObjectsOnLayer;
		for(int x=0; x<=10; x++ ) {
			for(int y=0; y<=10; y++ ) {
				Instantiate(tile, new Vector3(x * 10, y * 10, 0), Quaternion.identity);
			}
		}
		environmentTiles = findObjectsOnLayer.FindGameObjectsWithLayer(8);
		for(int i=0; i<environmentTiles.Length; i++) {
			// TODO: Build the nav mesh off all the tiles
		}
	}
}
