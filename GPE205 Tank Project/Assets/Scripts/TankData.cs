using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////////////////////////

    // list of the different components that other scripts can pull from
    [Header("Comps")]
    public Transform transform;
    public TankManager mover;
    public GameObject TankBullet1;


    ////////////////////////////////////////////////////////////////////////////////////

    // list of the different variables that other scripts can pull from
    [Header("Vars")]
    public float movementSpeed; 
    public float reverseMovementSpeed;
    public float roatationSpeed;
    public float health = 2;
    ////////////////////////////////////////////////////////////////////////////////////

    // is called when the script instance is loaded
    // tells what transform and mover do
    private void Awake()
    {
        transform = GetComponent<Transform>();
        mover = GetComponent<TankManager>();
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
}
