using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilLine : MonoBehaviour
{
    public GameObject obj;          //To refer to our prefab pencil line
    float lastx = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If we have moved far enough to make a new pencil line
        if (transform.position.x > (lastx+0.02f))
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            lastx = transform.position.x;
            lastx = transform.position.x;
        }
    }
}
