using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;



public class Generate : MonoBehaviour {
	


	public float time;
	public float spawnWait;
	public float spawnWaitObject;
	private string Leaderboard = "CgkI7KnE_d0eEAIQAA";
	public int hazardCount;
	public int numberofobject;
	public int i = 0;
	public int score ;
	public int HighScores;
	public float up = 0F;
	public int waittuto = 2;
	public float IV = 0.1F;
	public Text pointstext ;
	public Text Onpause;
	public GameObject wall;
	public GameObject rockgris;
	public GameObject rockrouge;
	public GameObject rockmarron;
	public GameObject menucanvas;
	public GameObject gameovercanvas;
	public GameObject ShopCanvas;
	public GameObject Loginbutton;
	public GameObject LaunchGame;
	public GameObject TutorielCanvas;
	public GameObject TutorielCanvasgauche;
	public GameObject TutorielCanvasdroite;
	public GameObject TutorielCanvasfinal;
	public GameObject eclairblanc1;
	public GameObject eclaijaune1;
	public GameObject eclairblanc2;
	public GameObject eclaijaune2;
	public GameObject eclairblanc3;
	public GameObject eclaijaune3;
	public GameObject pausetrue;
	public GameObject pausefalse;
	public GameObject coins;
    public GameObject SkinsButton;
    public GameObject BackgroundButton;
    public GameObject GroundButton;
    public GameObject FondShop;
    public GameObject Skin;
    public GameObject Background;
    public GameObject Ground;
	public GameObject Shops;
	public GameObject GO;
	public Vector2 velocity = new Vector2(0,-4);
	public Vector2 Rockvelocity = new Vector2 (0, -5);
    public Vector2 spawnPosition;
	public bool logins = false;
	public bool gameover = false;
	public bool menu = true;
	public bool restart = false;
	public bool gauchetuto = false;
	public bool droitetuto = false;
	public bool fintuto = false;
	public bool fintutotimer = false;
	public bool shop = false;
	public bool isinpause = false;
    public bool skinshop = false;
    public bool backgroundshop = false;
    public bool groundshop = false;
    public bool bonusshop = false;
	public bool GOB = false;
	private Player player;	
	private GooglePlayManager googleplaymanager;	
	private Obstacle obstacle;
	private Pub pub;
		
		
	 public void truepause ()
	{
		
			isinpause = true;

	}
	public void falsepause ()
	{
		isinpause = false;
	
	}
    public void skinButton()
    {
        skinshop = true;
        backgroundshop = false;
        groundshop = false;
        bonusshop = false;
    }
    public void backgroundbutton()
    {
        skinshop = false;
        backgroundshop = true;
        groundshop = false;
        bonusshop = false;
    }
    public void goundbutton()
    {
        skinshop = false;
        backgroundshop = false;
        groundshop = true;
        bonusshop = false;
    }

	void Start ()
	{
		
		pub.RequestInterstitial ();
		StartCoroutine (SpawnWaves ());

		StartCoroutine (SpawnObject ());
		InvokeRepeating("IncreaseVelocity", 8f, 8f); 

		spawnWaitObject = Random.Range(25,60);


	}

	IEnumerator SpawnWaves ()
	{
		while (true) {
			if (gameover == false) {
				for (i = 0; i < hazardCount; i++) {

					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (wall, spawnPosition, spawnRotation);
                    up += 0.3F;
                    spawnPosition = new Vector2(-4, 234 + up);
                    yield return new WaitForSeconds (spawnWait);
				}
	

			}
		}

		
	}
	IEnumerator SpawnObject ()
	{
		
		while (true) {
			if (gameover == false) {
				for (int o = 0; o < numberofobject; o++) {
					Vector2 spawngold = new Vector2 (Random.Range (-1, 2), 223);
					Instantiate (coins , spawngold, Quaternion.identity);
					yield return new WaitForSeconds (spawnWaitObject);

				}
               
			}
		}

	}
	void IncreaseVelocity ()
	{
		velocity = new Vector2 (0, -5 - IV);
		IV += 0.2F;
		Debug.Log ("velocity" + IV + velocity + spawnWait);
		spawnWait -= 0.045F;
		spawnWaitObject += 0.04F;
	}


	void Update ()
	{

	
	
		menus ();
		//timers ();
		eclair ();
		ispaused ();
		pubs ();

		if (spawnWait <= 0) 
		{
			spawnWait = 0;
		}
			


	
	}

	void ispaused()
	{
		if (isinpause == false) 
		{
			Time.timeScale = 1F;
			Onpause.enabled = false;
			pausefalse.SetActive (false);
			pausetrue.SetActive (true);

		}
		if (isinpause == true && gameover == false) 
		{
			Onpause.enabled = true;
			Onpause.text = "You're game is paused";
			Time.timeScale = 0F;
			pausefalse.SetActive (true);
			pausetrue.SetActive (false);

		}
	}
	void Awake()
	{

		player = GameObject.Find("Player").GetComponent<Player>();
		googleplaymanager = GameObject.Find("GoogleManager").GetComponent<GooglePlayManager>();
		pub = GameObject.Find("GoogleManager").GetComponent<Pub>();


	}

	public void login ()
	{
		Social.localUser.Authenticate((bool success) => {
			if (success)
			{
				Debug.Log("Connected");
				menu = false;
				googleplaymanager.logins = true;
				Social.ReportProgress("CgkI7KnE_d0eEAIQAQ", 100.0f, (bool successs) => {
				});

			}
			else{
				
				Debug.Log("Not Connected");
			}
		});

		googleplaymanager.logins = true;
		menu = false;
	}

	public void play ()
	{
		menu = false;
	}
	public void restarts ()
	{
		SceneManager.LoadScene ("test");
	}
	public void shopsbuttonenter()
	{
		shop = true;
       
	}
	public void shopsbuttonleave()
	{
		shop = false;
        
	}

	public void leaderboard ()
	{
		if (googleplaymanager.logins == true) {
			//Social.ShowLeaderboardUI ();
			PlayGamesPlatform.Instance.ShowLeaderboardUI (Leaderboard);             
		}
	}
	public void rate ()
	{
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.QuentinFreire.SlimeJump");
	}




	void menus ()
	{
		if( googleplaymanager.hasplayed == 0 && menu == false )
		{
			// premier lancement du jeux
			// Initialize...etc
			Time.timeScale = 0F;
			TutorielCanvas.SetActive(true);
			TutorielCanvasgauche.SetActive (true);
			TutorielCanvasdroite.SetActive (false);
			TutorielCanvasfinal.SetActive (false);
			if (gauchetuto == true) 
			{
				TutorielCanvasgauche.SetActive (false);
				TutorielCanvasdroite.SetActive (true);
				TutorielCanvasfinal.SetActive (false);
			}
			if (droitetuto == true) 
			{
				TutorielCanvasgauche.SetActive (false);
				TutorielCanvasdroite.SetActive (false);
				TutorielCanvasfinal.SetActive (true);

			}
			if (fintuto == true) 
			{
				TutorielCanvas.SetActive (false);
				PlayerPrefs.SetInt ("HasPlayed", 1);
				googleplaymanager.hasplayed++;
				Social.ReportProgress("CgkI7KnE_d0eEAIQAQ", 100.0f, (bool success) => {
					// handle success or failure
				});

			}

		}
		else
		{
			TutorielCanvas.SetActive(false);
			Time.timeScale = 1F;
			// pas la premiere fois
		}



			if (score > PlayerPrefs.GetInt("PlayScore"))     
			{
				PlayerPrefs.SetInt ("PlayScore", score);
				Debug.Log ("New HighScore : " + "score : " + score + "HighScoreSaved : " + PlayerPrefs.GetInt("PlayScore") );

				PlayerPrefs.Save ();
				Social.ReportScore(PlayerPrefs.GetInt("PlayScore") , Leaderboard, (bool success) => {
					Debug.Log("Succes you're score is update !!!");
					if (PlayerPrefs.GetInt("PlayScore") >= 100)
					{
						Social.ReportProgress("CgkI7KnE_d0eEAIQBA", 100.0f, (bool successs) => {
							
						});
					}
					if (PlayerPrefs.GetInt("PlayScore") >= 200)
					{
						Social.ReportProgress("CgkI7KnE_d0eEAIQAg", 100.0f, (bool successs) => {
							
						});
					}
					if (PlayerPrefs.GetInt("PlayScore") >= 500)
					{
						Social.ReportProgress("CgkI7KnE_d0eEAIQBQ", 100.0f, (bool successs) => {
							
						});
					}
					if (PlayerPrefs.GetInt("PlayScore") >= 1000)
					{
						Social.ReportProgress("CgkI7KnE_d0eEAIQCA", 100.0f, (bool successs) => {
							
						});
					}
				});

			}


		if (googleplaymanager.logins == true) 
		{
			LaunchGame.SetActive (true);
			Loginbutton.SetActive (false);
		}
		else 
		{
			Loginbutton.SetActive (true);
			LaunchGame.SetActive (false);
		}


		if (i == 50) 
		{
			i -= 50;
			Debug.Log ("Add 50 spawn");
		}
		if (gameover == false  && shop == false && player.leaveplatform == true)
        { //

            time += Time.deltaTime;
		}
        if (menu == true)
        {
            menucanvas.SetActive(true);
        }
        else
        {
         
            menucanvas.SetActive(false);


        }

      
     
        if (logins == true) 
		{
			Loginbutton.SetActive (false);
		}
		if (gameover == true)
		{
			gameovercanvas.SetActive(true);
			Time.timeScale = 0;
			GOB = true;
		}
		else {
			Time.timeScale = 1;
			gameovercanvas.SetActive(false);


		}
		if (shop == true) {
			GOB = false;
			Shops.SetActive (true);
	
            pointstext.text = " Gold : " + PlayerPrefs.GetInt ("Gold");
            



        } else 
		{
			Shops.SetActive (false);
			GOB = true;
            skinshop = false;
            backgroundshop = false;
            groundshop = false;
            bonusshop = false;
        }
		if (GOB == true) {
			GO.SetActive (true);
		} else 
		{
			GO.SetActive (false);
		}
        if (skinshop == true)
        {
           
            Skin.SetActive(true);
         
        }
        else
        {
            Skin.SetActive(false);
        }
        if (backgroundshop == true)
        {
           
            Background.SetActive(true);
        }
        else
        {
            Background.SetActive(false);
        }
        if (groundshop == true)
        {
            
            Ground.SetActive(true);
        }
        else
        {
            
            Ground.SetActive(false);
        }
     




    }

	void eclair ()
	{
		if (player.jumpcan == 4 && gameover == false) 
		{
			eclaijaune3.SetActive (true);
			eclaijaune2.SetActive (true);
			eclaijaune1.SetActive (true);
			eclairblanc3.SetActive (true);
		
		}
		if (player.jumpcan == 3 && gameover == false) 
		{
			eclaijaune3.SetActive (false);
			eclaijaune2.SetActive (true);
			eclaijaune1.SetActive (true);


		}
		if (player.jumpcan == 2 && gameover == false) 
		{
			eclaijaune2.SetActive (false);
			eclaijaune1.SetActive (true);
		}
		if (player.jumpcan == 1 && gameover == false) 
		{
			eclaijaune1.SetActive (false);
		}
		if (menu == true) {
			eclaijaune1.SetActive (true);
			eclaijaune2.SetActive (true);
			eclaijaune3.SetActive (true);
			eclairblanc1.SetActive (false);
			eclairblanc2.SetActive (false);
			eclairblanc3.SetActive (false);


		} 
		else 
		{
			
			menucanvas.SetActive (false);
			eclairblanc1.SetActive (true);
			eclairblanc2.SetActive (true);
			eclairblanc3.SetActive (true);

		}

		if (gameover == true) {
		
            eclaijaune1.SetActive(false);
            eclaijaune2.SetActive(false);
            eclaijaune3.SetActive(false);
            eclairblanc1.SetActive(false);
            eclairblanc2.SetActive(false);
            eclairblanc3.SetActive(false);
            
        } else {
			
			gameovercanvas.SetActive (false);
		

		}

	}

	 void pubs ()
	{
		if(gameover == true && shop == false)
		{
			pub.ShowInterstitial ();
		}

	}

	
}


