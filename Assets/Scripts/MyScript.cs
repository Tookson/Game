using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{

    public Transform target;
    public Rigidbody targetRigidbody;
    public int targetFrameRate = 30;
    public float jumpPower = 1f;
    public bool inJump;

    private Vector3 startPosition;
    private Vector3 savePosition;

    void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        startPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            int i = 0;
            while (i < 10)
            {
                print(i);
                i++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Respawn();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePosition();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPosition();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log(targetRigidbody.velocity.magnitude);
        }

        // var horizontal = Input.GetAxis("Vertical");
        // var vertical = Input.GetAxis("Horizontal");
        // target.position += new Vector3(-vertical, 0, -horizontal);
    }

    void Respawn()
    {
        target.position = startPosition;
    }

    void SavePosition()
    {
        savePosition = target.position;
    }

    void LoadPosition()
    {
        target.position = savePosition;
    }

    void Jump()
    {
        if (inJump) return;
        inJump = true;
        targetRigidbody.AddForce(new Vector3(0, jumpPower, 0));
    }

    private void OnCollisionEnter(Collision other)
    {
        inJump = false;
        Debug.Log("OnCollisionEnter " + other.gameObject.name);
    }

}