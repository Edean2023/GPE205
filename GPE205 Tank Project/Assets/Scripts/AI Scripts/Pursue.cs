using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : AIController
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

        switch (currentState)
        {
            case AIstates.Idle:
                Idle();

                if (Time.time > startTime + 3.0f)
                {
                    ChangeState(AIstates.Chase);
                }
                break;

            case AIstates.Chase:

                SeekPoint(target.tf.position);

                if (Vector3.Distance(target.tf.position, pawn.tf.position) > 5.0f)
                {
                    //ChangeState(AIstates.Shoot);
                }
                break;

            // put shooting here

               
        }
    }
}
