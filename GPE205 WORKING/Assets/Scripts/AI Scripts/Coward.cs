using UnityEngine;
using System.Collections;

public class Coward : AIController
{
    public TankData target;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TankData>();
        currentPatrolpoint = 0;
        target = FindObjectOfType<Inputs>().pawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { Destroy(gameObject); }
        else
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
                    if (Vector3.Distance(target.tf.position, pawn.tf.position) < 7.0f)
                    {
                        ChangeState(AIstates.Flee);
                    }

                    break;

                case AIstates.Flee:
                    SeekPoint(-target.tf.position);


                    if (Vector3.Distance(target.tf.position, pawn.tf.position) > 10.0f)
                    {
                        ChangeState(AIstates.Patrol);
                    }

                    break;
            }
        }
    }
    
}