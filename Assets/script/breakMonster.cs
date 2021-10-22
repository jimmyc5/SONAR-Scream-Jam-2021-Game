using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakMonster : MonoBehaviour
{
    public GameObject gb;
    // Start is called before the first frame update
    void Start()
    {
           
    }

 void OnCollisionEnter2D(Collision2D target)
    {    
        if(target.gameObject.GetComponent<gameOver>() != null)
        {
            Vector3 myVector = new Vector3(0.0f, 1.0f, 0.0f);
            GameObject newObject = Instantiate(gb, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation) as GameObject;
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

    }
}
