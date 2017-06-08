using UnityEngine;
using System.Collections;

public class FacebookManager : MonoBehaviour {
	
	// Your app’s unique identifier.
	private string AppID = "1518610058434094";

	// The link attached to this post.
	public string Link = "https://play.google.com/store/apps/details?id=com.QuentinFreire.SlimeJump";

	// The URL of a picture attached to this post. The picture must be at least 200px by 200px.
	public string Picture = "http://i.imgur.com/FXhY7Uh.png";

	// The name of the link attachment.
	public string Name = "My New Score";

	// The caption of the link (appears beneath the link name).
	public string Caption = "I just play at SlimeJump , Can you beat my score?";

	// The description of the link (appears beneath the link caption).
	public string Description = "Enjoy fun, free games! Challenge yourself or share with friends. Fun and easy-to-use game.";




	public void ShareScoreOnFB(){
		Application.OpenURL("https://www.facebook.com/dialog/feed?"+ "app_id="+AppID+ "&link="+
			Link+ "&picture="+Picture+ "&name="+ReplaceSpace(Name)+ "&caption="+
			ReplaceSpace(Caption)+ "&description="+ReplaceSpace(Description)+
			"&redirect_uri=https://facebook.com/");
	}

	string ReplaceSpace (string val) {
		return val.Replace(" ", "%20");
	}




}