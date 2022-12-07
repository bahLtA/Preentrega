using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject cam1, cam2;

    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
    }

    void ChangeCamera()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(cam1.activeInHierarchy)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
        }
    }
}
