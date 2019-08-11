using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TankData data;
    public Transform tf;
    public TankData shooter;
    public float speed = 10.0f;
    public float damageDone = 1.0f;

    void Awake()
    {
        tf = GetComponent<Transform>();
    }

    void Start()
    {
        data = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        TankData otherData = other.GetComponent<TankData>();

        otherData.health--;
    }
}