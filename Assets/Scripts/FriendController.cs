using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FriendController : MonoBehaviour {

	// 速度
	public Vector2 speed = new Vector2(0.05f, 0.05f);

	// targetPlayer
	public GameObject targetPlayer;

	// ラジアン変数
	private float rad;

	// 現在位置を代入する為の変数
	private Vector2 Position;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Homing();
	}

	void Homing(){
		float dx = targetPlayer.transform.position.x - transform.position.x;
		float dy = targetPlayer.transform.position.y - transform.position.y;

		if(Mathf.Abs(dx) > 0.5f){
			rad = Mathf.Atan2(dy, dx);

			// 現在位置をPositionに代入
			Position = transform.position;

			// x += SPEED * cos(ラジアン)
			// y += SPEED * sin(ラジアン)
			// これで特定の方向へ向かって進んでいく。
			Position.x += speed.x * Mathf.Cos(rad);
			Position.y += speed.y * Mathf.Sin(rad);

			// 現在の位置に加算減算を行ったPositionを代入する
			transform.position = Position;
		}
	}
}
