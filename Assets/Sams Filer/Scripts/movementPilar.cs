using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class movementPilar : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    Vector3 movementDirection;
    public Collider finishLine;
    public int speed = 5;
    float rotationSpeed = 720;
    int finishedPlayers = 0;

    public float jumpForce = 5f;
    private Rigidbody playerRB;

    public bool isOnGround = true;
    public bool finished = false;

    

    public int totalScore;
    

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
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

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Plattform") || collision.gameObject.CompareTag("Movable object"))
        {
            isOnGround = true;
        }
    }
    
    public void AddScore(int score)
    {
        totalScore = totalScore + score;
    }


}
