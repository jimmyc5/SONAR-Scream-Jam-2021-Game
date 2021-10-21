using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip monster;

    float lastSound = 0; //the actual timer maybe I should use different names lol
 

    Rigidbody2D rb;
    //boats rigidbody
    Rigidbody2D bb;

    // Start is called before the first frame update
    void Start()
    {
        //get componets from objects
        bb = GameObject.Find("boat").GetComponent<Rigidbody2D>();    
        rb = GetComponent<Rigidbody2D>();
         audioSource = gameObject.GetComponent<AudioSource>();
         lastSound = 5.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //3.0f is distance from boat to edge of sight
         if (3.0f >= Vector2.Distance(rb.position, bb.position) & lastSound > 4.0f)
        {
            audioSource.PlayOneShot(monster, 50); 
            lastSound=0;
        }
        else
        {
               lastSound += Time.deltaTime;
        }
    }
}
