using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    public GameObject cam1, cam2,cam3;
    public Image img;
    public Transform cam;
    public int camActive;
    float range = 100f;
    public LayerMask ignore;


    private void Start()
    {
        camActive = 1;
    }
    void Update()
    {
        ChangeCamera();
        DetectEnemy();
    }

    void ChangeCamera()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            switch (camActive)
            {
                case 1:
                    cam1.SetActive(false);
                    cam2.SetActive(true);
                    cam3.SetActive(false);
                    camActive++;
                    break;
                case 2:
                    cam1.SetActive(false);
                    cam2.SetActive(false);
                    cam3.SetActive(true);
                    camActive++;
                    break;
                case 3:
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                    cam3.SetActive(false);
                    camActive = 1;
                    break;
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
    }
}
