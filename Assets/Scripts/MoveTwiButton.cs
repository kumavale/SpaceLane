using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTwiButton : MonoBehaviour {

	//[SerializeField] private Button ChangeTwiButton;

	public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
	public Vector2 inPosition;        // スライドイン後の位置
	public Vector2 outPosition;      // スライドアウト後の位置
	public float duration = 1.0f;    // スライド時間（秒）

	private GameObject attackButtonObject;
	private AutoButtonController autoButtonController;

	private bool autoNow;

	[System.NonSerialized] public bool flg = true;


	// Use this for initialization
	void Start () {
		attackButtonObject = GameObject.Find("CanvasUI/AttackButtonObject");
		autoButtonController = GameObject.Find("CanvasUI/AutoButtonObject/AutoButton")
																.GetComponent<AutoButtonController>();
		//Debug.Log("MoveTwiButton:読み込みました");
	}

	// Update is called once per frame
	void Update () {

	}

	public void PushChangeTwiButton(){
		if(autoButtonController.markMove){
			StartCoroutine(StartSlideTwiPanel(flg));
			attackButtonObject.SetActive(!flg);
			flg = !flg;
		}
	}


	private IEnumerator StartSlideTwiPanel( bool isSlideIn ){
    float startTime = Time.time;    // 開始時間
    Vector2 startPos = transform.localPosition;  // 開始位置
    Vector2 moveDistance;            // 移動距離および方向

    if( isSlideIn ){
      moveDistance = (inPosition - startPos);
    }else{
      moveDistance = (outPosition - startPos);
		}

    while((Time.time - startTime) < duration){
      transform.localPosition
				= startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
       yield return 0;        // 1フレーム後、再開
    }
    transform.localPosition = startPos + moveDistance;
		//Debug.Log(flg);
  }
}
