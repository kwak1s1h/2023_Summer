using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class CoroutineCaching : MonoBehaviour
{
    public int MaxSpawnCount = 100;
    public float SpawnDelay = 0.1f;
    public GameObject CubePref;

    // Coroutine
    private int _spawnCount;
    private Vector3 _randomPos;
    private GameObject _newCube;

    private WaitForSeconds _spawnWFS;
    private Coroutine _spawnCoroutine;

    // Perfomance Time
    private Stopwatch _stopwatch = new Stopwatch();

    private void Start()
    {
        _spawnWFS = new WaitForSeconds(SpawnDelay);
        _spawnCoroutine = null;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_spawnCoroutine == null)
            {
                _spawnCoroutine = StartCoroutine(SpawnCo());
            }
        }
    }

    private IEnumerator SpawnCo()
    {
        Debug.Log("큐브생성 테스트 시작");

        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        _stopwatch.Reset();
        _stopwatch.Start();

        _spawnCount = MaxSpawnCount;
        while(_spawnCount > 0)
        {
            _randomPos = new Vector3(Random.value, Random.value, Random.value);
            _newCube = Instantiate(CubePref, _randomPos, Quaternion.identity);
            _newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            _newCube.transform.SetParent(transform);

            // yield return new WaitForSeconds(SpawnDelay);
            yield return _spawnWFS;

            _spawnCount--;
        }

        _stopwatch.Stop();
        Debug.Log("테스트 종료");
        Debug.Log(_stopwatch.ElapsedMilliseconds * 0.001f);
        _spawnCoroutine = null;
    }
}
