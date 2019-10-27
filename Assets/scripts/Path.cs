using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public bool[] HasNeighbor = new bool[4];
    public Ray[] NeighborDetect = new Ray[4];
    public Transform[] WallSpawner = new Transform[4];
    public GameObject Wall;

    public GameObject[] Brick = new GameObject[3];

    bool Notspawned = true;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        NeighborDetect[0] = new Ray(transform.position, Vector3.forward);
        NeighborDetect[1] = new Ray(transform.position, Vector3.right);
        NeighborDetect[2] = new Ray(transform.position, -Vector3.forward);
        NeighborDetect[3] = new Ray(transform.position, -Vector3.right);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (Pathmanager.Instance.PathCounter >= Pathmanager.Instance.PathCounterMax && Notspawned)
        {
            float myRayDist = 4f;

            for (int i = 0; i < HasNeighbor.Length; i++)
            {
                //Debug.DrawRay(NeighborDetect[i].origin, NeighborDetect[i].direction * myRayDist, Color.yellow);
                if (Physics.Raycast(NeighborDetect[i], myRayDist))
                {
                    //Debug.Log("Raycast returns true!");
                }
                else
                {
                        Instantiate(Wall, WallSpawner[i], false);
                }
            }

            float BrickPicker = 0;
            BrickPicker = Random.Range(0f, 10f);

            if (BrickPicker < 8f)
            {
                Instantiate(Brick[0],transform,false);
            }
            else if (BrickPicker >= 8f && BrickPicker <= 9f)
            {
                Instantiate(Brick[1], transform, false);
            }
            else if (BrickPicker > 9f && BrickPicker <= 10f)
            {
                Instantiate(Brick[2], transform, false);
            }

            Notspawned = false;
        }
    }
}
