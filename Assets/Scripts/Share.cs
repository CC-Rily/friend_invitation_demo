using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
	//public string username;
	public Text Button;

	string Username;
	int Coins;
	string Link;

	// Start is called before the first frame update
	public void SendInvitation()
	{
		//Todo
		//This information is got from some global variables
		//Please define them in your code
		Username = "Joey";
		Coins = 10;
		Link = "www.google.com";
		
		new NativeShare()
			.SetSubject("You receive an invitation!")
			.SetText("Hello! Your friend " + Username +
			"wants to invite you to project Minions, click the link below to get your initial coins!")
			.SetUrl(Link)
			.SetCallback((result, shareTarget) =>
			{
				Debug.Log("Share result: " + result + ", selected app: " + shareTarget);
				Button.text = result.ToString();
				if (result != NativeShare.ShareResult.NotShared)
				{
                    //get a linkID
                    string linkId = LinkIDGenerator.getUUIDLinkId();

					//Todo: save an escrew into the DB
					//call the API 'Post /create-escrow'
					//call the API 'PUT /update-coins'
				}
				else
				{
					Button.text = "fail!";
					//Todo: pop up a failure notification
				}
			})
			.Share();

		// Share on WhatsApp only, if installed (Android only)
		//if( NativeShare.TargetExists( "com.whatsapp" ) )
		//	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
	}

	//private string GenerateUrl(int TimeStamp, string FromUser, string ToUser, string SocialMedia, int Coins)
	//{
	//	//Tiny URL technology
	//	//Needed to be reasearched
	//}
}
