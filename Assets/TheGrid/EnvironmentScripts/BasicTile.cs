using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicTile : MonoBehaviour {

private int width = 10;
private int widthInTiles = 1;
private int length = 10;
private int lengthInTiles = 1;

public bool buildable;
public float rawHeight;
public bool normalized = false;
public int planeLevel;
public int xLoc;
public int zLoc;

public GameObject objectContained;

	void setObject(GameObject objectToBuild) {
		objectContained = objectToBuild;
		Vector3Int pos = new Vector3Int(xLoc - (width/2), 0, zLoc - (length/2));
		GameObject.Instantiate(objectToBuild, pos, Quaternion.identity);
	}

	public void calcTileHieght() {
		if(rawHeight < .3f) {
			planeLevel = 0;
		} else if(rawHeight >= .3f && rawHeight < .6f) {
			planeLevel = 1;
		} else {
			planeLevel = 2;
		}
		setTransformHeight();
	}
	
	public void setOutterWall() {
		normalized = true;
		resetTransform();
		planeLevel = 4;
		setTransformHeight();
	}

	private void resetTransform() {
		Vector3 currentLocal = transform.localScale;
		transform.localScale = new Vector3(currentLocal.x , 1, currentLocal.z);
	}

	public void normalizeToPlane(int plane) {
		planeLevel = plane;
		resetTransform();
		setTransformHeight();
	}
	public void setColor(Color color) {
		// for debuging purposes
		GetComponent<Renderer>().material.color = color;
	}

	void setTransformHeight() {
		Vector3 newScale = transform.localScale;
		newScale.y = planeLevel * 4 + newScale.y;
		transform.localScale = newScale;
		transform.position = new Vector3(transform.position.x, newScale.y / 2, transform.position.z);

		// for debuging purposes
		float color = (float)(planeLevel * 0.5);
		GetComponent<Renderer>().material.color = new Color(color,1,1);
	}
}
