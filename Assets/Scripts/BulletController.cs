using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {


	[SerializeField] GameObject EffectPrefab;


	public int damege = 1;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "Enemy" && this.tag != "EnemyDanmaku"){
			//Destroy (coll.gameObject);
			//if(coll.HP < 0)		//自身,敵のオブジェクトに実装
			//	Instantiate(EffectPrefab, coll.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}else if(coll.gameObject.tag == "Player" && this.tag == "EnemyDanmaku"){
			
			Destroy(gameObject);
		}
	}
}
