using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public TankData info;
    // allows this script to pull components and variables from TankData
    public float thrust = 150f;

     void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * thrust, ForceMode.Impulse);
    }

    void Update()
    {

    }

    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
