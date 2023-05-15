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
        //print("hi");
    }
    
   /*  public void UpdateBlueBoid () 
     {
        base.UpdateBoid();
     }*/


}

