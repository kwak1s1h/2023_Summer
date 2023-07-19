using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyObjectCreator : MonoBehaviour
{
    public int NumberOfObjects = 1000;

    private GameObject _dummyObj;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateObjects();
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            DestroyObjects();
            GC.Collect();
        }
    }

    private void DestroyObjects()
    {
        GameObject[] dummyObjs = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject obj in dummyObjs)
        {
            Destroy(obj);
        }
    }

    private void CreateObjects()
    {
        for(int i = 0; i < NumberOfObjects; i++)
        {
            _dummyObj = new GameObject("A_Dummy");
            _dummyObj.tag = "Player";
        }
    }
}
