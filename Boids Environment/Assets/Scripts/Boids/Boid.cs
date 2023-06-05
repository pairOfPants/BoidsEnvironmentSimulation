using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public BoidSettings settings;

    [HideInInspector]
    public Vector3 position;
    [HideInInspector]
    public Vector3 forward;
    [HideInInspector]
    public Vector3 velocity;

    [HideInInspector]
    public Vector3 acceleration;
    [HideInInspector]
    public Vector3 avgFlockHeading;
    [HideInInspector]
    public Vector3 avgAvoidanceHeading;
    [HideInInspector]
    public Vector3 centreOfFlockmates;
    [HideInInspector]
    public int numPerceivedFlockmates;
    [HideInInspector]

    public float hunger;
    private float hungerWeight;

    public Material material;
    public Transform cachedTransform;
    public Transform target;

    void Awake () 
    {
        material = transform.GetComponentInChildren<MeshRenderer> ().material;
        cachedTransform = transform;
    }

    public virtual void Initialize ( Transform target) 
    {
        this.target = target;
      //BoidSettings settings,  this.settings = settings;

        position = cachedTransform.position;
        forward = cachedTransform.forward;

        float startSpeed = (settings.minSpeed + settings.maxSpeed) / 2;
        velocity = transform.forward * startSpeed;

        System.Random random = new System.Random();
        hunger = settings.hunger + Random.Range(-10, 35);
    }

    public void SetColour (Color col)
    {
        if (material != null) {
            material.color = col;
        }
    }

    public Color GetColor()
    {
        return this.material.color;
    }

     public void UpdateBoid ()
    {
        Vector3 acceleration = Vector3.zero;

        if (target != null) 
        {
            Vector3 offsetToTarget = (target.position - position);
            acceleration = SteerTowards (offsetToTarget) * settings.targetWeight;
        }

        if (numPerceivedFlockmates != 0) 
        {
            centreOfFlockmates /= numPerceivedFlockmates;

            Vector3 offsetToFlockmatesCentre = (centreOfFlockmates - position);

            var alignmentForce = SteerTowards (avgFlockHeading) * settings.alignWeight;
            var cohesionForce = SteerTowards (offsetToFlockmatesCentre) * settings.cohesionWeight;
            var seperationForce = SteerTowards (avgAvoidanceHeading) * settings.seperateWeight;

            acceleration += alignmentForce;
            acceleration += cohesionForce;
            acceleration += seperationForce;
            for(int i = 0; i < numPerceivedFlockmates; i++) 
            { 
                if(target != null)
                {
                  /*  Boid tempTarget = new Boid();
                    tempTarget.cachedTransform = target;
                   */
                        acceleration += seperationForce * 3;
                }
            }
        }

        hungerWeight = HowHungry();

        if(IsHeadingForPrey())
        {
            Vector3 eatDirection = PreyRays();
            Vector3 eatForce = SteerTowards(eatDirection) * hungerWeight;
            acceleration += eatForce;
        }
        else if (IsHeadingForCollision()) 
        {
            Vector3 collisionAvoidDir = ObstacleRays ();
            Vector3 collisionAvoidForce = SteerTowards(collisionAvoidDir) * settings.avoidCollisionWeight;
            acceleration += collisionAvoidForce;
        }

        //hungerWeight = HowHungry();
        //acceleration += SteerTowards(PreyRays()) * hungerWeight;

        velocity += acceleration * Time.deltaTime;
        float speed = velocity.magnitude;
        Vector3 dir = velocity / speed;
        speed = Mathf.Clamp (speed, settings.minSpeed, settings.maxSpeed);
        velocity = dir * speed;

        cachedTransform.position += velocity * Time.deltaTime;
        cachedTransform.forward = dir;
        position = cachedTransform.position;
        forward = dir;


        if (hunger > 0)
        {
            hunger -= .3f;
        }
        else
        {
            gameObject.SetActive(false);
            Object.DestroyImmediate(gameObject);
            Object.DestroyImmediate(this);
        }


    }

    bool IsHeadingForCollision () 
    {
        RaycastHit hit;
        return Physics.SphereCast(position, settings.boundsRadius, forward, out hit, settings.collisionAvoidDst, settings.obstacleMask);
    }

    bool IsHeadingForPrey()
    {
        RaycastHit hit;
        return Physics.SphereCast(position, settings.boundsRadius, forward, out hit, settings.perceptionRadius, settings.preyMask);
    }

     Vector3 ObstacleRays () 
     {
        Vector3[] rayDirections = BoidHelper.directions;
        //RaycastHit hit;

        for (int i = 0; i < rayDirections.Length; i++)
        {
            Vector3 dir = cachedTransform.TransformDirection (rayDirections[i]);
            Ray ray = new Ray (position, dir);
            if (!Physics.SphereCast (ray, settings.boundsRadius, settings.collisionAvoidDst, settings.obstacleMask)) {
                return dir;
            }
        }

        return forward;
    }

    Vector3 PreyRays()
    {
        Vector3[] rayDirections = BoidHelper.directions;
        RaycastHit hit;

        for (int i = 0; i < rayDirections.Length; i++)
        {
            Vector3 dir = cachedTransform.TransformDirection(rayDirections[i]);
            Ray ray = new Ray(position, dir);
            if (!Physics.SphereCast(ray, settings.boundsRadius, settings.perceptionRadius, settings.preyMask))
            {
                return dir;
            }
        }
        return forward;
    }
 
    Vector3 SteerTowards (Vector3 vector) 
    {
        Vector3 v = vector.normalized * settings.maxSpeed - velocity;
        return Vector3.ClampMagnitude (v, settings.maxSteerForce);
    }

    float HowHungry()
    {
        if (hunger < settings.hunger / 2)
            return 4;
        else if (hunger < settings.hunger * 0.75)
            return 1;
        else return 0.5f;
    }

   public void updateHunger(int food)
    {
        hunger += food;
    }

}
