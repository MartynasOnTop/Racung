using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour
{
    Veichle veichle;

    private void Start()
    {
        veichle = GetComponent<Veichle>();
    }

    private void Update()
    {
        veichle.Steer(Mathf.PerlinNoise1D(Time.time) * 2 - 1);
        veichle.Accelerate();
    }
}
