using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheresBenchmark : MonoBehaviour
{
    public int _numberOfSpheres = 100;

    private void Start()
    {
        for(int i = 0; i < _numberOfSpheres; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material = new Material(Shader.Find("Specular"));
            renderer.material.color = Color.red;
            obj.transform.position = Random.insideUnitSphere * 20;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Transform[] spheres = GameObject.FindObjectsOfType<Transform>();
            foreach(Transform trm in spheres)
            {
                trm.Translate(0, 0, 1f);
            }
        }
    }
}