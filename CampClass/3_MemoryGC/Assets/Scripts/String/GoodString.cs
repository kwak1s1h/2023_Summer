using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class GoodString : MonoBehaviour
{
    private string[] _testStr = {"a", "b", "c", "d", "e"};

    private StringBuilder _sb = new StringBuilder();

    private void Start()
    {
        _sb.Clear();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < 1000; i++)
            {
                ConcatExample(_testStr);
            }
        }
    }

    private string ConcatExample(string[] strArr)
    {
        _sb.Clear();

        for(int i = 0; i < strArr.Length; i++)
        {
            _sb.Append(strArr[i]);
        }

        return _sb.ToString();
    }
}
