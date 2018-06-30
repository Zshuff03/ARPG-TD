using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectsOnLayer : MonoBehaviour {

	 public GameObject[] FindGameObjectsWithLayer (int layer) {
		GameObject[] goArray = (GameObject[])FindObjectsOfType((typeof(GameObject)));
		List<GameObject> goList = new System.Collections.Generic.List<GameObject>();
		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].layer == layer) {
				goList.Add(goArray[i]);
			}
		}
		if (goList.Count == 0) {
			return null;
		}
		return goList.ToArray();
	}
}
