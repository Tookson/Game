using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecentList : MonoBehaviour
{ public  int Count;
    
    public Color color1 = Color.gray;
    public Color color2 = Color.green;
    public List<string> recentList;

    private void OnTriggerEnter(Collider other)
    {
        string objName = other.name;
        bool isVisited = recentList.Contains(objName);
        Renderer renderer = other.GetComponent<Renderer>();
        if (isVisited)
        {
            renderer.material.color = color2;
            Count = Count + 1;
            if (Count == 10)
            {
                Color Sphere = color2;
            }
        }
        else
        {
            renderer.material.color = color1;
        }
        if (Count == 10 )
        {
            Color Sphere = color2;
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