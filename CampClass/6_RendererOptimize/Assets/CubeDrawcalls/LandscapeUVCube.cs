using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeUVCube : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;

    public int width = 100;
    public int depth = 100;

    void Start()
    {
        CreateCubes();

        CombineAll();
    }

    private void CombineAll()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] instances = new CombineInstance[meshFilters.Length - 1];

        int i = 1;
        while(i < meshFilters.Length)
        {
            instances[i - 1].mesh = meshFilters[i].sharedMesh;
            instances[i - 1].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(instances);
        transform.gameObject.SetActive(true);
    }

    private void CreateCubes()
    {
        for (int z = 0; z < depth; z++)
        {
            for (int x = 0; x < width; x++)
            {
                float height = Mathf.PerlinNoise(x / 50f, z / 50f) * 50 + Mathf.PerlinNoise((x + 25) / 30f, (z + 25) / 30f) * 50;

                Vector3 pos = new Vector3(x, height, z);
                if (height > 60)
                    Instantiate(block1, pos, Quaternion.identity, transform);
                else if (height > 50)
                    Instantiate(block2, pos, Quaternion.identity, transform);
                else if (height > 30)
                    Instantiate(block3, pos, Quaternion.identity, transform);
                else
                    Instantiate(block4, pos, Quaternion.identity, transform);
            }
        }
    }
}
