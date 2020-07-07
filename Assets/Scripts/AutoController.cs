using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoController : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Vector3 targetPosition;

    public float xMax, xMin;
    private float yMax = 3, yMin = -3;

    string objectTag;


    GameObject gameManagerObject;
    GameManager gameManager;


    void Awake(){
      objectTag = this.transform.tag;
      int screen_WIDTH = Screen.width;
      int screen_HEIGHT = Screen.height;

      FixationArea(screen_WIDTH, screen_HEIGHT);
    }


    void Start()
    {
      //Debug.Log("AutoController");
      targetPosition = this.GetRandomPositionOnLevel();

      gameManagerObject = GameObject.Find("GameManager");
      if(this.transform.tag == "Player")
        gameManager = gameManagerObject.GetComponent<GameManager>();

    }

    void Update()
    {
      // 目標地点に到着したら、次のランダムな目標地点を設定する
      if (targetPosition == transform.position)
      {
          targetPosition = GetRandomPositionOnLevel();
      }

      // 前方に進む
			transform.position = Vector3.MoveTowards(transform.position, targetPosition , speed * 0.01f);


			//gameManager = GetComponent<GameManager>();

      if (gameManager) {   // Null Reference Exception回避
        if(gameManager.GetRokeranGO() == true){
          gameManager.GyoraiAttack();
        }
      } else{}
    }


    public Vector3 GetRandomPositionOnLevel()
    {
      float xMin_trick = Random.Range(xMin - 2, xMax);
      if(xMin_trick < xMin) xMin_trick = xMin;
      return new Vector3(xMin_trick, Random.Range(yMin, yMax), 0);
    }




    // ユークリッドの互除法を用いてaとbの最大公約数を求める
    public static int Gcd(int a, int b)
    {
      //Debug.Log("Gcd!!");
      if (a < b){
        return Gcd(b, a); // a >= bとなるように
      }
      while (b != 0){
        int temp = a % b;
        a = b;
        b = temp;
      }
      return a;
    }




    private void FixationArea(int _Width, int _Height) {

    // 320x200の時
    if (_Width == 320 && _Height == 200) {
        if (objectTag == "Player")   // Player
        {
            xMin = -7;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }

    // 320x240の時
    if (_Width == 320 && _Height == 240)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -5.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 400x300の時
    if (_Width == 400 && _Height == 300)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -6;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 512x384の時
    if (_Width == 512 && _Height == 384)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -6;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6.5f;
        }
    }

    // 640x400の時
    if (_Width == 640 && _Height == 400)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }

    // 640x480の時
    if (_Width == 640 && _Height == 480)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -5.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 800x600の時
    if (_Width == 640 && _Height == 480)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -5.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 1024x768の時
    if (_Width == 1024 && _Height == 768)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -6;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 1152x864の時
    if (_Width == 1152 && _Height == 864)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -5.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6.5f;
        }
    }

    // 1280x720の時
    if (_Width == 1280 && _Height == 720)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -8;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 8.5f;
        }
    }

    // 1280x768の時
    if (_Width == 1280 && _Height == 768)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 8;
        }
    }

    // 1280x800の時
    if (_Width == 1280 && _Height == 800)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }

    // 1280x960の時
    if (_Width == 1280 && _Height == 960)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -6;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 1280x1024の時
    if (_Width == 1280 && _Height == 1024)
    {
      //Debug.Log("1280x1024");
        if (objectTag == "Player")   // Player
        {
            xMin = -5.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6;
        }
    }

    // 1360x768の時
    if (_Width == 1360 && _Height == 768)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -8;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 8.5f;
        }
    }

    // 1366x768の時
    if (_Width == 1366 && _Height == 768)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -8;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 8.5f;
        }
    }

    // 1400x1050の時
    if (_Width == 1400 && _Height == 1050)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -5.5f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 6.5f;
        }
    }

    // 1440x900の時
    if (_Width == 1440 && _Height == 900)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }

    // 1600x900の時
    if (_Width == 1600 && _Height == 900)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -8;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 8.5f;
        }
    }

    // 1680x1050の時
    if (_Width == 1680 && _Height == 1050)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7.4f;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }

    // 1920x1080の時
    if (_Width == 1920 && _Height == 1080)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }

    // 1920x1200の時
    if (_Width == 1920 && _Height == 1200)
    {
        if (objectTag == "Player")   // Player
        {
            xMin = -7;
            xMax = 2;
        }
        else    // Enemy
        {
            xMin = 3;
            xMax = 7.5f;
        }
    }
  }
}
