using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStick : MonoBehaviour
{
    public GameObject player;
   

    private void OnTriggerEnter(Collider other)
    {
        //delete the player
        Destroy(other.GetComponent<Collider>().transform.parent.gameObject.transform.Find("BetterPlayer").gameObject);
    }
}
