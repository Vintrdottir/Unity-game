using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;
    public bool grouned;
    public float stateBefore;
    public float difference;
    private Animator animation;

    public Renderer twinklePlayer;
    public int twinkleTime;
    public float twinkleVelocity;

	void Start () {
        player = GetComponent<Rigidbody2D> ();
        animation = GetComponent<Animator> ();
        twinklePlayer = GetComponent<Renderer>();
	}
	
    void FixedUpdate()
    {
        grouned = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        stateBefore = player.position.x;
    }

    public void EnemyConnect()
    {
        StartCoroutine(Twinkle());
    }

    IEnumerator Twinkle()
    {
        for (int i = 0; i < twinkleTime; i++) {
            twinklePlayer.enabled = false;
            yield return new WaitForSeconds(twinkleVelocity/2);
            twinklePlayer.enabled = true;
            yield return new WaitForSeconds(twinkleVelocity/2);
        }
    }

	void Update () {

        difference = Mathf.Abs(stateBefore - player.position.x);
        animation.SetFloat("Transition", difference);
        animation.SetBool("onGround", grouned);

        if(Input.GetKeyDown(KeyCode.W) && grouned)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (player.velocity.x < 0)
        {
            transform.localScale = new Vector3 (-1.5f, 1.5f, 1f);

        }

        if (player.velocity.x > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);

        }

    }


    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
    }
}
