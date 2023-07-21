using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject _cubePrefab;
    public int _width;
    public int _depth;

    void Start()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _depth; z++)
            {
                GameObject instance = Instantiate(_cubePrefab);
                Vector3 pos = new Vector3(x, Mathf.PerlinNoise(x * 0.21f, z * 0.21f), z);
                instance.transform.position = pos;
            }
        }
    }
}
