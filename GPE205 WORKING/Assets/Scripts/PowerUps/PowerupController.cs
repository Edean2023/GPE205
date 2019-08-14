using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public List<Powerup> powerups;
    

    ////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        
    }

    ////////////////////////////////////////////////////////////////////////////////////

    // Update is called once per frame
    void Update()
    {
        HandlePowerupTimer();
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void HandlePowerupTimer()
    {
        List<Powerup> toBeRemoved = new List<Powerup>();

        // countdown timer
        foreach (Powerup temp in powerups)
        {
            temp.remainingTime -= Time.deltaTime;
            // if the timer is less than or equal to 0
            if (temp.remainingTime <= 0)
            {
                // add everything to a different list
                toBeRemoved.Add(temp);
            }
        }
        // remove everything from toBeRemoved
        foreach (Powerup temp in toBeRemoved)
        {
            // duh
            RemovePowerup(temp);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void RemovePowerup(Powerup powerup)
    {
        
        // calls the remove
        powerup.OnRemovePowerup(gameObject);
        // remove the powerup from the list
        powerups.Remove(powerup);
    }

    ////////////////////////////////////////////////////////////////////////////////////

    public void AddPowerup(Powerup powerup)
    {
       
        // adds the powerup to the list
        powerups.Add(powerup);
        // call the apply for that powerup
        powerup.OnApplyPowerup(gameObject);
    }

    ////////////////////////////////////////////////////////////////////////////////////

}


