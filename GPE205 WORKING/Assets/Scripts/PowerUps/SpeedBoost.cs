using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    
    // reference SpeedPowerup
    public SpeedPowerup powerup;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ////////////////////////////////////////////////////////////////////////////////////

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I have the suicide");

        other.gameObject.GetComponent<TankData>().health++;
        // get the powerup controller from the object that entered 
        PowerupController tempPUC = other.GetComponent<PowerupController>();
        // if this is not null
        if(tempPUC != null)
        {
            // apply powerup to object
            tempPUC.AddPowerup(powerup);
            // destroy the pickup
            Destroy(gameObject);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////
}
