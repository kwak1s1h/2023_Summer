using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    private Transform[] _tanks;
    
    public int _numberOfTanks = 100;

    public GameObject _tankPref;

    public Transform _player;

    private void Start()
    {
        _tanks = new Transform[_numberOfTanks];

        GameObject tank;
        for(int i = 0; i < _numberOfTanks; i++)
        {
            tank = Instantiate(_tankPref);
            tank.transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            _tanks[i] = tank.transform;
        }
    }

    private void Update()
    {
        foreach(Transform trm in _tanks)
        {
            trm.LookAt(_player);
            trm.Translate(0, 0, 0.05f);
        }
    }
}
