using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
  //when hit player ends the game
    void OnCollisionEnter2D(Collision2D target)
    {    
        //check if collided with player
        if(target.gameObject.name.Equals("boat"))
        {
            //ends game in scoreTracker
            GameObject.Find("Score").GetComponent<scoreTracker>().endGame();          
        }
    }
}
