using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakMonster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

 void OnCollisionEnter2D(Collision2D target)
    {    
        if(target.gameObject.GetComponent<gameOver>() != null)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

    }
}
