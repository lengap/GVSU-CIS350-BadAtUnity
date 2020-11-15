using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level_Generation : MonoBehaviour
{
	//Variables to hold Different Tiles
    [SerializeField]
    private Tile groundTile;
    [SerializeField]
    private Tile pitTile;
    [SerializeField]
    private Tile topWallTile;
    [SerializeField]
    private Tile botWallTile;
	[SerializeField]
	private Tile doorTile;
    [SerializeField]
    private Tilemap groundMap;
    [SerializeField]
    private Tilemap pitMap;
    [SerializeField]
    private Tilemap wallMap;
	[SerializeField]
	private Tilemap doorMap;
	
	//Rate until a new room is created.
    [SerializeField]
    private int deviationRate = 10;
    [SerializeField]
	//Amount of rooms the map generates
    private int roomRate = 15;
	//Longest route to the finish the player has to run.
    [SerializeField]
    private int maxRouteLength;
    [SerializeField]
    private int maxRoutes = 20;
	//Transform objects for player and spawner to determine distance between them.
	public Transform SpawnerTrans;
	public Transform PlayerTrans;
	public Transform KitTransform;
	
	//Max amount of spawners the map can have at a time.
	public int maxSpnr;
	//Max amount of items the map can have at a time.
	public int maxItems;
	//Max amount of landmines the map can have at a time.
	public int maxMines;
	//Max amount of sandbags the map can have at a time.
	public int maxSandBags;
	//Max amount of Doors the map can have at a time.
	public int maxDoors;
	
	//Variable to hold the Spawner GameObject
	public GameObject spawner;
	//Array for item game objects.
	public GameObject[] items;
	//Variable to hold the player GameObject
    public GameObject player;
	public GameObject landmine;
	public GameObject Sandbags;
	public GameObject Portal;
	
	
	//Counts for spawners, landmines, sandbags, and items in game.
	private int spnrCount;
	private int landmineCount;
	private int itemCount;
	private int SandbagCnt;
	private int kitCount;
	private int initKitchenCnt;
	private int doorCnt;
	//Boolean for determining if a room is generated.
	private int Size;
    

    private int routeCount = 0;

    private void Start()
    {
        int x = 0;
        int y = 0;
        int routeLength = 0;
		spnrCount = 0;
		itemCount = 0;
		landmineCount = 0;
		initKitchenCnt = 0;
		SandbagCnt = 0;
		kitCount = 0;
		doorCnt = 0;
        GenerateSquare(x, y, 1);
        Vector2Int previousPos = new Vector2Int(x, y);
        y += 3;
        GenerateSquare(x, y, 1);
        NewRoute(x, y, routeLength, previousPos);

        FillWalls();
    }

    private void FillWalls()
    {
        BoundsInt bounds = groundMap.cellBounds;
        for (int xMap = bounds.xMin - 10; xMap <= bounds.xMax + 10; xMap++)
        {
            for (int yMap = bounds.yMin - 10; yMap <= bounds.yMax + 10; yMap++)
            {
                Vector3Int pos = new Vector3Int(xMap, yMap, 0);
                Vector3Int posBelow = new Vector3Int(xMap, yMap - 1, 0);
                Vector3Int posAbove = new Vector3Int(xMap, yMap + 1, 0);
                TileBase tile = groundMap.GetTile(pos);
                TileBase tileBelow = groundMap.GetTile(posBelow);
                TileBase tileAbove = groundMap.GetTile(posAbove);
                if (tile == null)
                {
                    pitMap.SetTile(pos, pitTile);
                    if (tileBelow != null)
                    {
						if(Random.Range(0,10) == 1 && doorCnt != maxDoors){
							Instantiate(Portal, posBelow, Quaternion.identity);
							doorCnt++;
							//doorMap.SetTile(pos, doorTile);
						}
						wallMap.SetTile(pos, topWallTile);
						
                    }
                    else if (tileAbove != null)
                    {
                        wallMap.SetTile(pos, botWallTile);
                    }
                }
            }
        }
    }
	

    private void NewRoute(int x, int y, int routeLength, Vector2Int previousPos)
    {
        if (routeCount < maxRoutes)
        {
            routeCount++;
            while (++routeLength < maxRouteLength)
            {
                //Initialize
                bool routeUsed = false;
                int xOffset = x - previousPos.x; //0
                int yOffset = y - previousPos.y; //3
                int roomSize = 1; //Hallway size
                if (Random.Range(1, 100) <= roomRate)
                    roomSize = Random.Range(3, 6);
                previousPos = new Vector2Int(x, y);

                //Go Straight
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x + xOffset, previousPos.y + yOffset, roomSize);
                        NewRoute(previousPos.x + xOffset, previousPos.y + yOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                    }
                    else
                    {
                        x = previousPos.x + xOffset;
                        y = previousPos.y + yOffset;
                        GenerateSquare(x, y, roomSize);
						//GenerateSandbags(previousPos.x,previousPos.y);
                        routeUsed = true;
                    }
                }

                //Go left
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x - yOffset, previousPos.y + xOffset, roomSize);
                        NewRoute(previousPos.x - yOffset, previousPos.y + xOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                    }
                    else
                    {
                        y = previousPos.y + xOffset;
                        x = previousPos.x - yOffset;
                        GenerateSquare(x, y, roomSize);
						GenerateLandmines(x,y);
                        routeUsed = true;
                    }
                }
                //Go right
                if (Random.Range(1, 100) <= deviationRate)
                {
                    if (routeUsed)
                    {
                        GenerateSquare(previousPos.x + yOffset, previousPos.y - xOffset, roomSize);
                        NewRoute(previousPos.x + yOffset, previousPos.y - xOffset, Random.Range(routeLength, maxRouteLength), previousPos);
                    }
                    else
                    {
                        y = previousPos.y - xOffset;
                        x = previousPos.x + yOffset;
                        GenerateSquare(x, y, roomSize);
						GenerateItems(x,y);
                        routeUsed = true;
                    }
                }

                if (!routeUsed)
                {
                    x = previousPos.x + xOffset;
                    y = previousPos.y + yOffset;
                    GenerateSquare(x, y, roomSize);
                }
            }
        }
    }

    private void GenerateSquare(int x, int y, int radius)
    {
        for (int tileX = x - radius; tileX <= x + radius; tileX++)
        {
            for (int tileY = y - radius; tileY <= y + radius; tileY++)
            {
                Vector3Int tilePos = new Vector3Int(tileX, tileY, 0);
                groundMap.SetTile(tilePos, groundTile);
            }
        }
		
		Vector3Int pos = new Vector3Int(x, y, 0);
		if(Vector3.Distance(pos, PlayerTrans.position) > 15){
			if(radius > 2 && (spnrCount != maxSpnr)){
				Instantiate(spawner, pos, Quaternion.identity);
				spnrCount++;
			}
		}
		
    }
	/**
	private void GenerateSpawner(int x, int y, int size){
		Vector3Int pos = new Vector3Int(x, y, 0);
		if(Vector3.Distance(pos, PlayerTrans.position) > 50){
			if(size > 2 && (spnrCount != maxSpnr)){
				Instantiate(spawner, pos, Quaternion.identity);
				spnrCount++;
			}
		}
	}
	**/
	private void GenerateItems(int x, int y){
		Vector3Int pos = new Vector3Int(x,y,-2);
		int chooseItem = Random.Range(0,2);
		if(itemCount != maxItems){
			Instantiate(items[chooseItem], pos, Quaternion.identity);
			itemCount++;
		}
		
	}
	
	private void GenerateLandmines(int x, int y){
		Vector3Int pos = new Vector3Int(x,y,-2);
		if(landmineCount != maxMines){
			Instantiate(landmine, pos, Quaternion.identity);
			landmineCount++;
		}
	}
	private void GenerateSandbags(int x, int y){
		Vector3Int pos = new Vector3Int(x,y,-2);
		if(SandbagCnt != maxSandBags){
			Instantiate(Sandbags, pos, Quaternion.identity);
			SandbagCnt++;
		}
	}
}