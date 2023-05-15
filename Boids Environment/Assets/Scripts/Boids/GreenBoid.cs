using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoid : Boid {

    //GreenSettings settings;
    public LayerMask ObstacleMask;

    void Awake () {
        material = transform.GetComponentInChildren<MeshRenderer> ().material;
        cachedTransform = transform;
    }

    public void Initialize ()//BoidSettings settings, Transform target) 
    {
        base.Initialize(target);
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("BBoid"));
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("RBoid"));
        this.settings.hunger *= 1; //green boids have normal hunger bars
    }
    
     public void UpdateRedBoid () 
     {
        base.UpdateBoid();
     }


}

