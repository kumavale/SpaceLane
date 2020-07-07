using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour {

	public GameObject twitterSetting;

	bool flg = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void PushSettingButton(){
    //CameraFade.StartAlphaFade(Color.black, false, 0.5f, 0.5f, () => { SceneManager.LoadScene("Setting"); });
    SceneManager.LoadScene("Setting");
	}

	public void PushEndButton(){
		Application.Quit();
	}

	public void ChangeMainSceneButton(){
		SceneManager.LoadScene("Main");
	}

	public void PushTwiSettingButton(){
		twitterSetting.SetActive(flg);
		flg = !flg;
	}

}
