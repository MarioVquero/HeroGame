using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{

    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public float JumpHeight = 2f;
    [SerializeField] public float gravity = -9.5f;

    private CharacterController characterController;
    private Vector3 moveInput;
    private Vector3 velocity;


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

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }

    // for flight idea
    // turn off gravity and increase speed by X amount
    // 
}
