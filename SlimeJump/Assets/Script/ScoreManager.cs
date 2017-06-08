using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	private Generate generate;	
	int previousScore = -1;
	public Sprite[] numberSprites;
	public SpriteRenderer Units, Tens, Hundreds;

	void Start () {
		(Tens.gameObject as GameObject).SetActive (false);
		(Hundreds.gameObject as GameObject).SetActive (false);
		 
	}
	

	void Update () {
		if (previousScore != generate.score) 
{
	if (generate.score < 10) 
	{
		Units.sprite = numberSprites [generate.score];

	} 

	   else if (generate.score >= 10 && generate.score < 100) 
		{
		(Tens.gameObject as GameObject).SetActive (true);
		Tens.sprite = numberSprites [generate.score / 10];
		Units.sprite = numberSprites [generate.score % 10];
		} 
			else if (generate.score >= 100) 
			{
				(Hundreds.gameObject as GameObject).SetActive (true);
				Hundreds.sprite = numberSprites [generate.score / 100];
				int rest = generate.score % 100;
				Tens.sprite = numberSprites [rest / 10];
				Units.sprite = numberSprites [rest % 10];
			}
}
	
	}



	void Awake()
	{
		generate = GameObject.Find("GameController").GetComponent<Generate>();

	}
}
