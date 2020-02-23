using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float maxSpeed = 2f;                     //Maximum speed for robot
    bool facingLeft = true;                         //Value to represent if we are facing left or right
    Animator anim;                                  //Value to represent our Animator

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();            //Set anim to our Animator
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");   //Give a value of one, if we are using arrow keys to move

        //move the players rigid body
        GetComponent<Rigidbody2D>().velocity = new Vector3(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //set our speed
        anim.SetFloat("Speed", Mathf.Abs(move));

        //checks if we are moving left, but not facing left - then flips to face moving way
        if (move < 0 && !facingLeft)
        {
            Flip();
        }
        else if (move > 0 && facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
