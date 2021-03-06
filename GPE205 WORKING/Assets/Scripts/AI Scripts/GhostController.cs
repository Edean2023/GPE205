﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostController : AIController
{
    public TankData target;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TankData>();
        target = FindObjectOfType<Inputs>().pawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {

            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
        else
        {

            // switches state depending on what the current state is
            switch (currentState)
            {
                case AIstates.Shoot:
                    SeekPoint(target.tf.position);
                    // Do a special "Update" for that state
                    Shoot();

                    if (Vector3.Distance(target.tf.position, pawn.tf.position) > 7.0f)
                    {
                        Shoot();
                    }

                    break;
            }
        }

    }
   

}
