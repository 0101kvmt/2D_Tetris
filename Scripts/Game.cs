using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];


	// Use this for initialization
	void Start () {
        SpawnNextTetro();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // for each colummn in each row check if null
    public void UpdateGrid (Tetramino tetromino)
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridHeight; x++)
            {
                if(grid[x,y] != null)
                {
                    if(grid[x,y] == tetromino.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        
        foreach (Transform mino in tetromino.transform)
        {
            Vector2 pos = Round(mino.position);
            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    public void SpawnNextTetro ()
    {
        // load random tetro, positioned & rotated
        GameObject nextTetro = (GameObject)Instantiate(Resources.Load(GetRandomTetro(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool CheckIsInsideGrid(Vector2 pos)
    {
        //if x position within 0 & gridWidth & not under y position 0.
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round (Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    string GetRandomTetro ()
    {
        int randomTetro = Random.Range(1, 8);

        string randomTetroName = "Prefabs/Tetromino_T";

        switch(randomTetro)
        {
            case 1:
                randomTetroName = "Prefabs/Tetromino_T";
                break;
            case 2:
                randomTetroName = "Prefabs/Tetromino_Long";
                break;
            case 3:
                randomTetroName = "Prefabs/Tetromino_Square";
                break;
            case 4:
                randomTetroName = "Prefabs/Tetromino_J";
                break;
            case 5:
                randomTetroName = "Prefabs/Tetromino_L";
                break;
            case 6:
                randomTetroName = "Prefabs/Tetromino_S";
                break;
            case 7:
                randomTetroName = "Prefabs/Tetromino_Z";
                break;
        }

        return randomTetroName;
    }
}
