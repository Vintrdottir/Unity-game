using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnergy : MonoBehaviour {

    public Game game;

	void Start () {

        game = FindObjectOfType<Game>();
		
	}
	
	void OnTriggerEnter2D (Collider2D whatsThat) {

        if (whatsThat.name == "Player")
        {
            game.EnergyChange (1);
            Destroy(gameObject);
        }
		
	}
}
