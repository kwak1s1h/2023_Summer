using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGCTest : MonoBehaviour
{
    private void Update()
    {
        CreateTanks();
        DestroyTanks();
    }

    private void DestroyTanks()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
        for(int i = 0; i < tanks.Length; i++)
        {
            Destroy(tanks[i]);
        }
    }

    private void CreateTanks()
    {
        for(int i = 0; i < 100; i++)
        {
            GameObject obj = new GameObject();
            obj.tag = "Tank";
        }
    }
}
