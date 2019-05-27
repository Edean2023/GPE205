using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    // allows this script to pull components and variables from TankData
    public TankData data;
    private CharacterController tankController;

    ////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        tankController = GetComponent<CharacterController>();
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void OnTriggerEnter()
    {
        data.health--;
        if (data.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
   
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void Movement (Vector3 movementDirection)
    {
        Vector3 moveDirection = data.transform.TransformDirection(movementDirection);

        tankController.SimpleMove(moveDirection * data.movementSpeed);
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void Rotate (float direction)
    {
        data.transform.Rotate(new Vector3(0, direction * data.roatationSpeed * Time.deltaTime, 0));
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    
}



