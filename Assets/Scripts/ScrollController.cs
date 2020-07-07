using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour {

	[SerializeField] private float speed = 1;							// 速度
	//[SerializeField] private float translate_x = 1;				// X方向に移動
	//[SerializeField] private float translate_y = 0;				// y方向に移動
	//[SerializeField] private float translate_z = 0;				// z方向に移動
	[SerializeField] private float rotate_X = 0;					// X軸回転
	[SerializeField] private float rotate_Y = 0;					// Y軸回転
	[SerializeField] private float rotate_Z = 0;					// Z軸回転

	//[SerializeField] private float first_Rotate_Y = 0;		// Y軸回転の初期値

	public Space space = Space.Self;		// 基準の座標

	// Use this for initialization
	void Start () {
		//transform.Rotate(0, first_Rotate_Y, 0);
		//transform.Rotate(0, -90, 0, Space.World);
		speed *= 0.1f;
	}

	// Update is called once per frame
	void Update () {
    //transform.Translate(translate_x * speed, translate_y * speed, translate_z * speed, space);
		transform.Translate(speed, 0, 0, space);
		transform.Rotate (rotate_X, rotate_Y, rotate_Z);
    if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y > 3.5f){
			Destroy(gameObject);
    }
	}
}
