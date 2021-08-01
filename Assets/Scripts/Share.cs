using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{

	public Text Button;
	// Start is called before the first frame update
	public void SendInvitation()
	{
		//yield return new WaitForEndOfFrame();

		//Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		//ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		//ss.Apply();

		//string filePath = "Hello World!";
		//File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		//Destroy(ss);
		//Debug.Log("hi");
		new NativeShare()
			.SetSubject("Subject goes here")
			.SetText("Hello world!")
			.SetUrl("https://github.com/yasirkula/UnityNativeShare")
			.SetCallback((result, shareTarget) =>
			{
				Debug.Log("Share result: " + result + ", selected app: " + shareTarget);
				Button.text = result.ToString();
				if (result != NativeShare.ShareResult.NotShared)
				{
					//Todo: save an escrew into the DB
					//call the API 'Post /create-escrow'
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
