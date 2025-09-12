using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;

    [SerializeField] private float maxFlightHeight;
    [SerializeField] private float minFlightHeight;

    public Camera freeLookCam;
    private float currHeight;




    // [SerializeField] private float rotationSpeed = 4f;

    // private CharacterController controller;
    // private Vector3 playerVelocity;
    // private bool groundedPlayer;

    // private Transform cameraMainTransform;

    // [Header("Input Actions")]
    // public InputActionReference moveActionController; // expects Vector2
    // public InputActionReference flyingController; // expects Button

    private void Awake()
    {
        // controller = gameObject.GetComponent<CharacterController>();
        // cameraMainTransform = Camera.main.transform;
    }

    void Start()
    {
        currHeight = transform.position.y;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // private void OnEnable()
    // {
    //     moveActionController.action.Enable();
    //     flyingController.action.Enable();
    // }

    // private void OnDisable()
    // {
    //     moveActionController.action.Disable();
    //     flyingController.action.Disable();
    // }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            MoveChar();
        }
        else
        {
            DisableChar();
        }

        currHeight = Mathf.Clamp(transform.position.y, currHeight, maxFlightHeight);
        transform.position = new Vector3(transform.position.x, currHeight, transform.position.z);


    }

    private void MoveChar()
    {
        Vector3 cameraForward = new Vector3(freeLookCam.transform.forward.x, 0, freeLookCam.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(0, 0, 0), Space.Self);

        Vector3 forward = freeLookCam.transform.forward;
        Vector3 flyDirection = forward.normalized;


        currHeight += flyDirection.y * playerSpeed * Time.deltaTime;
        currHeight = Mathf.Clamp(currHeight, minFlightHeight, maxFlightHeight);

        transform.position += flyDirection * playerSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, currHeight, transform.position.z);

    }

    private void DisableChar()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

}
