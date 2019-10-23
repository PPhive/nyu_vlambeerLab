using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathmakerManager : MonoBehaviour
{
    //I want to limit and detect the amount of balls on field
    public static PathmakerManager instance;
    public int[] SphereCounter; 

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (Pathmanager.Instance.PathCounter < Pathmanager.Instance.PathCounterMax)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
