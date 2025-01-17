﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it will move around, and drop a path of floor tiles behind it

public class Pathmaker : MonoBehaviour {

    // STEP 2: ============================================================================================
    // translate the pseudocode below

    //	DECLARE CLASS MEMBER VARIABLES:
    //	Declare a private integer called counter that starts at 0; 		// counter var will track how many floor tiles I've instantiated
    //	Declare a public Transform called floorPrefab, assign the prefab in inspector;
    //	Declare a public Transform called pathmakerSpherePrefab, assign the prefab in inspector; 		// you'll have to make a "pathmakerSphere" prefab later

    private int counter = 0;
    public Transform FloorPrefab;
    public Transform PathmakerSpherePrefab;

    bool isGrounded = false;

    public Transform Paths;

    public void Start()
    {
        if (PathmakerManager.instance.MyCurrentSphere == null)
        {
            //Debug.Log("No Ball!");
            PathmakerManager.instance.MyCurrentSphere = this.gameObject; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate () {
        if (counter < 50)
        {
            float RandomNum;
            RandomNum = Random.Range(0f, 1f);
            if (RandomNum < 0.15f)
            {
                PathmakerSpherePrefab.eulerAngles += PathmakerSpherePrefab.up * 90;
            }
            else if (RandomNum >= 0.15f && RandomNum <= 0.3f)
            {
                PathmakerSpherePrefab.eulerAngles -= PathmakerSpherePrefab.up * 90;
            }
            else if (RandomNum >= 0.98f && RandomNum <= 1f)
            {
                Instantiate(PathmakerSpherePrefab);
            }

            if (Pathmanager.Instance.PathCounter < Pathmanager.Instance.PathCounterMax)
            {
                if (isGrounded == false)
                {
                    Instantiate(FloorPrefab, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation, Paths);
                    Pathmanager.Instance.PathCounter++;
                }
            }
            else
            {
                Destroy(this.gameObject);
            }

            transform.position += transform.forward * 5;

            counter++;

            Ray myRay = new Ray(transform.position, Vector3.down);
            float myRayDist = 5f;
            if (Physics.Raycast(myRay, myRayDist))
            {
                //Debug.Log("Raycast returns true!");
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}

// MORE STEPS BELOW!!!........



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS, PLEASE, I'M BEGGING YOU
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
//		- MODEL 3 DIFFERENT TILES IN MAYA! DON'T STOP USING MAYA OR YOU'LL FORGET IT ALL
//		- add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]



// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
