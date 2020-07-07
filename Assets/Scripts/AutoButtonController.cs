using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AutoButtonController : MonoBehaviour {

	public GameObject playerController;

	private MoveTwiButton moveTwiButton;

	public Sprite autoButtonImg;
	public Sprite manualButtonImg;

	Image changeButton;


	public GameObject ChTwiBut;


	public Image buttonMark;
	[System.NonSerialized] public bool markMove = false;

	public GameObject stickButton;


	AutoController player1Auto;
	PlayerController playerControllerEnabled;



	// Use this for initialization
	void Start () {
		changeButton = GetComponent<Image>();
		player1Auto = playerController.GetComponent<AutoController>();
		playerControllerEnabled = playerController.GetComponent<PlayerController>();
		//stickButton = GameObject.Find("MoneButtonObject");
		moveTwiButton = GameObject.Find("TwitterCanvas/Twitter")
													.GetComponent<MoveTwiButton>();
	}

	// Update is called once per frame
	void Update () {
		if(markMove){
			buttonMark.transform.Rotate (0, 0, -3);
		}
	}


	public void ChangeImage(){
		if(moveTwiButton.flg == true){
	    if (changeButton.sprite == autoButtonImg){		// 自律戦闘ONの時
				stickButton.SetActive(false);
	      changeButton.sprite = manualButtonImg;
				markMove = true;
				player1Auto.enabled = !player1Auto.enabled;
				playerControllerEnabled.enabled = !playerControllerEnabled.enabled;
				ChTwiBut.SetActive(true);
			} else {
				stickButton.SetActive(true);
	      changeButton.sprite = autoButtonImg;			// 自律戦闘OFFの時
				markMove = false;
				player1Auto.enabled = !player1Auto.enabled;
				playerControllerEnabled.enabled = !playerControllerEnabled.enabled;
				ChTwiBut.SetActive(false);
	    }
		}
 	}
}
