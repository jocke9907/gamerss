using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] int jumpForce;
    public KeyCode jumpButton;
    public bool isGrounded;

    [SerializeField] GameObject groundCheck;
    [SerializeField] LayerMask groundMask;


    float horizontalInput;
    float verticalInput;
    Vector3 movementDirection;

    int speed = 5;
    float rotationSpeed = 720;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        isGrounded = Physics.CheckBox(
           groundCheck.transform.position,
           groundCheck.GetComponent<Collider>().bounds.size, Quaternion.identity,
           groundMask
           );

        //if (Input.GetKeyDown(jumpButton) && isGrounded)
        //{
        //    GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        //}
    }
}
