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

<<<<<<< HEAD
        engineSound.pitch = pitchCurve.Evaluate(speedRatio);

        var localVelocity = transform.InverseTransformVector(rb.velocity);

        rb.velocity += -transform.right * localVelocity.x * sideDrag * Time.deltaTime;
        
        if (!isAccelerating)
        {
            rb.velocity += -transform.forward * localVelocity.z * frontDrag * Time.deltaTime;
        }

        if (Mathf.Abs(localVelocity.normalized.x) > 0.5f)
        {
            driftParticles.SetActive(true);
        }
        else
        {
            driftParticles.SetActive(false);
        }

        isAccelerating = false;
=======
        engineSound.pitch = speedRatio * 2;
>>>>>>> parent of 27ba725 (better movement)
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
