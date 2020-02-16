using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    float x;
    float y;
    float dx;
    float dy;
    public float energy;
    public GameObject Energy1;
    public GameObject Energy2;
    public GameObject Energy3;
    public GameObject Energy4;

    public string start_menu;

    void Start () {

        Energy1 = GameObject.Find("Energy1");
        Energy2 = GameObject.Find("Energy2");
        Energy3 = GameObject.Find("Energy3");
        Energy4 = GameObject.Find("Energy4");

        dx = transform.position.x - Camera.main.gameObject.transform.position.x;
        dy = transform.position.y - Camera.main.gameObject.transform.position.y;
    }
	
	void Update () {

        Position();
        Energy();
	}

    void Position ()
    {
        x = Camera.main.gameObject.transform.position.x + dx;
        y = Camera.main.gameObject.transform.position.y + dy;
        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void EnergyChange (int value)
    {
        energy = energy + value;
        if (energy<0)
        {
            Application.LoadLevel(start_menu);
        }

        if (energy > 5)
        {
            energy = 5;
        }
    }

    void Energy()
    {
       if (energy >= 4)
        {
            Energy4.GetComponent<Renderer> ().enabled = true;
        } else
        {
            Energy4.GetComponent<Renderer>().enabled = false;
        }

        if (energy >= 3)
        {
            Energy3.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Energy3.GetComponent<Renderer>().enabled = false;
        }

        if (energy >= 2)
        {
            Energy2.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Energy2.GetComponent<Renderer>().enabled = false;
        }

        if (energy >= 1)
        {
            Energy1.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            Energy1.GetComponent<Renderer>().enabled = false;
        }

        
    }

    
}
