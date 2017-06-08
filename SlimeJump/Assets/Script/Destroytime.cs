using UnityEngine;
using System.Collections;

public class Destroytime : MonoBehaviour {



		public float lifetime = 40;

		void Start ()
		{
			Destroy (gameObject, lifetime);
		}


	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Destroy")
		{
			Debug.Log ("enter");
			Destroy (gameObject, 1);
		}
	}
}
