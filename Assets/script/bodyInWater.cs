using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyInWater : MonoBehaviour
{
    //distance till start moving to boat
    public float distance = 3.0f;

    //speed at which body moves towards boat
    public float swimSpeed = 1.0f;

    //circle rigidbody
    Rigidbody2D rb;
    //boats rigidbody
    Rigidbody2D bb;

  void Start()
    {
        //get components from objects
        bb = GameObject.Find("boat").GetComponent<Rigidbody2D>();    
        rb = GetComponent<Rigidbody2D>();
    }


        //if close to boat person will begin swiming toward it
    private void FixedUpdate()
    {
        if (distance >= Vector2.Distance(rb.position, bb.position))
        {
            //adapated from dashball/ballscript.cs
            Vector2 dir = (rb.transform.position - bb.transform.position).normalized;
            rb.AddForce(-dir*swimSpeed);
        }
    }

    //if contact boat remove and add to score
     void OnTriggerEnter2D(Collider2D target)
    {    
        //check if collided with player
        if(target.name.Equals("boat"))
        { 
            GameObject.Find("Score").GetComponent<scoreTracker>().score+=1;
            Destroy(gameObject);
        }
    }

}
