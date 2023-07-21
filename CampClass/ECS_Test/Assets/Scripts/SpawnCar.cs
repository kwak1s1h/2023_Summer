using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject _carPrefab;
    public GameObject _camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = new Vector3(10, 10, 10);
            GameObject c = Instantiate(_carPrefab, pos, Quaternion.identity);
            _camera.GetComponent<SmoothFollow>().target = c.transform;
        }
    }
}
