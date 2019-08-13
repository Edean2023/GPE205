using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TankData))]
public class TankManager : MonoBehaviour
{
    // allows this script to pull components and variables from TankData
    public TankData data;
    private CharacterController tankController;

    ////////////////////////////////////////////////////////////////////////////////////

    GameObject powerup;


    // Start is called before the first frame update
    void Start()
    {
        powerup = GameObject.FindWithTag("powerup");
        data = GetComponent<TankData>();
        tankController = GetComponent<CharacterController>();
    }


    ////////////////////////////////////////////////////////////////////////////////////

     private void OnTriggerEnter()
     {
         data.health--; 
   
        // if health is less than zero kill the game object 
       
        if (data.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy") == null && GameObject.FindWithTag("Player") != null)
        {
            SceneManager.LoadScene("Win");
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void Movement (Vector3 movementDirection)
    {
        Vector3 moveDirection = data.tf.TransformDirection(movementDirection);

        tankController.SimpleMove(moveDirection * data.movementSpeed);
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void Rotate (float direction)
    {
        data.tf.Rotate(new Vector3(0, direction * data.roatationSpeed * Time.deltaTime, 0));
    }

    ////////////////////////////////////////////////////////////////////////////////////
    
    public void RotateTowards(Vector3 lookvector)
    {
        // finds the vector to target
        Vector3 vectorToTarget = lookvector;
        // Finds the quaternion to look down that vector
        Quaternion targetQuaternion = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        // Sets the rotation to "partway towards" that quaternion 
        data.tf.rotation =
            Quaternion.RotateTowards(data.tf.rotation, targetQuaternion, data.roatationSpeed * Time.deltaTime);
                
    }

}



