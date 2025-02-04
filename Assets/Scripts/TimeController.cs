﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	public float time = 240;											//残り時間初期値
	Text text;


	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;											//毎フレームの時間を加算.
		int minute = (int)time/60;									//分.timeを60で割った値.
		int second = (int)time%60;									//秒.timeを60で割った余り.
		string minText, secText;										//テキスト形式の分・秒を用意.
		if (minute < 10)
				minText = "0" + minute.ToString();			//ToStringでint→stringに変換.
		else
				minText = minute.ToString();
		if (second < 10)
				secText = "0" + second.ToString();			//上に同じく.
		else
				secText = second.ToString();

		if (time < 0) time = 0;											//ゲームオーバーの処理

		text.text = minText + ":" + secText ;
	}
}
