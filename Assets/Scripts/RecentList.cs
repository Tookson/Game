using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecentList : MonoBehaviour
{
    public Color color1 = Color.white;
    public Color color2 = Color.green;
    public Color color3 = Color.red;
    public Color color4 = Color.blue;
    public Color color5 = Color.black;
    public virtual int Count { get; }
    public List<string> recentList;

    private void OnTriggerEnter(Collider other)
    {
        string objName = other.name;
        bool isVisited = recentList.Contains(objName);
        Renderer renderer = other.GetComponent<Renderer>();
        if (isVisited)
        {
            renderer.material.color = color2;
        }
        else
        {
            renderer.material.color = color1;
        }

        if (Count == 10)
        {
            renderer.material.color = color4;
        }

        if (isVisited)
        {
            recentList.Remove(objName);
        }
        else
        {
            recentList.Add(objName);
        }
    }
}