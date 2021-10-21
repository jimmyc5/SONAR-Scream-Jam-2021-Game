using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movementVector;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        if (movementVector.y > 0)
        {
            rb.AddForce(transform.up * moveSpeed * movementVector.y);
        }else if(movementVector.y < 0)
        {
            rb.AddForce(transform.up * 0.5f * moveSpeed * movementVector.y);
        }

        if(movementVector.x != 0)
        {
            rb.rotation -= movementVector.x*turnSpeed;
        }

       // rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);
    }
}
