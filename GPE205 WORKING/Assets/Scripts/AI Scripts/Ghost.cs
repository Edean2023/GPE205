﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public TankData pawn;
    Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //Hunt();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(Player.position - transform.position), pawn.roatationSpeed * Time.deltaTime);

            transform.position += transform.forward * pawn.movementSpeed * Time.deltaTime;
        }
    }

}
