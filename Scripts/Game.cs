using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public static int gridWidth = 10;
    public static int gridHeight = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnNextTetromino ()
    {
        GameObject nextTetro = (GameObject)Instantiate()
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

        string randomTetroName = "Tetromino_T";

        switch(randomTetro)
        {
            case 1:
                randomTetroName = "Tetromino_T";
                break;
            case 2:
                randomTetroName = "Tetromino_Long";
                break;
            case 3:
                randomTetroName = "Tetromino_Square";
                break;
            case 4:
                randomTetroName = "Tetromino_J";
                break;
            case 5:
                randomTetroName = "Tetromino_L";
                break;
            case 6:
                randomTetroName = "Tetromino_S";
                break;
            case 7:
                randomTetroName = "Tetromino_Z";
                break;
        }

        return randomTetroName;
    }
}
