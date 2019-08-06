using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerup : Powerup
{
    // set float for adjustable speed
    public float boostSpeed;

    // gets movement speed data from TankData and applies the boost
    public override void OnApplyPowerup(GameObject target)
    {
        TankData tempData = target.GetComponent<TankData>();
        tempData.movementSpeed += boostSpeed;
    }

    // gets movement speed data from TankData and removes the boost
    public override void OnRemovePowerup(GameObject target)
    {
        TankData tempData = target.GetComponent<TankData>();
        tempData.movementSpeed -= boostSpeed;
    }


}
