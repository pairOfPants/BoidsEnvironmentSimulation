using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlueSettings : ScriptableObject {
    // Settings
    public float minSpeed = 1;
    public float maxSpeed = 2.5f;
    public float perceptionRadius = 2.5f;
    public float avoidanceRadius = 1;
    public float maxSteerForce = 3;

    public float alignWeight = 1;
    public float cohesionWeight = 1;
    public float seperateWeight = 1;

    public float targetWeight = 1;

    static System.Random random = new System.Random();
    public float hunger = 400 + random.Next(0, 15);

    // public float scale = BlueBoid.transform.localScale(3, 3, 3);

    [Header ("Collisions")]
    public LayerMask obstacleMask;
    public LayerMask thisBoid;
    public LayerMask preyMask;
    public float boundsRadius = .27f;
    public float avoidCollisionWeight = 10;
    public float collisionAvoidDst = 5;

}


