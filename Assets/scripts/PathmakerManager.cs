using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathmakerManager : MonoBehaviour
{
    //I want to limit and detect the amount of balls on field
    public static PathmakerManager instance;
    public GameObject MySphere;
    public GameObject MyCurrentSphere;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
            Instantiate(MySphere);
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Pathmanager.Instance.PathCounter < Pathmanager.Instance.PathCounterMax &&
                MyCurrentSphere == null)
            {
                Instantiate(MySphere);
            }
        }
    }
}
