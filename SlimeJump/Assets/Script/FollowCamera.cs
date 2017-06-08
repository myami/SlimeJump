using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform Player;
	public int yOffset = 2;
	public int xOffset = 5;
	public int zOffset = -5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Player.position.x + xOffset,Player.position.y + yOffset , zOffset);
	}
}
