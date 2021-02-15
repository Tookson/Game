using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public string message = "Слоны летят на север";

    private void Start()
    {
        var dict = new Dictionary<char, int>();
        foreach (var ch in message)
        {
            if (dict.TryGetValue(ch, out int count))
            {
                dict[ch] = count + 1;
            }
            else
            {
                dict[ch] = 1;
            }
        }

        var str = "";
        foreach (var key in dict.Keys)
        {
            str += $"{key}: {dict[key]}\n";
        }
        print(str);
    }
    
}
