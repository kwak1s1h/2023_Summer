using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SpeedTest : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StringDemoFunc();
        }
    }

    private void StringDemoFunc()
    {
        // string s = "";
        StringBuilder sb = new StringBuilder();

        Debug.Log($"StartTime : {Time.time}");

        for(int i = 0; i < 100000; i++)
        {
            // s += "Hi ";
            sb.Append("Hi ");
        }

        Debug.Log($"EndTime : {Time.time}");

        Debug.Log(sb.ToString());
    }
}
