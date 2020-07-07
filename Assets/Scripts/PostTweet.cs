using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostTweet : MonoBehaviour {

  public GameObject inputTweetField;
	//public ScrollView outputField;


	//[System.NonSerialized] public string myTweet;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}


  public void OnClickTweetButon () {
  	Dictionary<string, string> parameters = new Dictionary<string, string>();
  	parameters ["status"] = inputTweetField.GetComponent<InputField> ().text;;  // ツイートするテキスト
  	StartCoroutine (Twity.Client.Post ("statuses/update", parameters, this.Callback));
  }


	void Callback(bool success, string response) {
  	if(success){
    	Twity.Tweet tweet = JsonUtility.FromJson<Twity.Tweet> (response); // 投稿したツイートが返ってくる
			//outputField.text += "\n"+tweet;
  	} else {
    	Debug.Log (response);
  	}
	}


}
