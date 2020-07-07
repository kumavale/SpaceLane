using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSupport : MonoBehaviour
{
    public Image imageObject;

    public Vector2 position;

    float area_X,area_Y;

    Vector2 image_Position;


    //AutoController autoController;

    //public PlayerController playerController;

    // Use this for initialization
    void Start()
    {
		  //autoController = GameObject.Find("PlayerController").GetComponent<AutoController>();
      int screen_WIDTH = Screen.width;
      int screen_HEIGHT = Screen.height;
      area_X = screen_WIDTH / 2 - 30;   //930
      //area_X = Mathf.Abs(autoController.xMin);
      //Debug.Log(area_X);
      area_Y = (screen_HEIGHT / 6) * 5;
      image_Position = imageObject.rectTransform.position;

      //playerController = playerController.GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            position = Input.mousePosition;
          //Debug.Log(position);
          if(position.x < area_X && position.y < area_Y){
            imageObject.GetComponent<Image>().color = new Color(1,1,1,1);
            //Debug.Log(("position x" + position.x + "y" + position.y + " buttonP x" + imageObject.rectTransform.position.x + "y" + imageObject.rectTransform.position.y));
            float dx = position.x - image_Position.x;
            float dy = position.y - image_Position.y;
            float rad = Mathf.Atan2(dy, dx);
            var angle = rad * Mathf.Rad2Deg;
            //Debug.Log("angle" + angle);
            var distance = Vector2.Distance(position, image_Position);
            //Debug.Log(distance);
            if (distance >= 62.5f)    //50
            {
                distance = 62.5f;
            }
            Vector2 nextPosition;
            nextPosition.x = Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
            nextPosition.y = Mathf.Sin(Mathf.Deg2Rad * angle) * distance;
            imageObject.rectTransform.localPosition = nextPosition;
            PlayerController.GetInstance().PlayerMove(angle, distance / 640); //512
          }
        }
        else
        {
          imageObject.rectTransform.localPosition = Vector2.zero;
          imageObject.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        }
    }
}
