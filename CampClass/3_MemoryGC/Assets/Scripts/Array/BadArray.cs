using UnityEngine;
using Random = UnityEngine.Random;

public class BadArray : MonoBehaviour
{
    private float[] _randResults;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _randResults = RandomList(10000);
        }
    }

    private float[] RandomList(int v)
    {
        float[] result = new float[v];
        for(int i = 0; i < v; i++)
        {
            result[i] = Random.Range(0f, v);
        }
        return result;
    }
}
