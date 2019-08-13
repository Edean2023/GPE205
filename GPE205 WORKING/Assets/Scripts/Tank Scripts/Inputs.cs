using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    // sets the enum for the 2 different control schemes 
    // makes it easy to switch between the two in Unity
    public enum Controls {WASD, Arrows, None};

    // allows this script to pull components and variables from TankData
    public TankData pawn;
    public AudioSource someSound;
    public Controls controls;

    ////////////////////////////////////////////////////////////////////////////////////

    // is called when the script instance is loaded
    private void Awake()
    {
        
    }

    ////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        
    }

    ////////////////////////////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // if the control scheme is set to WASD then do this
        if (controls == Controls.WASD)
        {
            // set the movement for W to forward
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += Vector3.forward;
            }

            // set the movement for S to reverse
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection += -Vector3.forward;
            }

            // set the movement for A to rotate left
            if (Input.GetKey(KeyCode.A))
            {
                pawn.mover.Rotate(-pawn.roatationSpeed * Time.deltaTime);
            }

            // set the movement for A to rotate right
            if (Input.GetKey(KeyCode.D))
            {
                pawn.mover.Rotate(pawn.roatationSpeed * Time.deltaTime);
            }

           
            else if (controls == Controls.Arrows)
            {
                // set the movement for Up Arrow to forward
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    moveDirection += Vector3.forward;
                }

                // set the movement for Down Arrow to reverse
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    moveDirection += -Vector3.forward;
                }

                // set the movement for Left Arrow to rotate left
                if (Input.GetKey(KeyCode.K))
                {
                    pawn.mover.Rotate(-pawn.roatationSpeed * Time.deltaTime);
                }

                // set the movement for Right Arrow to rotate right
                if (Input.GetKey(KeyCode.L))
                {
                    pawn.mover.Rotate(pawn.roatationSpeed * Time.deltaTime);
                }
            }
            // tells the mover to move to the final direction
            pawn.mover.Movement(moveDirection);

        }
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
}
