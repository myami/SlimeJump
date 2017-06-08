using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GooglePlayManager : MonoBehaviour {
public static GooglePlayManager instance = null;	
	public bool logins = false;
	//private Generate generate;	
	//private Pub pub;
	public bool loadpub = false ;
	public bool loadbutton = false;
	public int numbgame;
	public int hasplayed ;

	private InterstitialAd interstitial;

	// Use this for initialization
	void Start () {
		
		PlayGamesPlatform.Activate ();
		hasplayed = PlayerPrefs.GetInt( "HasPlayed");
	}
	
	// Update is called once per frame
	void Update () {

		}
	


    void Awake()
		{
	//	pub = GameObject.Find("GoogleManager").GetComponent<Pub>();
	//	generate = GameObject.Find("GameController").GetComponent<Generate>();
			//Check if instance already exists
			if (instance == null)
				
				//if not, set instance to this
				instance = this;
			
			//If instance already exists and it's not this:
			else if (instance != this)
				
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy(gameObject);	
			
			//Sets this to not be destroyed when reloading scene
			  DontDestroyOnLoad(gameObject);




}


}