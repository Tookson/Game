using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameTimer gameTimer;
    public Flash flash;
    
    private void OnTriggerEnter(Collider other)
    {
        gameTimer.ResetTimer();

        if (flash != null)
        {
            flash.Animate();
        }
    }
}
