using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blip : MonoBehaviour
{
    //how long blip is displayed after being sonared
    public float displayTime = 1.0f;
    
    //the opacancy the object is drawn with
    public float opac = 1.0f;

    //holds orginal displayTime so blips can disappear smoothly
    float hold;
    void Start()
    {
      hold = displayTime;  
    }


    
    void OnTriggerEnter2D(Collider2D target)
    {    
        if(target.gameObject.name.Equals("aroundBoat"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //gradually disappear based on time passed
        displayTime -= Time.deltaTime; 
        opac -= Time.deltaTime/hold;

        //when timer = 0 get rid of itself
        if (displayTime <=0)
        Destroy(gameObject); 

        //update sprite
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,opac); 
    }
}
