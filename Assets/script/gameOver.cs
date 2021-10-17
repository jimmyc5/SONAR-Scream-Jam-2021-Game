using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
  //when hit player ends the game
    void OnTriggerEnter2D(Collider2D target)
    {    
        Debug.Log("nuts");
        //check if collided with player
        if(target.name.Equals("boat"))
        {
            //PLACE HOLDER
            //pauses the game indefinitly
            Time.timeScale =0;            
        }
    }
}
