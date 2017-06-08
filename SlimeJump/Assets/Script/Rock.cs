using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	private Generate generate;

	public float lifetime = 40;

	void Start()
	{
		Destroy (gameObject, lifetime);
	}
	
	void Update ()
	{
		GetComponent<Rigidbody2D>().velocity = generate.Rockvelocity;

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
