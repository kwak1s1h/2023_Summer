using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTesting : MonoBehaviour
{
    private const int _numberOfTests = 5000;

    private Transform _testTrm;

    private void Update()
    {
        PerformanceTest1();
        PerformanceTest2();
        PerformanceTest3();
    }

    private void PerformanceTest1()
    {
        for(int i = 0; i < _numberOfTests; i++)
        {
            _testTrm = GetComponent<Transform>();
        }
    }

    private void PerformanceTest2()
    {
        for(int i = 0; i < _numberOfTests; i++)
        {
            // _testTrm = (Transform)GetComponent("Transform");
            _testTrm = GetComponent("Transform").transform;
        }
    }

    private void PerformanceTest3()
    {
        for(int i = 0; i < _numberOfTests; i++)
        {
            _testTrm = (Transform)GetComponent(typeof(Transform));
        }
    }
}
