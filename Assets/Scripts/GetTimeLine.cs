using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTimeLine : MonoBehaviour {

		/*############# MEMO #############

		id									//ツイートID
		text								//ツイート
		user.id							//ユーザーID
		user.screen_name		//screen_name
		user.name						//ユーザー名

		################################*/



	// Use this for initialization
	void Start () {
		Dictionary<string, string> parameters = new Dictionary<string, string>();
		parameters ["count"] = 5.ToString();   // 取得するツイート数
		StartCoroutine (Twity.Client.Get ("statuses/home_timeline", parameters, this.Callback));
	}

	// Update is called once per frame
	void Update () {

	}

	void Callback(bool success, string response) {
  	if (success) {
    	Twity.StatusesHomeTimelineResponse Response = JsonUtility.FromJson<Twity.StatusesHomeTimelineResponse> (response);
			//Debug.Log("Response:"+Response.items[0].text);
			for(int i = 0; i < Response.items.Length; i++){
				Debug.Log(Response.items[i].user.name+"\n"+Response.items[i].text);
			}
  	} else {
    	Debug.Log (response);
  	}
	}
}
