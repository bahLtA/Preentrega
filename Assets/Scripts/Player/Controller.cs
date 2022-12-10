using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    float origSpeed;
    public float speed;
    

    private Vector3 playerInputs;
    private Vector3 moveTo;

    //camara
    public Camera cam;
    private Vector3 forwardCam,rightCam;
    public Transform _cam;

    public CharacterController player;
    float gravity = -9.8f;

    void Start()
    {
        player = GetComponent<CharacterController>();
        origSpeed = speed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 movement = Vector3.zero;
        float movementSpeed = 0;
        if (hor != 0 || ver != 0)
        {
            Vector3 forward = _cam.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = _cam.right;
            right.y = 0;
            right.Normalize();

            Vector3 direction = forward * ver + right * hor;
            movementSpeed = Mathf.Clamp01(direction.magnitude);
            direction.Normalize();

            Run();
            movement = direction * speed * movementSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
        movement.y += gravity * Time.deltaTime;

        moveTo = playerInputs.x * rightCam + playerInputs.z * forwardCam;
        player.Move(movement);
        
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
}
