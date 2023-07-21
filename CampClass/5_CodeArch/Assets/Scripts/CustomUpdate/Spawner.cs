using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdate
{
    public class Spawner : MonoBehaviour
    {
        public bool UseUpdateManager = false;

        public GameObject SpawnPrefab;
        public int SpawnCount = 100;

        private void Start()
        {
            SpawnObjects(SpawnCount);
        }

        private void SpawnObjects(int count)
        {
            for(int i = 0; i < count * 2; i += 2)
            {
                for(int j = 0; j < count * 2; j += 2)
                {
                    if(i == 2 && j == 2) continue;

                    GameObject obj = Instantiate(SpawnPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                    if(UseUpdateManager)
                    {
                        obj.AddComponent<ManagedMover>();
                    }
                    else
                    {
                        obj.AddComponent<Mover>();
                    } 
                }
            }
        }
    }
}
