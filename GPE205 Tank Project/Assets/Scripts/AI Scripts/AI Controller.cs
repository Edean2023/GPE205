using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public TankData pawn;
    // this will allow the developer to easily change what state an AI tank will have
    public enum AIstates
    {
        Patrol, Chase, Flee, Idle
    }

    // this will allow the developer to easily change how the AI avoids obstacles
    public enum AIAvoidanceState
    {
        moveToAvoid, turnToAvoid, none
    }

    public enum loopTypes
    {
        Loop, Stop, PingPong, Random
    }
    ////////////////////////////////////////////////////////////////////////////////////

    public loopTypes loopType;
    public List<Transform> patrolpoints;
    public int currentPatrolpoint;
    public float cutoff;
    public bool isForward;
    public float startTime;
    public AIstates currentState;

    // obstacle avoidence
    public AIAvoidanceState currentAvoidanceState = AIAvoidanceState.none;
    public float avoidMoveTime;
    public float startAvoidTime;
    public float feelerDistance;

    ////////////////////////////////////////////////////////////////////////////////////

    public void ChangeState(AIstates newState)
    {
        startTime = Time.time;
        currentState = newState;

        currentAvoidanceState = AIAvoidanceState.none;
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void ChangeAvoidState(AIAvoidanceState newState)
    {
        startAvoidTime = Time.time;
        currentAvoidanceState = newState;
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public bool isBlocked()
    {
        if (Physics.Raycast(pawn.tf.position, pawn.tf.forward, feelerDistance))
        {
            return true;
        }

        return false;
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void Idle()
    {
        // AI does nothing
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void Seek(Transform target)
    {
        switch (currentAvoidanceState)
        {
            case AIAvoidanceState.none:
                // chases
                Vector3 targetVector = (target.position - pawn.tf.position).normalized;
                pawn.mover.RotateTowards(targetVector);
                pawn.mover.Movement(Vector3.forward);

                // if the AI is blockecd by something, it will turn to avoid it
                if (isBlocked())
                {
                    // Change the avoid state to 'turnToAvoid'
                    ChangeAvoidState(AIAvoidanceState.turnToAvoid);
                }
                break;
            case AIAvoidanceState.turnToAvoid:
                // rotation
                pawn.mover.Rotate(1);

                // if it is NOT blocked
                if (!isBlocked())
                {
                    // changes the avoid state to move to avoid
                    ChangeAvoidState(AIAvoidanceState.moveToAvoid);
                }
                break;
            case AIAvoidanceState.moveToAvoid:
                // forward movement
                pawn.mover.Movement(Vector3.forward);
                // if it is blocked
                if (isBlocked())
                {
                    // changes the avoid state to turn to avoid
                    ChangeAvoidState(AIAvoidanceState.turnToAvoid);
                }

                // if time is greater than startAvoidTime plus avoidMoveTime
                if (Time.time > startAvoidTime + avoidMoveTime)
                {
                    // change avoid state to none
                    ChangeAvoidState(AIAvoidanceState.none); 
                }
                break;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void SeekPoint(Vector3 targetPoint)
    {
        Vector3 targetVector = (targetPoint - pawn.tf.position).normalized;
        pawn.mover.RotateTowards(targetVector);
        pawn.mover.Movement(Vector3.forward);
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void Flee(Transform target)
    {
        // finds a vector to target
        Vector3 targetVector = (target.position - pawn.tf.position);
        // finds the opposite of that vector
        Vector3 awayVector = -targetVector;
        // Rotate towards that vector
        pawn.mover.RotateTowards(awayVector);
        // Move forward
        pawn.mover.Movement(Vector3.forward);
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void Patrol()
    {
        // go towards the targeted patrol point
        Seek(patrolpoints[currentPatrolpoint]);
        if (Vector3.Distance(pawn.tf.position, patrolpoints[currentPatrolpoint].position) <= cutoff)
        {
            // move to the next one
            if (isForward)
            {
                currentPatrolpoint++;
            }
            else
            {
                currentPatrolpoint--;
            }
            // if the AI is out of the bounds of the patrol points
            if (currentPatrolpoint >= patrolpoints.Count || currentPatrolpoint < 0)
            {
                // adjust loop type
                if (loopType == loopTypes.Loop)
                {
                    currentPatrolpoint = 0;
                }
                else if (loopType == loopTypes.Random)
                {
                    currentPatrolpoint = Random.Range(0, patrolpoints.Count);
                }
                else if (loopType == loopTypes.PingPong)
                {
                    isForward = !isForward;
                    if (currentPatrolpoint >= patrolpoints.Count)
                    {
                        currentPatrolpoint = patrolpoints.Count - 1;
                    }
                    else
                    {
                        currentPatrolpoint = 0;
                    }
                }
            }

        }
    }

    ////////////////////////////////////////////////////////////////////////////////////


}
