using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    private GameObject cam1;
    private GameObject cam2;

    void Start()
    {
        cam1 = GameObject.FindGameObjectWithTag("MainCamera");
        cam2 = GameObject.Find("cam2");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("V Key"))
        {
            if (cam1.GetComponent<Camera>().enabled)
            {
                cam1.GetComponent<Camera>().enabled = false;
                cam2.GetComponent<Camera>().enabled = true;

            }
            else
            {
                cam1.GetComponent<Camera>().enabled = true;
                cam2.GetComponent<Camera>().enabled = false;
            }

        }
    }
}
