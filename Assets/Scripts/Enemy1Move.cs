using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour {

    public float speed;
    private Rigidbody2D enemy1;
    public Transform point1;
    public Transform point2;
    public bool m_left;
    public PlayerMove player;
    public Game game;

	void Start () {

        enemy1 = GetComponent<Rigidbody2D>();
        m_left = true;
        player = FindObjectOfType<PlayerMove>();
        game = FindObjectOfType<Game>();
		
	}
	
	void Update () {

        if (enemy1.position.x < point1.position.x){
            m_left = false;
        }

        if (enemy1.position.x > point2.position.x){
            m_left = true;
        }

        if (m_left)
        {
            enemy1.velocity = new Vector2(-speed, enemy1.velocity.y);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            enemy1.velocity = new Vector2(speed, enemy1.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

     
	}

    void OnTriggerEnter2D(Collider2D whatsThat)
    {
        if (whatsThat.name == "Player")
        {
            game.EnergyChange(-1);
            player.EnemyConnect();
        }
    }
}
