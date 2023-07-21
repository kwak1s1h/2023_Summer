using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCStruct
{
    public GameObject _avatar;
    public string _name;
    public int _health;

    public NPCStruct(string name, GameObject go)
    {
        _name = name;
        _health = 100;
        _avatar = go;
    }
}

public class NPCClass
{
    public GameObject _avatar;
    public string _name;
    public int _health;

    public NPCClass(string name, GameObject go)
    {
        _name = name;
        _health = 100;
        _avatar = go;
    }
}

public class NPCTypes : MonoBehaviour
{
    private const int _numberOfTests = 100000;

    NPCStruct[] _npcs = new NPCStruct[_numberOfTests];
    NPCClass[] _npcc = new NPCClass[_numberOfTests];

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateStructs();
            CreateClasses();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PassStructs();
            PassClasses();
        }
    }

    #region Pass

    private void PassStructs()
    {
        for (int i = 0; i < _npcs.Length; i++)
        {
            UseStruct(_npcs[i]);
        }
    }

    private void PassClasses()
    {
        for (int i = 0; i < _npcc.Length; i++)
        {
            UseClass(_npcc[i]);
        }
    }

    #endregion

    #region Use

    private void UseStruct(NPCStruct npc)
    {

    }

    private void UseClass(NPCClass npc)
    {

    }

    #endregion

    #region Create

    private void CreateStructs()
    {
        for(int i = 0; i < _npcs.Length; i++)
        {
            _npcs[i] = new NPCStruct("곽석현", null);
        }
    }

    private void CreateClasses()
    {
        for(int i = 0; i < _npcc.Length; i++)
        {
            _npcc[i] = new NPCClass("곽석현", null);
        }
    }

    #endregion
}
