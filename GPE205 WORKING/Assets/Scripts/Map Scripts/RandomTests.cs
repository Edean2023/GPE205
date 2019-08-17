using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomTests : MonoBehaviour
{
    // sets default seed to 100
    public int seed = 100;
    // adds a map of day button 
    public bool map_of_day = false;
    // Randomizes the map every time
    public bool random_map = false;

    // Start is called before the first frame update
    void Start()
    {
        
        // gets the current date
        DateTime currentTime = DateTime.Now.Date;

        // if map of day is selected
        if (map_of_day)
        {
            // use map of day seed
            Random.InitState((int)currentTime.Ticks);
        }
        // if random map is not selected 
        else if (random_map)
        {
            // sets seed to system clock for 'Random seed'
            Random.InitState((int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));
        }
        else
        {
            // use seed it was given
            Random.InitState(seed);
        }
    }

   

    // Update is called once per frame
    void Update()
    {

    }
}
