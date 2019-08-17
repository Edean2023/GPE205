using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHealth : MonoBehaviour
{
    TankData data;

    public static int healthValue = 5;
    Text tankHealth;

    void Start()
    {
        data = GetComponent<TankData>();
        tankHealth = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tankHealth.text = "Health: " + healthValue;
    }
}

