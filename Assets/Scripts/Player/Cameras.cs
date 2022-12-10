using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    public GameObject cam1, cam2;
    public Image img;
    public Transform cam;
    float range = 100f;
    public LayerMask ignore;

    void Update()
    {
        ChangeCamera();
        DetectEnemy();
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
    void DetectEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range,~ignore))
        {
            img.color = Color.white;
            if (hit.transform.CompareTag("Enemy"))
            {
                img.color = Color.red;
            }
        }
        Debug.Log(hit.transform.name);
    }
}
