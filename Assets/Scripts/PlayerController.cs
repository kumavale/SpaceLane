using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

  private static PlayerController _playerController;

  AutoController autoController;

  float MinX, MaxX;
  const float MinY = -3, MaxY = 3;

  float speed = 0.1f;
  int startMove = 0;


	public GameObject moveSupport;
	//MoveSupport mS;

	// Use this for initialization
	void Start () {
		_playerController = this;
		autoController = this.GetComponent<AutoController>();

    MinX = autoController.xMin;
    MaxX = autoController.xMax;

    //Debug.Log("MinX:"+MinX+"\nMaxX:"+MaxX);
	}

	// Update is called once per frame
	void Update () {
    if(startMove < 100){
      transform.Translate(0.05f, 0, 0);
      startMove++;
    }

  		// Playerの移動
      //float speed = 50.0f / 512;
			if(Input.anyKey){
	      if(Input.GetKey(KeyCode.W))
	      {
	          PlayerMove(90, speed);
						//mS.position = new Vector2(200, 212.5f);
	      }
	      if (Input.GetKey(KeyCode.D))
	      {
	          PlayerMove(0, speed);
						//mS.position = new Vector2(262.5f, 150);
	      }
	      if (Input.GetKey(KeyCode.A))
	      {
	          PlayerMove(180, speed);
						//mS.position = new Vector2(135.5f, 150);
	      }
	      if (Input.GetKey(KeyCode.S))
	      {
	          PlayerMove(270, speed);
						//mS.position = new Vector2(200, 87.5f);
	      }
			}
	}

  public static PlayerController GetInstance()
  {
      return _playerController;
  }


	// Playerの移動
	public void PlayerMove(float angle, float distance){
		/*
    var x = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
    var y = Input.GetAxis("Vertical") * Time.deltaTime * ySpeed;
    transform.Translate(x, y, 0); //*/

      Vector3 nextPosition = transform.localPosition;
      nextPosition.x += Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
      nextPosition.y += Mathf.Sin(Mathf.Deg2Rad * angle) * distance;

      if (nextPosition.x <= MinX)
      {
          nextPosition.x = MinX;
      }
      else
      if (nextPosition.x >= MaxX)
      {
          nextPosition.x = MaxX;
      }
      if (nextPosition.y <= MinY)
      {
          nextPosition.y = MinY;
      }
      else
      if (nextPosition.y >= MaxY)
      {
          nextPosition.y = MaxY;
      }
      transform.localPosition = nextPosition;
	}
}
