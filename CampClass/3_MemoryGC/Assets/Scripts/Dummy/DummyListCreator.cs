using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyListCreator : MonoBehaviour
{
    public int NumberOfLists;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateLists();
        }
    }

    private void CreateLists()
    {
        for(int i = 0; i < NumberOfLists; i++)
        {
            List<string> nameList = new List<string>(NumberOfLists);
        }
    }
}
