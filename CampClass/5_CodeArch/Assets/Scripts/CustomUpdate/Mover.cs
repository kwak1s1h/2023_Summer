using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdate
{
    public class Mover : MonoBehaviour
    {
        private float _speed;

        private void Awake()
        {
            _speed = Random.Range(1f, 1.1f);
        }

        private void Update()
        {
            MoveUpAndDown();
        }

        private void MoveUpAndDown()
        {
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(
                currentPos.x, 
                Mathf.PingPong(Time.time * _speed, 10f), 
                currentPos.z
            );
        }
    }
}
