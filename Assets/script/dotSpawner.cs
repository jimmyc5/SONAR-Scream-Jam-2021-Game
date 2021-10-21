using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotSpawner : MonoBehaviour
{
    //audioclips
    public AudioClip ping1;
    public AudioClip ping2;
    public AudioClip ping3;
    
    //audioplayer
     AudioSource audioSource;
 //how long blip is displayed after being sonared
    public float displayTime = 1.0f;

    //to detect collsions
    public Rigidbody2D rb;

    //true if detected
    public bool detected = false;

    //where blip is spawned
    Transform spawnPoint;

    //gameobject to spawn when detected (what color blip to spawn)
    public GameObject gb;


    void Start()
    {
     //removed so that object would appear when inside visable circle 
     //0f sets opacity to 0 when sprite is first drawn  to be sure invisable
     //  gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.0f);
        audioSource = gameObject.GetComponent<AudioSource>();
      spawnPoint = gameObject.GetComponent<Transform>();    
    }

    void Update()
    {
       
    }

    //when hit by sonar beam draws image of self where it was scanned
    void OnTriggerEnter2D(Collider2D target)
    {    
        //check if collided with sonar line
        if(target.name.Equals("radar"))
        {
            //choose random clip to play
            int clip = Random.Range(1, 3);

            if(clip == 1)
                audioSource.PlayOneShot(ping1, 40);
            if(clip == 2)
                audioSource.PlayOneShot(ping2, 40);
            if(clip == 3)
                audioSource.PlayOneShot(ping3, 40);

            //if spawn the blip in place
            GameObject newObject = Instantiate(gb, spawnPoint.position, spawnPoint.rotation) as GameObject;
            newObject.GetComponent<blip>().displayTime = displayTime;
            
        }
    }
}
