using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject WallPrefab;
    public Ray NeighborDetect;

    void Start()
    {
        NeighborDetect = new Ray(transform.position, Vector3.forward);
    }

    void FixedUpdate()
    {
        NeighborDetect = new Ray(transform.position, Vector3.forward);

        if (Pathmanager.Instance.PathCounter >= Pathmanager.Instance.PathCounterMax)
        {
            //Debug.DrawRay(NeighborDetect.origin, NeighborDetect.direction * 10, Color.yellow);
            //Instantiate(WallPrefab);

            //Physics.Raycast(NeighborDetect, 2) && 
        }
    }
    
}
