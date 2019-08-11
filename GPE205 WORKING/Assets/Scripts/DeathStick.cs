using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStick : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //delete the player
        Destroy(other.GetComponent<Collider>().transform.parent.gameObject.transform.Find("BetterPlayer").gameObject);
    }
}
