using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public GameObject WeaponPrefab;
	public GameObject RokeranPrefab;
	public GameObject Enemy_SpacemanPrefab;
	public GameObject tirashiBomPrefab;
	public GameObject bulletPrefab;
	public GameObject bulletDanmaku_1;
	public GameObject bulletDanmaku_2;
	public GameObject bulletDanmaku_3;
	GameObject meteorStorm;


	public GameObject playerController;
	[SerializeField] private GameObject twitter;


	Vector3 playerPosition;


	public Image rokeranGage;
	public Image attackButtonBack;
	public float countTime = 10;

	[System.NonSerialized] public bool rokeranGo = false;

	private int gyoren = 4;

	private Animator animator;



	// Opening
	void Awake(){
		// Characterの登場
		//for(int i=0;i<300;i++)playerController.transform.Translate(0.01f, 0, 0);
		//Instantiate(Enemy_SpacemanPrefab, new Vector2(10, 0), Quaternion.identity);
	}


	// Use this for initialization
	void Start () {
		animator = GameObject.Find("PlayerController/Player1Prefab").GetComponent<Animator>();		// GameManagerに移動
    StartCoroutine("BulletDanmaku_1");
    StartCoroutine("BulletDanmaku_2");
    StartCoroutine("BulletDanmaku_3");
		StartCoroutine("MeteorStorm");
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.N)){
			Instantiate(WeaponPrefab, new Vector3(10, Random.Range(-3.5f, 2.5f), 0), Quaternion.identity);
			Instantiate(RokeranPrefab, new Vector3(10, Random.Range(-3.5f, 2.5f), 0), Quaternion.identity);
		}
		if (Input.GetKeyDown (KeyCode.M)){
			Instantiate(tirashiBomPrefab, new Vector3(10, Random.Range(-3.5f, 2.5f), 0), Quaternion.identity);
		}

		// rokeranGageの
		rokeranGage.fillAmount += 1.0f / countTime * Time.deltaTime;
		if(rokeranGage.fillAmount == 1){
			 rokeranGo = true;
			 attackButtonBack.GetComponent<Image>().color = new Color(1,1,1,1);
		}


		/*
		// 魚雷(四連)のテスト	書き直す 後に4も5も他キーに統一
		if (Input.GetKeyDown (KeyCode.G)) {
			GyoraiAttack();
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			twitter.GetComponent<MoveTwiButton>().PushChangeTwiButton();
		} //*/
	}

	public void GyoraiAttack(){
		// GameManagerに移動
		// attackingAnimation
		//Debug.Log("GyoraiAttack");
		if(rokeranGo){
			animator.SetTrigger("attacking");
			playerPosition = playerController.transform.position;
			switch(gyoren){
				case 4:
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(15, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(5, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(-5, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(-15, new Vector3(0,0,1)));
					//Instantiate(bulletPrefab, new Vector3(playerPosition.x, playerPosition.y+0.3f, playerPosition.z), Quaternion.AngleAxis(15, new Vector3(0,0,1)));
					//Instantiate(bulletPrefab, new Vector3(playerPosition.x, playerPosition.y+0.1f, playerPosition.z), Quaternion.AngleAxis(5, new Vector3(0,0,1)));
					//Instantiate(bulletPrefab, new Vector3(playerPosition.x, playerPosition.y-0.1f, playerPosition.z), Quaternion.AngleAxis(-5, new Vector3(0,0,1)));
					//Instantiate(bulletPrefab, new Vector3(playerPosition.x, playerPosition.y-0.3f, playerPosition.z), Quaternion.AngleAxis(-15, new Vector3(0,0,1)));
					break;
				case 5:
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(15, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(7, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(0, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(-7, new Vector3(0,0,1)));
					Instantiate(bulletPrefab, playerPosition, Quaternion.AngleAxis(-15, new Vector3(0,0,1)));
					break;
			}
			rokeranGo = false;
			rokeranGage.fillAmount = 0;
	 		attackButtonBack.GetComponent<Image>().color = new Color(1,1,1,0.5f);
		}
	}


	public bool GetRokeranGO(){
		return rokeranGo;
	}



  private IEnumerator BulletDanmaku_1(){
		yield return new WaitForSeconds(3);
		while(true){
			yield return new WaitForSeconds(7);
			for(int i = 0; i < 4; i++){
    		yield return new WaitForSeconds(0.1f);
				playerPosition = playerController.transform.position;
				Instantiate(bulletDanmaku_1, playerPosition, Quaternion.identity);
  		}
		}
	}

  private IEnumerator BulletDanmaku_2(){
		yield return new WaitForSeconds(3);
		while(true){
			yield return new WaitForSeconds(5);
			for(int i = 0; i < 5; i++){
    		yield return new WaitForSeconds(0.05f);
				playerPosition = playerController.transform.position;
				Instantiate(bulletDanmaku_2, playerPosition, Quaternion.identity);
			}
		}
	}

  private IEnumerator BulletDanmaku_3(){
		yield return new WaitForSeconds(3);
		while(true){
			yield return new WaitForSeconds(3);
			for(int i = 0; i < 8; i++){
    		yield return new WaitForSeconds(0.05f);
				playerPosition = playerController.transform.position;
				Instantiate(bulletDanmaku_3, playerPosition, Quaternion.identity);
			}
		}
	}

	private IEnumerator MeteorStorm(){
		meteorStorm = GameObject.Find("Ef_MeteorStorm");
		meteorStorm.SetActive(false);
		while(true){
			//Debug.Log(meteorStorm);
			yield return new WaitForSeconds(Random.Range(15,30));
			//Instantiate(meteorStorm, new Vector2(0, 10), Quaternion.identity);
			meteorStorm.SetActive(true);
			yield return new WaitForSeconds(8);
			meteorStorm.SetActive(false);
		}
	}


}
