using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoid : Boid {

    BlueSettings settings;
    //public LayerMask ObstacleMask;

    void Awake () {
        material = transform.GetComponentInChildren<MeshRenderer> ().material;
        cachedTransform = transform;
    }

    public void Initialize (BlueSettings settings, Transform target) 
    {
        
        base.Initialize((BoidSettings)settings, target);
       // base.settings.setObstacleMask(ObstacleMask);
    }
    
     public void UpdateRedBoid () 
     {
        base.UpdateBoid();
     }


}

