using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;

    public float jumpForce = 2.0f;

    CharacterController theCharController;

    private Vector3 moveDirection;
    public float gravityScale;

    public float currentYValue;
    public float lastYValue;

    // Start is called before the first frame update
    void Start()
    {
        theCharController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, moveDirection.y, Input.GetAxis("Vertical"));

        if (theCharController.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
                
            }
        }

        //lastYValue = transform.position.y;

        if (theCharController.isGrounded == false)
        {
            currentYValue = transform.position.y;
            if (currentYValue == lastYValue)
            {
                moveDirection.y = 0;
            }
        }
       
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        theCharController.Move(moveDirection * Time.deltaTime);

        lastYValue = currentYValue;

    }

    public void AddJumpModifier(int modifierToAdd)
    {
        jumpForce += modifierToAdd;
    }



}
