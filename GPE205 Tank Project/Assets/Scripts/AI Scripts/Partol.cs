using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partol : AIController
{
    // Start is called before the first frame update
    void Start()
    {
        currentPatrolpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // switches state depending on what the current state is
        switch (currentState)
        {
            case AIstates.Idle:
                // do a special update for that state
                Idle();
                if (Time.time > startTime + 3.0f)
                {
                    ChangeState(AIstates.Patrol);
                }
                break;

            case AIstates.Patrol:
                // do a special update for that state
                Patrol();
                break;

        }
    }
        
    
}
