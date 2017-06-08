using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {


	private Generate generate;	

	// Use this for initialization
	void Start()
	{
		GetComponent<Rigidbody2D>().velocity = generate.velocity;

	}
	void Update ()
	{
		if (generate.gameover == false)
			GetComponent<Rigidbody2D> ().velocity = generate.velocity;
		else
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		
	
	}
	void Awake()
	{

		generate = GameObject.Find("GameController").GetComponent<Generate>();


	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Destroy")
        {

            Destroy(gameObject);
        }
      

    }



}