using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSound : MonoBehaviour
{
    public TankData data;
    public AudioSource sound;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            sound.Play();
        }

    }
}
