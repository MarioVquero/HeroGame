using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{

    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public float JumpHeight = 2f;
    [SerializeField] public float gravity = -9.5f;
    [SerializeField] public float roationSpeed = 4f;

    [SerializeField] public Transform cameraTransform;
    // [SerializeField]
    public InputActionReference movementControl;

    private CharacterController characterController;
    private Vector3 moveInput;
    private Vector3 velocity;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        characterController.Move(move * playerSpeed * Time.deltaTime);
        // movement = movementControl.action.ReadValue<Vector2>();

        // if (movement != Vector2.zero)
        // {
        //     float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        //     Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
        //     transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * roationSpeed);
        // }

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        Debug.Log(moveInput);

        movement = context.ReadValue<Vector2>();
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * roationSpeed);
        }

        
    }

    // for flight idea
    // turn off gravity and increase speed by X amount
    // 
    


}
