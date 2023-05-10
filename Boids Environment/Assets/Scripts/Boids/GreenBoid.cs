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
       // base.settings.setObstacleMask(ObstacleMask);
    }
    
     public void UpdateRedBoid () 
     {
        base.UpdateBoid();
     }


}

