using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veichle : MonoBehaviour
{
    public float speed = 1.0f;
    public float rotateSpeed = 1.0f;
    AudioSource engineSound;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        print((int)rb.velocity.magnitude * 3.6f + "km/h");
        var speedRatio = rb.velocity.magnitude / speed;

        engineSound.pitch = speedRatio * 2;
    }

    public void Steer(float value)
    {
        transform.Rotate(0, value * rotateSpeed * Time.deltaTime, 0);
    }

    public void Accelerate()
    {
       rb.velocity += transform.forward * speed * Time.deltaTime;
    }

    public void Brake()
    {

    }
}
