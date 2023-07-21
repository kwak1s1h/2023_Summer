using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectionTest : MonoBehaviour
{
    private const int _numberOfTests = 10000;
    
    private int[] _inventory = new int[_numberOfTests];

    Dictionary<int, int> _inventoryDict = new Dictionary<int, int>();
    List<int> _inventoryList = new List<int>();
    HashSet<int> _inventoryHashSet = new HashSet<int>();

    private void Start()
    {
        AddValuesInArray();
        AddValuesInDictionary();
        AddValuesInList();
        AddValuesInHashSet();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PrintValuesInArray();
            PrintValuesInDictionary();
            PrintValuesInList();
            PrintValuesInHashSet();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            ContainsValuesInArray();
            ContainsValuesInDictionary();
            ContainsValuesInList();
            ContainsValuesInHashSet();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            RemoveValuesInArray();
            RemoveValuesInDictionary();
            RemoveValuesInList();
            RemoveValuesInHashSet();
        }
    }

    #region Remove

    private void RemoveValuesInHashSet()
    {
        int v = 5000;
        _inventoryHashSet.Remove(v);
    }

    private void RemoveValuesInList()
    {
        int v = 5000;
        _inventoryList.Remove(v);
    }

    private void RemoveValuesInDictionary()
    {
        int v = 5000;
        _inventoryDict.Remove(v);
    }

    private void RemoveValuesInArray()
    {
        int idx = 5000;
        int tempCnt = 0;
        int[] temp = new int[_inventory.Length - 1];
        for(int i = 0; i < _inventory.Length; i++)
        {
            if(i != idx)
            {
                temp[tempCnt] = _inventory[i];
                tempCnt++;
            }
        }
        _inventory = temp;
    }

    #endregion

    #region Contains

    private void ContainsValuesInDictionary()
    {
        int search = 5000;
        bool bFound = _inventoryDict.ContainsKey(search);
    }

    private void ContainsValuesInHashSet()
    {
        int search = 5000;
        bool bFound = _inventoryHashSet.Contains(search);
    }

    private void ContainsValuesInList()
    {
        int search = 5000;
        bool bFound = _inventoryList.Contains(search);
    }

    private void ContainsValuesInArray()
    {
        int search = 5000;
        foreach(int i in _inventory)
        {
            if(i == search) return;
        }
    }

    #endregion

    #region Print

    private void PrintValuesInHashSet()
    {
        foreach(int i in _inventoryHashSet)
        {
            Debug.Log(i);
        }
    }

    private void PrintValuesInList()
    {
        foreach(int i in _inventoryList)
        {
            Debug.Log(i);
        }
    }

    private void PrintValuesInDictionary()
    {
        foreach(KeyValuePair<int, int> i in _inventoryDict)
        {
            Debug.Log(i.Value);
        }
    }

    private void PrintValuesInArray()
    {
        foreach(int i in _inventory)
        {
            Debug.Log(i);
        }
    }

    #endregion

    #region Add

    private void AddValuesInHashSet()
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            _inventoryHashSet.Add(Random.Range(10, 100));
        }
    }

    private void AddValuesInList()
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            _inventoryList.Add(Random.Range(10, 100));
        }
    }

    private void AddValuesInDictionary()
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            _inventoryDict.Add(i, Random.Range(10, 100));
        }
    }

    private void AddValuesInArray()
    {
        for(int i = 0; i < _inventory.Length; i++)
        {
            _inventory[i] = Random.Range(10, 100);
        }
    }

    #endregion
}
