using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonar : MonoBehaviour
{
    float rot = 0f;
    public float rotationPerUpdate = 0.001f;
    public Transform boat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationPerUpdate);
        transform.position = boat.position;
    }

    private void FixedUpdate()
    {
        rot += rotationPerUpdate;
    }
}
