using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {
	private GameObject playerObjact;
	private GameObject[] enemyObjacts;
	private GameObject[] bulletObjects;
	private GameObject[] itemObjects;

	AutoController playerAuto;
	PlayerController playerMove;
	GameManager gameManagerEnable;

	MoveSupport moveEnable;

	bool changeOK = true;
	bool flg = false;		//自律戦闘の部分をいじったかのフラグ

	public GameObject autoButton;
	public GameObject moveSupport;

	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		if(changeOK) {
			flg = false;			//初期化
			Time.timeScale = 0;	//時間を止める
			AutoChange();
			changeOK = false;	//繰り返さないようにする
		}
	}


	public void TimeScaleEnable(){	//出て行く時
		if(flg){
			playerAuto.enabled = !playerAuto.enabled;
			autoButton.GetComponent<AutoButtonController>().markMove = flg;
		}
		Time.timeScale = 1;	//時間を動かす
		changeOK = true;	//初期化
	}


	public void AutoChange(){	//ポーズ画面に入るとき&出て行くとき
		SearchObjects();
		gameManagerEnable.enabled = !gameManagerEnable.enabled;
		moveEnable.enabled = !moveEnable.enabled;
		playerMove.enabled = !playerMove.enabled;
		bool _markMove = autoButton.GetComponent<AutoButtonController>().markMove;
		if(bulletObjects != null){
			foreach(GameObject obj in bulletObjects){
				obj.GetComponent<ScrollController>().enabled
					= !obj.GetComponent<ScrollController>().enabled;
			}
		}
		if(_markMove == true  && flg == false) {
			playerAuto.enabled = !playerAuto.enabled;
			autoButton.GetComponent<AutoButtonController>().markMove = flg;
			flg = !flg;
		}
		if(enemyObjacts != null){
			foreach(GameObject obj in enemyObjacts){
				obj.GetComponent<AutoController>().enabled
					= !obj.GetComponent<AutoController>().enabled;
			}
		}
		if(itemObjects != null){
			foreach(GameObject obj in itemObjects){
				obj.GetComponent<ScrollController>().enabled
					= !obj.GetComponent<ScrollController>().enabled;
			}
		}
	}


	void SearchObjects(){
		playerObjact = GameObject.Find("PlayerController");
		gameManager = GameObject.Find("GameManager");
		enemyObjacts = GameObject.FindGameObjectsWithTag("Enemy");
		bulletObjects = GameObject.FindGameObjectsWithTag("Bullet");
		itemObjects = GameObject.FindGameObjectsWithTag("Item");
		playerAuto = playerObjact.GetComponent<AutoController>();
		playerMove = playerObjact.GetComponent<PlayerController>();
		moveEnable = moveSupport.GetComponent<MoveSupport>();
		gameManagerEnable = gameManager.GetComponent<GameManager>();
	}


}
