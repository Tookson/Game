using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        var sb = new StringBuilder();
        foreach (var key in dict.Keys)
        {
            sb.AppendLine($"{key}: {dict[key]}");
        }
        print(sb.ToString());
    }
    
}
