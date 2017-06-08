using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Sprite spritegreen;
	public Sprite spriteviolet;
	public Sprite spritejaune;
	public Sprite spritebleu;
	public Vector2 jumpForce = new Vector2(0, 300);
	public Vector2 jumpForces = new Vector2(0, 310);
	public Vector2 DownForce = new Vector2 (0, -10);
	public Vector2 mouvementvector = new Vector2(5,0);
	public int jumpcan = 4;
	public int sprites;
	public int points;
	public bool dontjump = false;
	public bool leaveplatform = false;
	private Generate generate;	
	private GooglePlayManager googleplaymanager;	
	private SpriteRenderer spriteRenderer; 

	// Update is called once per frame
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		playercharacter();
	}
	void playercharacter()
	{
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = spritegreen; 
			sprites = 1;
			PlayerPrefs.SetInt ("SpritesPlayer", 1);
			Debug.Log ("Changesprite:" + PlayerPrefs.GetInt("SpritesPlayer"));
		}
		if (PlayerPrefs.GetInt("SpritesPlayer") == 3)
		{
			spriteRenderer.sprite = spriteviolet;
		}

		if (PlayerPrefs.GetInt("SpritesPlayer") == 2)
		{
			spriteRenderer.sprite = spritebleu;
		}
		if (PlayerPrefs.GetInt("SpritesPlayer") == 4)
		{
			spriteRenderer.sprite = spritejaune;

		}

	}
	public void buybleu()
	{
		if (PlayerPrefs.GetInt("Gold") >= 100 && PlayerPrefs.GetInt ("BuyBleu") == 0)
		{
			PlayerPrefs.SetInt ("SpritesPlayer", 2);
			spriteRenderer.sprite = spritebleu;
			points = PlayerPrefs.GetInt("Gold") ;
			points -= 100;
			PlayerPrefs.SetInt ("Points", points );
			PlayerPrefs.SetInt ("BuyBleu", 1);
			Social.ReportProgress("CgkI7KnE_d0eEAIQCQ", 100.0f, (bool successs) => {
			});
		}
		if (PlayerPrefs.GetInt ("BuyBleu") == 1) {
			PlayerPrefs.SetInt ("SpritesPlayer", 2);
			spriteRenderer.sprite = spritebleu;
		}
	}
	public void buygreen()
	{
		
			PlayerPrefs.SetInt ("SpritesPlayer", 1);
			spriteRenderer.sprite = spritegreen;
	}
	public void buyviolet()
	{
		if (PlayerPrefs.GetInt("Gold") >= 150 && PlayerPrefs.GetInt ("BuyViollet") == 0)
		{
			PlayerPrefs.SetInt ("SpritesPlayer", 3);
			spriteRenderer.sprite = spriteviolet;
			points = PlayerPrefs.GetInt("Gold") ;
			points -= 150;
			PlayerPrefs.SetInt ("Points", points );
			PlayerPrefs.SetInt ("BuyViollet", 1);
		}
		if (PlayerPrefs.GetInt ("BuyViollet") == 1)
		{
			PlayerPrefs.SetInt ("SpritesPlayer", 3);
			spriteRenderer.sprite = spriteviolet;
		}
	}
	public void buyjaune()
	{
		if (PlayerPrefs.GetInt("Gold") >= 200 && PlayerPrefs.GetInt ("BuyJaune") == 0)
		{
			PlayerPrefs.SetInt ("SpritesPlayer", 4);
			spriteRenderer.sprite = spritejaune;
			points = PlayerPrefs.GetInt("Gold") ;
			points -= 200;
			PlayerPrefs.SetInt ("Points", points );
			PlayerPrefs.SetInt ("BuyJaune", 1);
		}
		if (PlayerPrefs.GetInt ("BuyJaune") == 1) 
		{
			PlayerPrefs.SetInt ("SpritesPlayer", 4);
			spriteRenderer.sprite = spritejaune;
		}
	}

	void Update ()
	{
		menu ();
        Mouvement();

    }
	void FixedUpdate () // compiler en premier a chaque frame
	{
		
	}

	void menu ()
	{
		if (googleplaymanager.hasplayed == 0 && generate.menu == false) 
		{
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
			{
				Vector2 touchDeltaPosition = Input.GetTouch(0).position;
				if(touchDeltaPosition.x < Screen.width /2.0 ){


					generate.gauchetuto = true;


				}
				else if (touchDeltaPosition.x > Screen.width /2.0 ) {

					generate.droitetuto = true;

				}

			}
			if (generate.droitetuto == true) {

				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
					generate.fintuto = true;
				}
			}
		}

	}
    void Mouvement ()
    {
		if (dontjump == false && generate.menu == false && googleplaymanager.hasplayed == 1 && generate.gameover == false && generate.shop == false) {


			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
			{

				Vector2 touchDeltaPosition = Input.GetTouch(0).position;

				if(touchDeltaPosition.x < Screen.width /2.0 ){


					GetComponent<Rigidbody2D> ().velocity = -mouvementvector;
					GetComponent<Rigidbody2D> ().AddForce (jumpForce);
					jumpcan--;


				}
				else if (touchDeltaPosition.x > Screen.width /2.0 ) {

					GetComponent<Rigidbody2D> ().velocity = mouvementvector;
					GetComponent<Rigidbody2D> ().AddForce (jumpForces);
					jumpcan--;

				}
			}

			if (Input.GetKeyUp ("d")) 
			{
				GetComponent<Rigidbody2D> ().velocity = mouvementvector;
				GetComponent<Rigidbody2D> ().AddForce (jumpForce);
				jumpcan--;
			}
			if (Input.GetKeyUp ("a")) 
			{
				GetComponent<Rigidbody2D> ().velocity = -mouvementvector;
				GetComponent<Rigidbody2D> ().AddForce (jumpForces);
				jumpcan--;
			}

		}
		if (jumpcan == 0) 
		{
			dontjump = true;
			GetComponent<Rigidbody2D> ().velocity = DownForce;
		}
    }
	void Awake()
	{
		generate = GameObject.Find("GameController").GetComponent<Generate>();
		googleplaymanager = GameObject.Find("GoogleManager").GetComponent<GooglePlayManager>();


	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			Debug.Log("Touch the wall!!!!!");
			generate.score ++;
			jumpcan = 4;
			dontjump = false;
			coll.gameObject.tag = "TouchWall";

		}
		if (coll.gameObject.tag == "Ground") 
		{
			generate.gameover = true;
		}

		if (coll.gameObject.tag == "Rock") 
		{
			jumpcan--;
			Debug.Log ("rock touch");
		}
		if (coll.gameObject.tag == "LimiteTop") 
		{
			transform.position = new Vector2 (0, 150);
			jumpcan = 4;
		}

	}

	void OnCollisionExit2D(Collision2D colls)
	{
		if (colls.gameObject.tag == "Begin")
		{
			Debug.Log("Leave!!!!!");
			Destroy (colls.gameObject,1);
			leaveplatform = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{

		if (other.gameObject.tag == "Coins" && generate.gameover == false) 
		{
			Debug.Log("une piece!!!!!");
			PlayerPrefs.SetInt ("Gold", PlayerPrefs.GetInt("Gold")+ 1);
			Destroy (other.gameObject, 0);

		
		}

	}




	}
	
