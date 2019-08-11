using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////

    // list of the different components that other scripts can pull from
    [Header("Comps")]
    public Transform tf;
    public TankManager mover;
    public Shooter shoot;

    ////////////////////////////////////////////////////////////////////////////////////

    // list of the different variables that other scripts can pull from
    [Header("Vars")]
    public float movementSpeed; 
    public float reverseMovementSpeed;
    public float roatationSpeed;
    public float health = 2;
    public float fireCooldown = 1.5f;

    ////////////////////////////////////////////////////////////////////////////////////

    [Header("GameObjects")]
    public GameObject bulletPrefab;
    public GameObject thisTank;

    ////////////////////////////////////////////////////////////////////////////////////

    // is called when the script instance is loaded
    // tells what transform and mover do
    private void Awake()
    {
        tf = GetComponent<Transform>();
        mover = GetComponent<TankManager>();
        shoot = GetComponent<Shooter>();
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
       
    }

   /* public static implicit operator TankData(GameObject v)
    {
        throw new NotImplementedException();
    }
    */
}
