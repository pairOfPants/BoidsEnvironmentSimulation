using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoid : Boid {

    //BoidSettings settings;
    public LayerMask ObstacleMask;

    void Awake () {
        material = transform.GetComponentInChildren<MeshRenderer> ().material;
        cachedTransform = transform;
    }

    public void Initialize() //(BlueSettings settings, Transform target) {
    {
        base.Initialize(cachedTransform);
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("GBoid"));
        this.settings.obstacleMask |= (1 << LayerMask.NameToLayer("RBoid"));
        this.settings.hunger *= 4; //blue boids have large hunger bars
    }
    
   /* public void UpdateBlueBoid () 
     {
        base.UpdateBoid();
     }*/


}

