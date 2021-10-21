using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("boat").GetComponent<Transform>();
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            transform.position = target.position + offset;
        }
    }        
}
