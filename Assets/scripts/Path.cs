using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public bool[] HasNeighbor = new bool[4];
    public Ray[] NeighborDetect = new Ray[4];
    public Transform[] WallSpawner = new Transform[4];
    public GameObject Wall;

    bool spawned = true;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        NeighborDetect[0] = new Ray(transform.position, Vector3.forward);
        NeighborDetect[1] = new Ray(transform.position, Vector3.right);
        NeighborDetect[2] = new Ray(transform.position, -Vector3.forward);
        NeighborDetect[3] = new Ray(transform.position, -Vector3.right);
    }

    void FixedUpdate()
    {
        if (Pathmanager.Instance.PathCounter >= Pathmanager.Instance.PathCounterMax)
        {
            float myRayDist = 4f;

            for (int i = 0; i < HasNeighbor.Length; i++)
            {
                Debug.DrawRay(NeighborDetect[i].origin, NeighborDetect[i].direction * myRayDist, Color.yellow);
                if (Physics.Raycast(NeighborDetect[i], myRayDist))
                {
                    //Debug.Log("Raycast returns true!");
                }
                else
                {
                    if (spawned)
                    {
                        Instantiate(Wall, WallSpawner[i], false);
                    }
                }
            }
            spawned = false;
        }
    }
}
