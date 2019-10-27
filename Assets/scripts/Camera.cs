using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform TallCam;
    public Transform FlatCam;
    public bool tall = false;
    // Start is called before the first frame update

    void Start()
    {
        transform.position = FlatCam.position;
        transform.rotation = FlatCam.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tall)
            {
                transform.position = FlatCam.position;
                transform.rotation = FlatCam.rotation;
                tall = false;
            }
            else
            {
                transform.position = TallCam.position;
                transform.rotation = TallCam.rotation;
                tall = true;
            }
        }
    }
}
