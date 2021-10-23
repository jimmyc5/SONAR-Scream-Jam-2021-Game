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

    bool isChasing;
    Vector3 startPos;
    Vector3 wanderPos;
    float wanderRange;
    float speed;
    AudioSource audioSource;
    public AudioClip body;

  void Start()
    {
        //get components from objects
        bb = GameObject.Find("boat").GetComponent<Rigidbody2D>();    
        rb = GetComponent<Rigidbody2D>();
        startPos = gameObject.transform.position;
        wanderPos = gameObject.transform.position;
        audioSource = gameObject.GetComponent<AudioSource>();
        isChasing = false;
        wanderRange = 5f;
        speed = 1f;
    }
        //if close to boat person will begin swiming toward it
    void FixedUpdate()
    { 
        //3.0f is distance from boat to edge of sight
        if (3.0f >= Vector2.Distance(rb.position, bb.position) & !isChasing)
        {
            audioSource.PlayOneShot(body, 0.5f); 
            isChasing = true;
        }

        if(isChasing){
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, bb.position, Time.fixedDeltaTime * speed);
        }
        else{
            //generate wanderPos if not too close
            if(Vector3.Distance(gameObject.transform.position, wanderPos) <= .5f){
                do{
                    wanderPos = gameObject.transform.position + (new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f,1f), 0f).normalized) * Random.Range(1f, 5f);
                } while(Vector3.Distance(startPos, wanderPos) > wanderRange);
            }
            //navigate to wanderPos
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, wanderPos, Time.fixedDeltaTime);


        }

    }

    //if contact boat remove and add to score
    private void OnCollisionEnter2D(Collision2D target)
    {    
        //check if collided with player
        if(target.gameObject.name.Equals("boat"))
        { 
            GameObject.Find("Score").GetComponent<scoreTracker>().score+=1;
            Destroy(gameObject);
        }
    }

}
