﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino : MonoBehaviour {

    float fall = 0;
    public float fallSpeed = 1;

    public bool allowRotation = true;
    public bool limitRotation = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UserInput();
	}

    void UserInput ()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (CheckIsValidPosition())
            {
               FindObjectOfType<Game>().UpdateGrid(this);
            } else
            {
                transform.position += new Vector3(-1, 0, 0);

            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        } else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            if (CheckIsValidPosition())
            {
                FindObjectOfType<Game>().UpdateGrid(this);
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                FindObjectOfType<Game>().DeleteRow();

                enabled = false;
                Debug.Log("Input down Spawn");
                FindObjectOfType<Game>().SpawnNextTetro();
            }

            fall = Time.time;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (allowRotation)
            {
                if (limitRotation)
                {
                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
                if (CheckIsValidPosition())
                  {
                    FindObjectOfType<Game>().UpdateGrid(this);
                }
                else
                  {
                   if (limitRotation)
                    {
                        if (transform.rotation.eulerAngles.z >= 90)
                        {
                            transform.Rotate(0, 0, -90);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    } else
                    {
                        transform.Rotate (0, 0, -90);
                    }

                  }
                
            }
            
        }
    }

    bool CheckIsValidPosition ()
    {
        foreach (Transform mino in transform)
        {
            // rounded value of current game object
            Vector2 pos = FindObjectOfType<Game>().Round(mino.position);

            // if not inside grid, return false
            if(FindObjectOfType<Game>().CheckIsInsideGrid (pos) == false)
            {
                Debug.Log("Boolean false 1. Not insideGrid.");
                return false;
            }
            if (FindObjectOfType<Game>().GetTransformAtGridPos(pos) != null && FindObjectOfType<Game>().GetTransformAtGridPos(pos).parent != transform)
            {
                Debug.Log("Boolean false 2. Not inside grid + not mino");
                return false;
            }
        }

        return true;
    }
}
