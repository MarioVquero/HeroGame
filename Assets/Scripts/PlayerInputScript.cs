using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{

    [Header("Flight Stats")]
    public float playerSpeed = 5.0f;
    [SerializeField] private float maxFlightHeight;
    [SerializeField] private float minFlightHeight;
    [SerializeField] private Vector3 attackOffset;
    public Vector3 attackPosition;
    public float currHeight;
    public bool loseSpeed = false;


    private Vector3 flyDirection;


    [Header(" References")]
    private PlayerAttackScript PAScript;
    public Transform pos;
    public Camera freeLookCam;


    [SerializeField] Transform aimPos;
    [SerializeField] LayerMask aimMask;
    [SerializeField] float aimSmoothSpeed = 20f;

    void Start()
    {
        pos = GetComponent<Transform>();
        PAScript = GetComponent<PlayerAttackScript>();
        currHeight = transform.position.y;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rotateCharacter();

        // currHeight = Mathf.Clamp(transform.position.y, currHeight, maxFlightHeight);
        transform.position = new Vector3(transform.position.x, currHeight, transform.position.z);


        if (Input.GetKey(KeyCode.W) && loseSpeed == false)
        {
            MoveChar();
            PAScript.AttackSquare.SetActive(false);



        }

        if (loseSpeed == true)
        {
            ShowAttack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            loseSpeed = true;

            StartCoroutine(PAScript.Attacking());
            // Debug.Log(pos);
        }

    }

    public void rotateCharacter()
    {

        Vector3 cameraForward = new Vector3(freeLookCam.transform.forward.x, 0, freeLookCam.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(0, 0, 0), Space.Self);

        Vector3 forward = freeLookCam.transform.forward;
        flyDirection = forward.normalized;

    }

    public void MoveChar()
    {

        currHeight += flyDirection.y * playerSpeed * Time.deltaTime;
        currHeight = Mathf.Clamp(currHeight, minFlightHeight, maxFlightHeight);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 50.0f;
        }
        else
        {
            playerSpeed = 20.0f;
        }
        transform.position += flyDirection * playerSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, currHeight, transform.position.z);

    }

    public void DisableChar()
    {

        // Debug.Log(loseSpeed);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }


    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.CompareTag("Building"))
        // {
        //     loseSpeed = true;
        // }
    }

    public void ShowAttack()
    {
        Vector2 screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);


        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {

            Debug.Log("showAttack");

            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }
    }

    // at the end of playerAttackscript.Attacking
    // return a vector 3 aka final hit,
    


}

