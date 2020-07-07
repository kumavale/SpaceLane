using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHPController : MonoBehaviour {

	private int hp = 300;

	[SerializeField] private Slider enemyHPbar;

	[SerializeField] GameObject EffectPrefab;


	// Use this for initialization
	void Start () {
		//pauseController = GameObject.Find("CanvasUI/Pause").GetComponent<PauseController>();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		BulletController colBullet = col.GetComponent<BulletController>();
		hp -= colBullet.damege;
		enemyHPbar.value = hp;

		if(hp <= 0){
			EnemyNoLife();
		}
	}

	void OnParticleCollision(GameObject col){
    hp -= 10;
		enemyHPbar.value = hp;

		if(hp <= 0){
			EnemyNoLife();
		}
	}



	// Enemy Life 0
	void EnemyNoLife(){
		Destroy(gameObject);
		Instantiate(EffectPrefab, transform.position, Quaternion.identity);

		//Playerや弾,時間を止め、クリア画面の表示
	}
}
