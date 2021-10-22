using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip monster;

    bool isChasing;
    Vector3 startPos;
    Vector3 wanderPos;
    float wanderRange;
    float speed;
    scoreTracker score;

    Rigidbody2D rb;
    //boats rigidbody
    Rigidbody2D bb;

    // Start is called before the first frame update
    void Start()
    {
        //get componets from objects
        bb = GameObject.Find("boat").GetComponent<Rigidbody2D>();    
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.Find("Score").GetComponent<scoreTracker>();
        audioSource = gameObject.GetComponent<AudioSource>();
        startPos = gameObject.transform.position;
        wanderPos = gameObject.transform.position;
        isChasing = false;
        wanderRange = 5f;
        speed = 1.5f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = 1f + (score.score * 0.1f); 
        //3.0f is distance from boat to edge of sight
        if (3.0f >= Vector2.Distance(rb.position, bb.position) & !isChasing)
        {
            audioSource.PlayOneShot(monster, 50); 
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
}
