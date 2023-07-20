using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyControls : MonoBehaviour
{
    Animator anim;
    float speed = 0.1f;

    readonly int _runningHash = Animator.StringToHash("running");

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey("up"))
        {
            anim.SetBool(_runningHash, true);
            this.transform.position += this.transform.forward * speed;
        }
        else if (Input.GetKey("down"))
        {
            anim.SetBool(_runningHash, true);
            this.transform.position -= this.transform.forward * speed;
        }
        else if (Input.GetKeyUp("up") || Input.GetKeyUp("down"))
        {
            anim.SetBool(_runningHash, false);
        }
    }
}
