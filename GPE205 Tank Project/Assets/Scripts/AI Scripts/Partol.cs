using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partol : AIController
{
    public TankData target;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TankData>();
        currentPatrolpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { target = GameObject.FindObjectOfType<Inputs>().pawn; }

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
                if (Vector3.Distance(target.tf.position, pawn.tf.position) < 7.0f)
                {
                    ChangeState(AIstates.Chase);
                }
                break;

            case AIstates.Chase:
                SeekPoint(target.tf.position);
               
                if (Vector3.Distance(target.tf.position, pawn.tf.position) > 10.0f)
                {
                    ChangeState(AIstates.Patrol);                  
                }
                break;
        }
    }
        
    
}
