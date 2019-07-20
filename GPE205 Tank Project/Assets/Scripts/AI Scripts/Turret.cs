using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : AIController
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

        if (currentState == AIstates.Idle)
        {
            pawn.mover.Rotate(-pawn.roatationSpeed * Time.deltaTime);
        }

        // switches state depending on what the current state is
        switch (currentState)
        {
            case AIstates.Patrol:
                // do a special update for that state
                Patrol();
                if (Time.time > startTime + 11.0f)
                {
                    ChangeState(AIstates.Idle);
                }
                break;

            case AIstates.Idle:
                Idle();
                
                if (Vector3.Distance(target.tf.position, pawn.tf.position) < 10.0f)
                {
                    ChangeState(AIstates.Shoot);
                }
                break;

            case AIstates.Shoot:
                SeekPoint(target.tf.position);
                // Do a special "Update" for that state
                Shoot();

                if (Vector3.Distance(target.tf.position, pawn.tf.position) > 7.0f)
                {
                    ChangeState(AIstates.Patrol);
                }

                break;

        }
    }
}
