using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyGirlController : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer rbSprite;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("isJumping", true);
            Debug.Log("space key was pressed");
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetMouseButtonDown(1)){
            rbSprite.flipX = false;
            animator.SetBool("isSkipping", true);
            Debug.Log("right mouse button was pressed");
            rb.AddForce(Vector2.right * 1 + Vector2.up * 2, ForceMode2D.Impulse);

        }else if (Input.GetMouseButtonDown(0)) {

            rbSprite.flipX = true;
            animator.SetBool("isSkipping", true);
            Debug.Log("left mouse button was pressed");
            rb.AddForce(Vector2.left * 1 + Vector2.up * 2, ForceMode2D.Impulse);
            //StartCoroutine(WaitBeforeSkipAgain());

        }else{
             animator.SetBool("isSkipping", false);
        }     
    }

    IEnumerator WaitBeforeSkipAgain()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
