
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BuildEnvironment : MonoBehaviour {
	public GameObject helperScripts;
	public GameObject tile;
	public NavMeshSurface navMesh;
	public GameObject[,] tileArray;

	private int totalPassedWithoutMod = 0;
	
	private Queue<GameObject> tileQueue = new Queue<GameObject>();


	// TODO: figure out a good size that doesn't break the game, 150x150 seems good, but real laggy. 
	private int gridWidth = 100;
	private int gridHeight = 100;
	private int total;
	FindObjectsOnLayer findObjectsOnLayer;


	// Use this for initialization
	void Start () {
		total = gridWidth * gridHeight;
		findObjectsOnLayer = helperScripts.GetComponent(typeof(FindObjectsOnLayer)) as FindObjectsOnLayer;
		tileArray = new GameObject[gridWidth, gridHeight];
		Vector2 startingLoc = new Vector2(1,1);
		buildArena();
		BFModTiles();
		navMesh.BuildNavMesh();
	}

	void buildArena() {
		for(int x=0; x<gridWidth; x++ ) {
			for(int y=0; y<gridWidth; y++ ) {
				
				GameObject tilePrefab =  Instantiate(tile, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
				tilePrefab.name = "Tile(" + x + "," + y + ")";
				BasicTile tilescript = tilePrefab.GetComponent(typeof(BasicTile)) as BasicTile;

				tilescript.xLoc = x;
				tilescript.zLoc = y;

				if(x == 0 || y == 0 || x == gridWidth -1 || y == gridHeight - 1) {
					tilescript.setOutterWall();
				}
				tileArray[x,y] = tilePrefab;
				
			}
		}
	}

	//Using breadth first algorithm with custom 'branching', build a list of tiles to check 
	void BFModTiles() {
		float percentChanceToChange = 0f;
		int currentPlane = 0;
		GameObject currentTile;
		tileQueue.Enqueue(tileArray[1, 1]);

		while (tileQueue.Count != 0) {
			this.totalPassedWithoutMod++;
			currentTile = tileQueue.Dequeue();
			BasicTile tileScript = currentTile.GetComponent(typeof(BasicTile)) as BasicTile;
			tileScript.normalized = true;
			percentChanceToChange = calcChangePercent(total);
			float randomPercentage = Random.Range(0, 100);
			if(randomPercentage > (100 - percentChanceToChange * 25)) {
				// TODO: come up with some randomized way to determine which plane we are going to go to next, ++ or --
				currentPlane++;
				this.totalPassedWithoutMod = 0;
			}
			tileScript.normalizeToPlane(currentPlane);
			int timesToBranch = Random.Range(0, gridWidth / 2);
			List<GameObject> neighbors;

			for (int k=0; k<=timesToBranch; k++) {
				neighbors = getNewNeighbors(currentTile);

				foreach (GameObject tile in neighbors) {
					tileQueue.Enqueue(tile);
				}

				// If there are children, branch to a random neighbor and start the process again
				if (neighbors.Count > 1) {
					int nextNeighbor = Random.Range(0, neighbors.Count);
					currentTile = neighbors[nextNeighbor];
				} else {
					break;
				}
			}
		}
	}


	float calcChangePercent(int totalTiles) {
		float totalTilesForcedFlat = totalTiles/3;
		if (this.totalPassedWithoutMod < totalTilesForcedFlat) {
			return 0;
		}
		float returnVal = 0f;
		this.totalPassedWithoutMod++;
		returnVal = (float)(this.totalPassedWithoutMod - totalTilesForcedFlat)/totalTiles;

		return  returnVal;
	}

	private List<GameObject> getNewNeighbors(GameObject tile) {
		BasicTile currentTileScript = tile.GetComponent(typeof(BasicTile)) as BasicTile;
		List<GameObject> newNeighbors = new List<GameObject>();
		for (int x=currentTileScript.xLoc-1; x<=currentTileScript.xLoc+1; x++) {
			for (int z=currentTileScript.zLoc-1; z<=currentTileScript.zLoc+1; z++) {

				if (currentTileScript.xLoc == x && currentTileScript.zLoc == z) {
					continue;
				}

				BasicTile tilescript = tileArray[x,z].GetComponent(typeof(BasicTile)) as BasicTile;

				// Ignore edges(planeLevel 4) and already normalized tiles
				if (tilescript.planeLevel != 4 && !tilescript.normalized) {
					newNeighbors.Add(tileArray[x,z]);
					tilescript.normalized = true;
				}
			}
		}
		return newNeighbors;
	}

}
