using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMoveScript : MonoBehaviour {
    // Movement
    Vector3 acceleration;
    Vector3 velocity;
    Vector3 desired;
    Vector3 force;

    // public to change in Inspector
    public float maxSpeed = 10.0f;
    public float maxForce = 12.0f;
    public float mass = 2.0f;
    public float radius = 1.0f;

    GameObject target;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        // ------------------------------------------------------------- >> STEERING <<
        // Calculate the necessary steering forces / add them to acceleration
        CalcSteeringForces();

        // For clamping the object down to the ground
        Vector3 down = new Vector3(0f, -1f, 0f);
        down *= maxSpeed;

        // Add accel to vel
        velocity += acceleration * Time.deltaTime;
        velocity.y = 0;

        // Limit vel to max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Move character based on velocity - don't forget to clamp to ground
        velocity.y = 0.0f;
        transform.position += velocity * Time.deltaTime;
        //charController.Move(velocity * Time.deltaTime);
        //charController.Move(down * Time.deltaTime);

        // Reset acceleration to 0
        acceleration = Vector3.zero;

        // Set creature's forward to the velocity now
        transform.forward = velocity.normalized;
    }

    // Calculates all steering forces / adds them together into acceleration
    // Calculates depending on SUBSUMPTION model
    void CalcSteeringForces()
    {
        // Reset forces
        force = Vector3.zero;

        force += Seek(target.transform.position);


        // Clamp the force and apply it
        force = Vector3.ClampMagnitude(force, maxForce);

        ApplyForce(force);
    }

    // Applies force to acceleration, taking mass into account
    void ApplyForce(Vector3 steeringForce)
    {
        acceleration += steeringForce / mass;
    }

    // Returns direction creature must travel to reach target
    Vector3 Seek(Vector3 targetPos)
    {
        desired = targetPos - transform.position;
        desired.y = 0;
        desired = desired.normalized * maxSpeed;
        desired -= velocity;
        return desired;
    }

    Vector3 Arrive(Vector3 targetPos)
    {
        if (Vector3.Distance(transform.position, targetPos) < 2.0f)
        {

        }
        return Vector3.zero;
    }
}
