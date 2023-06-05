using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBoid : Boid {

    // BoidSettings settings;
    public LayerMask ObstacleMask;

    void Awake () 
    {
        material = transform.GetComponentInChildren<MeshRenderer> ().material;
        cachedTransform = transform;
    }

    public void Initialize (BoidSettings settings, Transform target) 
    {
        base.Initialize(target);
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("BBoid"));
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("GBoid"));
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("Wall"));
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("Obstacle"));
        this.settings.hunger *= 1; //green boids have normal hunger bars
    }
    
     public void UpdateRedBoid () 
     {
        base.UpdateBoid();
     }


}

