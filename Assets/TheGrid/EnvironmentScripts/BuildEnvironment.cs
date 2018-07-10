
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BuildEnvironment : MonoBehaviour {
	public GameObject helperScripts;
	public GameObject tile;
	public NavMeshSurface navMesh;
	public GameObject[,] tileArray;
	private int noiseMod = 100;

	// TODO: figure out a good size that doesn't break the game, 150x150 seems good, but real laggy. 
	private int gridWidth = 15;
	private int gridHeight = 15;
	private float randomOffsetX = 100f;
	private float randomOffsetY = 100f;
	public float RNGRange = 50f;
	FindObjectsOnLayer findObjectsOnLayer;

	// Use this for initialization
	void Start () {
		randomOffsetX = Random.Range(0f, RNGRange);
		randomOffsetY = Random.Range(0f, RNGRange);
		findObjectsOnLayer = helperScripts.GetComponent(typeof(FindObjectsOnLayer)) as FindObjectsOnLayer;
		tileArray = new GameObject[gridWidth, gridHeight];

		for(int x=0; x<gridWidth; x++ ) {
			for(int y=0; y<gridWidth; y++ ) {
				GameObject tilePrefab =  Instantiate(tile, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
				tilePrefab.name = "Tile(" + x + "," + y + ")";
				BasicTile tilescript = tilePrefab.GetComponent(typeof(BasicTile)) as BasicTile;
				float xSample = (float) x * 10 / noiseMod * randomOffsetX;
				float ySample = (float) y * 10 / noiseMod * randomOffsetY;
				
				tilescript.xLoc = x;
				tilescript.yLoc = y;
				tilescript.rawHeight = Mathf.PerlinNoise(xSample, ySample);
				tilescript.calcTileHieght();
				tileArray[x,y] = tilePrefab;
			}
		} 
		normalizeHeights();
		navMesh.BuildNavMesh();
	}

	void normalizeHeights() {
		for(int x=0; x<gridWidth; x++ ) {
			for(int y=0; y<gridWidth; y++ ) {
				if(x == 0 || y == 0 || x == gridWidth -1 || y == gridHeight - 1) {
					BasicTile tilescript = tileArray[x,y].GetComponent(typeof(BasicTile)) as BasicTile;
					tilescript.setOutterWall();
				} else {
					//Normalize everything!
					int[] localHeights = countTileHeights(x, y);
				}
			}
		}
	}

	private int[] countTileHeights(int currentX, int currentY) {
		int[] localHeights = new int[3];
		for(int x=currentX-1; x<=currentX+1; x++) {
			for(int y=currentY-1; y<=currentY+1; y++) {
				BasicTile tilescript = tileArray[x,y].GetComponent(typeof(BasicTile)) as BasicTile;
				if(tilescript.planeLevel != 4) {
					print("here");
					print(localHeights[tilescript.planeLevel]);
					localHeights[tilescript.planeLevel] ++;
				}
			}
		}
		print(localHeights[0]);
		return localHeights;
	}
}
