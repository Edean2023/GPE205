using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : AIController
{
    public TankData target;
    // Start is called before the first frame update
    void Start()
    {

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
                if (Vector3.Distance(target.tf.position, pawn.tf.position) < 7.0f)
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
                    ChangeState(AIstates.Idle);
                }
                break;
        }
    }
}
