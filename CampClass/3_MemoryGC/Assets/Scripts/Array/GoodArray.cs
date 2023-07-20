using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodArray : MonoBehaviour
{
    private float[] _randResults;
    public int NumberOfCount = 10000;

    private void Start()
    {
        _randResults = new float[NumberOfCount];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RandomArray(_randResults);
        }
    }

    private void RandomArray(float[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = Random.Range(0f, arr.Length);
        }
    }
}
