using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public enum GizmoType { Never, SelectedOnly, Always }

    public GameObject prefab;
    public float spawnRadius = 10;
    public int spawnCount = 10;
    public Color colour;
    public GizmoType showSpawnRegion;
    public bool hasReproduced = false;
    public int health;
    public int reproNum; //# of new plants
    public int reproRad; //how close new plants spawn

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = transform.position + new Vector3 (Random.Range(0f, spawnRadius), 0, Random.Range(0f, spawnRadius));
            GameObject plant = Instantiate(prefab);
            plant.transform.position = pos;
           // plant.transform.forward = Random.insideUnitSphere;
            //plant falls to ground (or more accurately spawns on ground)
            //plant is rotated to direction of Normal line (perpindicular to the angle of the surface)
        }
    }
    private void OnDrawGizmos()
    {
        if (showSpawnRegion == GizmoType.Always)
        {
            DrawGizmos();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (showSpawnRegion == GizmoType.SelectedOnly)
        {
            DrawGizmos();
        }
    }

    void DrawGizmos()
    {

        Gizmos.color = new Color(colour.r, colour.g, colour.b, 0.3f);
        Gizmos.DrawSphere(transform.position, spawnRadius);
    }
    void Update()
    {
        //If an object collides with it
        //health subract some value
        //object's hunger fills some value (could be different by color)
        //if health == 0 then die
        //if survives for some time reproduce x amount of new plants in radius r (x can be a genetic trait bc we still have to implement those)
    }
}


