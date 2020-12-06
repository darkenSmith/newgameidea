using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public Animator animator;



    public float speed;
    public float curpos;
    //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        animator.SetBool("still", true);
    }


    void Update()
    {


       
        //Store the current horizontal input in the float moveHorizontal.
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("still", false);
            // convert user input into world movement
            float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            float verticalMovement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

            //assign movement to a single vector3
            Vector3 directionOfMovement = new Vector3(horizontalMovement, verticalMovement, 0);

            // apply movement to player's transform
            gameObject.transform.Translate(directionOfMovement);


        }
        else
        {
            animator.SetBool("still", true);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
    }



}
