using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float speed = 3f;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
