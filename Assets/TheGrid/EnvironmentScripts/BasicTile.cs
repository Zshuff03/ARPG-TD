using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTile : MonoBehaviour {

private int width = 10;
private int widthInTiles = 1;
private int height = 10;
private int heightInTiles = 1;

public bool buildable;
public int xLoc;
public int yLoc;

public GameObject objectContained;

	void setObject(GameObject objectToBuild) {
		objectContained = objectToBuild;
		Vector3Int pos = new Vector3Int(xLoc - (width/2), 0, yLoc - (height/2));
		GameObject.Instantiate(objectToBuild, pos, Quaternion.identity);
	}
}
