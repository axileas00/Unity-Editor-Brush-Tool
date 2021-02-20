﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManagerCircle : MonoBehaviour
{

    
    [Tooltip("The prefab object you want to add")]
    public GameObject prefabGO;
     
  
    [Tooltip("The radius of the brush circle")]
    public float radius = 5f;
   

    [Tooltip("How many gameobjects you want to add")]
    public int howManyObjects = 5;

    //Should we add or remove objects within the circle
    public enum Actions { AddObjects, RemoveObjects }

    public Actions action;

    //Add a prefab that we instantiated in the editor script
    public void AddPrefab(GameObject newPrefabObj, Vector3 center)
    {
        //Get a random position within a circle in 2d space
        Vector2 randomPos2D = Random.insideUnitCircle * radius;

        //But we are in 3d, so make it 3d and move it to where the center is
        Vector3 randomPos = new Vector3(randomPos2D.x, 0f, randomPos2D.y) + center;

        newPrefabObj.transform.position = randomPos;

        newPrefabObj.transform.parent = transform;
    }

    //Remove objects within the circle
    public void RemoveObjects(Vector3 center)
    {
        //Get an array with all children to this transform
        GameObject[] allChildren = GetAllChildren();

        foreach (GameObject child in allChildren)
        {
            //If this child is within the circle
            if (Vector3.SqrMagnitude(child.transform.position - center) < radius * radius)
            {
                DestroyImmediate(child);
            }
        }
    }

    //Remove all objects
    public void RemoveAllObjects()
    {
        //Get an array with all children to this transform
        GameObject[] allChildren = GetAllChildren();

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child);
        }
    }

    //Get an array with all children to this GO
    private GameObject[] GetAllChildren()
    {
        //This array will hold all children
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Fill the array
        int childCount = 0;
        foreach (Transform child in transform)
        {
            allChildren[childCount] = child.gameObject;
            childCount += 1;
        }

        return allChildren;
    }
}