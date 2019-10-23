using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathmanager : MonoBehaviour
{
    public static Pathmanager Instance; 
    public int PathCounter;
    public int PathCounterMax;
    
    void Awake()
    {
        Instance = this;    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
