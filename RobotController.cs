using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    //This will be our maximum speed as we will always be multiplying by 1
    public float maxSpeed = 2f;

    //A boolean value to represent whether we are facing left or not
    bool facingLeft = true;

    //A value to represent our Animator
    Animator anim;
    
    private float move = 0f;

    //To check ground and have a jumpforce we can change in the editor
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;

    // Start is called before the first frame update
    void Start()
    {
        //Set anim to our animator
        anim = GetComponent<Animator>();
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set our vSpeed
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        //set our grounded bool
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        Debug.Log($"Grounded var is: {grounded}");

        //set ground in our Animator to match grounded
        anim.SetBool("Ground", grounded);

        //TESTING - uncomment this part
        move = Input.GetAxisRaw("Horizontal"); //Give us 1/-1 if we are moving via the arrow keys

        //move our Players rigidbody
        GetComponent<Rigidbody2D>().velocity = new Vector3(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //set our speed
        anim.SetFloat("Speed", Mathf.Abs(move));    

        //if we are moving left but not facing left flip, and vice versa
        if (move < 0 && !facingLeft)
        {
            Flip();
        }
        else if (move > 0 && facingLeft)
        {
            Flip();
        }
    }

    private void Update()
    {
        //If Robot is on the ground and the space bar was pressed, change our ground state and add an upward force
        if ( grounded && Input.GetKeyDown (KeyCode.Space))
        {
            Debug.Log("space bar pressed");

            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
    
    //Flip robot if needed
    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
