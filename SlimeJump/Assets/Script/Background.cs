using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	private SpriteRenderer spriteRenderer; 
	public Sprite lava;
	public Sprite water;
	public int points;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (PlayerPrefs.GetInt("SpritesBackGround") == 2)
		{
			spriteRenderer.sprite = water;
		}
		if (PlayerPrefs.GetInt ("SpritesBackGround") == 1) 
		{
			spriteRenderer.sprite = lava;
		}
	}

	public void groundwater()
	{
		if (PlayerPrefs.GetInt("Gold") >= 100 && PlayerPrefs.GetInt ("BuyoceanBackground") == 0)
		{
			PlayerPrefs.SetInt ("SpritesBackGround", 2);
			spriteRenderer.sprite = water;
			points = PlayerPrefs.GetInt("Gold") ;
			points -= 100;
			PlayerPrefs.SetInt ("Points", points );
			PlayerPrefs.SetInt ("Buyoceanbackground", 1);
		
			Social.ReportProgress("CgkI7KnE_d0eEAIQDA", 100.0f, (bool successs) => {
			});
		}
		if (PlayerPrefs.GetInt ("Buyoceanbackground") == 1) {
			PlayerPrefs.SetInt ("SpritesBackGround", 2);
			spriteRenderer.sprite = water;
		
		}
	}

	public void groundlava()
	{

		PlayerPrefs.SetInt ("SpritesBackGround", 1);
		spriteRenderer.sprite = lava;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
