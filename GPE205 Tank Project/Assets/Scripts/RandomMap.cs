using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    public int OpeningDirection;

    private RoomTemplates _templates;
    private int rand;
    private bool spawned = false;
    void Start()
    {
        _templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Spawn();
        
        // Invoke("Spawn", 0.1f);
    }

  private void Spawn()
    {
        if (spawned != false) return;
        switch (OpeningDirection)
        {
            case 1:
                rand = Random.Range(0, _templates.topRooms.Length);
                Instantiate(_templates.topRooms[rand], transform.position, transform.rotation);
                break;
            case 2:
                rand = Random.Range(0, _templates.bottomRooms.Length);
                Instantiate(_templates.bottomRooms[rand], transform.position, transform.rotation);
                break;
            case 3:
                rand = Random.Range(0, _templates.leftRooms.Length);
                Instantiate(_templates.leftRooms[rand], transform.position, transform.rotation);
                break;
            case 4:
                rand = Random.Range(0, _templates.rightRooms.Length);
                Instantiate(_templates.rightRooms[rand], transform.position, transform.rotation);
                break;
            default:
                break;
        }
        spawned = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint")) 
        {
            Destroy(gameObject);
        }
    }
}
