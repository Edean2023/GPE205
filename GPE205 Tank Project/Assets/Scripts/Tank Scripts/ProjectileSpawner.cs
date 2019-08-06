using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float fireDelay = 0.25f;
    float coolDownTimer;
    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;
        
        if (Input.GetButtonDown("Space") && coolDownTimer <=0)
        {
          coolDownTimer = fireDelay;
          Instantiate(projectile, transform.position, transform.rotation);
        }

    }
}
