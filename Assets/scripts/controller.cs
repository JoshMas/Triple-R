using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class controller : MonoBehaviour
{

    public float speed = 10.0f;
    public float gravity = 100.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    Rigidbody rb;

    private Vector3 targetVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //rb.useGravity = false;
    }

    private void Update()
    {
        targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= speed;

        //transform.Translate(targetVelocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.velocity = targetVelocity;

        // Calculate how fast we should be moving
        // Apply a force that attempts to reach our target velocity
        /*
        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // Jump
        if (canJump && Input.GetButton("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, CalculateJumpVerticalSpeed(), rb.velocity.z);
        }
        */

        //// We apply gravity manually for more tuning control
        //rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

        //grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}