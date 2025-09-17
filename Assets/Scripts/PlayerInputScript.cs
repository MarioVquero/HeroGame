using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    

    [SerializeField] private float maxFlightHeight;
    [SerializeField] private float minFlightHeight;
    [SerializeField] private Vector3 attackOffset;
    [SerializeField] public PlayerAttackScript PAScript;

    public Camera freeLookCam;
    private float currHeight;

    private void Awake()
    {

    }

    void Start()
    {
        currHeight = transform.position.y;
    }

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

        if (Input.GetKey(KeyCode.F))
        {
            SlowTime();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(PAScript.Attack());
            Debug.Log(transform.position);
            transform.position = (PAScript.Attack() + attackOffset);
            Debug.Log(PAScript.Attack());
            Debug.Log(transform.position);
        }

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

    private void SlowTime()
    {
        Time.timeScale = 0.2f;
    }
}
