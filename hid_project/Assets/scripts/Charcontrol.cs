using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charcontrol : MonoBehaviour {

    private Rigidbody2D rb2d;
    private SpriteRenderer spriterenderer;
    public int facing = 1;
    public Animator anim;

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal < 0) {
            spriterenderer.flipX = true;
            facing = 1;
            anim.SetBool("walking", true);
        } else if (moveHorizontal > 0) {
            spriterenderer.flipX = false;
            facing = -1;
            anim.SetBool("walking", true);
        } else
        {
            anim.SetBool("walking", false);
        }

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal*2.5f, -.6f);

        rb2d.velocity = movement;
    }
}
