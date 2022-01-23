using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandling : MonoBehaviour
{
    public int wave = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            wave += 1;
        }
        
    }
}
