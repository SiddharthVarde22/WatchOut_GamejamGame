using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    Camera camera1;
    [SerializeField]
    Camera camera2;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if (camera2.depth == 1)
            {
                camera1.depth = 1;
                camera2.depth = 0;
            }
            else
            {
                camera1.depth = 0;
                camera2.depth = 1;
            }
        }
    }
}
