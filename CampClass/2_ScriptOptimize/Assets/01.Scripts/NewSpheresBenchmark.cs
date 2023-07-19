using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpheresBenchmark : MonoBehaviour
{
    public int _numberOfSpheres = 100;

    private Transform[] _spheres;

    private void Start()
    {
        _spheres = new Transform[_numberOfSpheres];

        for(int i = 0; i < _numberOfSpheres; ++i)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Material mat = new Material(Shader.Find("Specular"));
            mat.color = Color.red;
            ((Renderer)obj.GetComponent("Renderer")).material = mat;
            _spheres[i] = obj.transform;
            _spheres[i].position = Random.insideUnitSphere * 20;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < _spheres.Length; ++i)
            {
                _spheres[i].position += Vector3.forward;
            }
        }
    }
}
