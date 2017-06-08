using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	private SpriteRenderer spriteRenderer; 
	public Sprite lava;
	public Sprite water;
	public int points;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (PlayerPrefs.GetInt("SpritesGround") == 2)
		{
			spriteRenderer.sprite = water;
		}
		if (PlayerPrefs.GetInt ("SpritesGround") == 1) 
		{
			spriteRenderer.sprite = lava;
		}
	}

	public void groundwater()
	{
		if (PlayerPrefs.GetInt("Gold") >= 100 && PlayerPrefs.GetInt ("Buyoceanground") == 0)
		{
			PlayerPrefs.SetInt ("SpritesGround", 2);
			spriteRenderer.sprite = water;
			points = PlayerPrefs.GetInt("Gold") ;
			points -= 100;
			PlayerPrefs.SetInt ("Points", points );
			PlayerPrefs.SetInt ("Buyoceanground", 1);
			Social.ReportProgress("CgkI7KnE_d0eEAIQDQ", 100.0f, (bool successs) => {
			});
		}
		if (PlayerPrefs.GetInt ("Buyoceanground") == 1) {
			PlayerPrefs.SetInt ("SpritesGround", 2);
			spriteRenderer.sprite = water;
		}
	}

	public void groundlava()
	{

		PlayerPrefs.SetInt ("SpritesGround", 1);
		spriteRenderer.sprite = lava;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
