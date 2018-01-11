using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];


	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        SpawnNextTetro();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isFullRow (int y)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            if(grid[x,y] == null)
            {
                return false;
            }
        }
        //if not return false in for loop, grid is confirmed full
        return true;
    }

    public void DeleteMino (int y)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void MoveRowDown (int y) {
      
        for (int x = 0; x < gridWidth; x++)
        {
            if (grid[x,y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowsDown (int y)
    {
        for (int i = y; i < gridHeight; i++)
        {
            MoveRowDown(i);
        }
    }
    
    public void DeleteRow ()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            if(isFullRow(y))
            {
                DeleteMino(y);
                MoveAllRowsDown(y + 1);
                --y;
            }
        }
    }
    
    // for each colummn in each row check if null
    public void UpdateGrid (Tetramino tetramino)
    {
        for (int y = 0; y < gridHeight; ++y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                if(grid[x,y] != null)
                {
                    if(grid[x,y].parent == tetramino.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        
        foreach (Transform mino in tetramino.transform)
        {
            Vector2 pos = Round(mino.position);
            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    public Transform GetTransformAtGridPos (Vector2 pos)
    {
        if (pos.y > gridHeight -1)
        {
            return null;
        } else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }

    public void SpawnNextTetro ()
    {
        // load random tetro, positioned & rotated
        Debug.Log("hello");
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
