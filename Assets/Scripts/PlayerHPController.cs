using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHPController : MonoBehaviour {

	private int hp = 300;

	[SerializeField] private Slider playerHPbar;
	[SerializeField] GameObject EffectPrefab;

	[SerializeField] GameObject GameOverEffect;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		/*
		this.hp -= col.damage;
		if(this.hp <= 0){
			// 死亡処理
		} //*/
	}


	void OnParticleCollision(GameObject col){
    hp -= 40;
		playerHPbar.value = hp;

		//Debug.Log(hp);

		if(hp <= 0){
			//GameOver();
		}
	}


	//GameOver
	void GameOver(){
		//GetComponent<Animator>().enabled = !GetComponent<Animator>().enabled;
		//Destroy(gameObject);
		Instantiate(EffectPrefab, transform.position, Quaternion.identity);
		Instantiate(GameOverEffect, new Vector2(0, 0), Quaternion.identity);
		//this.enabled = !this.enabled;

		//Playerや弾,時間を止め、GameOver画面の表示
		//これはGameManagerに書く？
	}
}
