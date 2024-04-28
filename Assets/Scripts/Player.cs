using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Veichle veichle;

    private void Start()
    {
        veichle = GetComponent<Veichle>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            veichle.Accelerate();
        }

        if (Input.GetKey(KeyCode.S))
        {
            veichle.Brake();
        }

        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0) veichle.Steer(horizontal);
    }
}
