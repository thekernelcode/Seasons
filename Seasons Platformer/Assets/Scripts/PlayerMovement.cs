using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    bool onGround = true;

    public float landedCounterLength = 0.5f;
    public float landedCounter;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        float landedCounter = landedCounterLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround == true)
        {
            this.transform.Translate(Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true && landedCounter <= 0)
        {
            onGround = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumped");
            landedCounter = landedCounterLength;
        }

        if (landedCounter > 0)
        {
            landedCounter -= Time.deltaTime;
        }

    }

    void OnCollisionStay()
    {
        if (landedCounter <= 0f)
        {
            onGround = true;
            Debug.Log("Landed");
            landedCounter = landedCounterLength;
        }
    }



}
