using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecentList : MonoBehaviour
{
    public Color[] colors = new Color[] {Color.gray, Color.green, Color.blue};

    public GameObject Sphere;

    public GameObject[] cubes;

    private Dictionary<string, CubeInfo> _cubes = new Dictionary<string, CubeInfo>();


    private void Start()
    {
        foreach (var cube in cubes)
        {
            var info = new CubeInfo();
            info.name = cube.name;
            info.color = Color.white;
            info.visitCount = 0;
            _cubes[info.name] = info;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string objName = other.name;
        Renderer renderer = other.GetComponent<Renderer>();

        if (_cubes.TryGetValue(objName, out var info))
        {
            info.visitCount++;

            info.color = colors[(info.visitCount - 1) % colors.Length];
            renderer.material.color = info.color;

            var baseColor = info.color;
            var allColorsSame = true;
            foreach (var cubeInfo in _cubes.Values)
            {
                if (cubeInfo.color != baseColor)
                {
                    allColorsSame = false;
                    break;
                }
            }

            if (allColorsSame)
            {
                Sphere.GetComponent<Renderer>().material.color = baseColor;
            }
        }
    }

    private class CubeInfo
    {
        public string name;
        public Color color;
        public int visitCount;
    }
}