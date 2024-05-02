using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veichle : MonoBehaviour
{
    public float maxSpeed = 10;
    public float acceleration = 1.0f;
    public float decceleration = 1.5f;
    public float rotateSpeed = 1.0f;
    public float reverseAcceleration = 1f;
    public AnimationCurve pitchCurve;
    public AnimationCurve rotateSpeedCurve;
    float speedRatio;
    public float sideDrag = 1f;
    public float frontDrag = 0.1f;
    public bool isAccelerating;
    AudioSource engineSound;
    public GameObject driftParticles;


    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
        rb.maxLinearVelocity = maxSpeed;
    }

    private void Update()
    {
        //print((int)rb.velocity.magnitude + "m/s");
        speedRatio = rb.velocity.magnitude / maxSpeed;

        engineSound.pitch = pitchCurve.Evaluate(speedRatio);

        var localVelocity = transform.InverseTransformVector(rb.velocity);

        rb.velocity += -transform.right * localVelocity.x * sideDrag * Time.deltaTime;
        
        if (!isAccelerating)
        {
            rb.velocity += -transform.forward * localVelocity.z * frontDrag * Time.deltaTime;
        }

        if (Mathf.Abs(localVelocity.normalized.x) > 0.5f)
        {
            driftParticles.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            driftParticles.GetComponent<ParticleSystem>().Pause();
        }

        isAccelerating = false;
    }

    public void Steer(float value)
    {
        transform.Rotate(0, value * rotateSpeed * Time.deltaTime * rotateSpeedCurve.Evaluate(speedRatio), 0);
    }

    public void Accelerate()
    {
        rb.velocity += transform.forward * acceleration * Time.deltaTime;
        isAccelerating = true;
    }

    public void Brake()
    {
        var acc = speedRatio > 0 ? decceleration : reverseAcceleration;
        rb.velocity += -transform.forward * acc * Time.deltaTime;
    }
}
