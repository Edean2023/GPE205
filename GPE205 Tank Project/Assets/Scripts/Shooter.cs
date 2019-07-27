using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Transform firePoint;
    private float lastFireTime;

    private TankData data;

    // Start is called before the first frame update
    void Start()
    {
        // Set our data component
        data = GetComponent<TankData>();

        // Set our last fire time
        lastFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(GameObject bulletPrefab)
    {
        if (Time.time > lastFireTime + data.fireCooldown)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            Bullet bulletData = bullet.GetComponent<Bullet>();
            
            if (bulletData != null)
            {
                bulletData.shooter = data;
                
            }

            lastFireTime = Time.time;
        }
    }
}
