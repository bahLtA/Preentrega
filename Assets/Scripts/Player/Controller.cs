using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    float origSpeed;
    public float speed,jumpForce;

    private Vector3 playerInputs;
    private Vector3 moveTo;

    //camara
    public Camera cam;
    private Vector3 forwardCam,rightCam;

    public CharacterController player;

    void Start()
    {
        player = GetComponent<CharacterController>();
        origSpeed = speed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        Jump();
        CameraDirection();
    }

    void PlayerMovement()
    {
        playerInputs = new Vector3(Input.GetAxis("Horizontal")*Time.fixedDeltaTime,0, Input.GetAxis("Vertical")*Time.fixedDeltaTime);
        Run();
        moveTo = playerInputs.x * rightCam + playerInputs.z * forwardCam;
        player.Move(moveTo * speed * Time.fixedDeltaTime);
        
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = origSpeed*2.5f;
        }
        else
        {
            speed = origSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    void CameraDirection()
    {
        forwardCam = cam.transform.forward;
        rightCam = cam.transform.right;
        
        forwardCam.y = 0;
        rightCam.y = 0;

        forwardCam = forwardCam.normalized;
        rightCam = rightCam.normalized;
    }
}
