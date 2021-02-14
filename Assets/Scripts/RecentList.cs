using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecentList : MonoBehaviour
{
    public Color color1 = Color.gray;
    public Color color2 = Color.green;
    public Color color3 = Color.blue;
    public List<string> recentList;
    public virtual int Count { get; }
    public GameObject Sphere;

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

        if (recentList.Count == 10) 
        {
            Sphere.GetComponent<SpriteRenderer>().color = new Color(100, 100, 100, 100);
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