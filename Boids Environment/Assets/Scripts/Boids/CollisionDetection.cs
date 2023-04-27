using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       /* if (other.gameObject.tag == "plant")
        {
            print("BOID HIT PLANT ENTER");
        }
        if (other.gameObject.tag == this.gameObject.tag)
        {
            print("BOID ON BOID ENTER");
        }*/
        if (this.gameObject.tag == "plant" && other.gameObject.tag == "floor")
        {
            this.gameObject.transform.rotation = this.gameObject.transform.localRotation;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if (this.gameObject.tag == "plant" && other.gameObject.tag == "mesh")
        {
             Debug.Log("Plants hit MESH");
            this.gameObject.transform.rotation = this.gameObject.transform.localRotation;
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        if(this.gameObject.tag == "Boid" && other.gameObject.tag == "plant")
        {
            //TODO incrememnt boid's hunger when colliding with plant
            // other.gameObject.SetActive(false);
            // Object.DestroyImmediate(other.gameObject);
            // Object.DestroyImmediate(other.gameObject);
        }
        /*
         * if this is a plant and that is a plant
         *      shift the position a little
         */
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Boid" && this.gameObject.tag =="Boid")
        {
           // print("BOID ON BOID STAY");
        }
        if(this.gameObject.tag == "plant" && other.gameObject.tag == "plant")
        {
          //  print("PLANT ON PLANT ACTION ;)");
            other.gameObject.GetComponent<Rigidbody>().position = other.gameObject.GetComponent<Rigidbody>().position + new Vector3(0.02f, 0, 0.02f);
            this.gameObject.GetComponent<Rigidbody>().position = this.gameObject.GetComponent<Rigidbody>().position - new Vector3(0.02f, 0, 0.02f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "plant")
        {
          //  print("EXIT");
        }
        if (other.gameObject.tag == this.gameObject.tag)
        {
           // print("BOID ON BOID COLLISION");
        }
    }
}


