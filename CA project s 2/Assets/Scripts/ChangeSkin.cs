using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour {

	public Sprite green_sprite;
	public Sprite moon_sprite;
	public Sprite penguin_sprite;

	public Text skinName;
	public Text skinIntod;

	public GameObject skinlist;

	public bool change;

	// Use this for initialization
	void Start () {

		if(PlayerPrefs.GetString("SelectSkin")=="Moon"){
			MoonBtnOnClick ();
		}
		else if(PlayerPrefs.GetString("SelectSkin")=="Penguin"){
			PenguinBtnOnClick ();
		}
		else{
			GreenBtnOnClick();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetString("SelectSkin")=="Moon"){
			gameObject.GetComponent<Image>().sprite = moon_sprite;
		}
		else if(PlayerPrefs.GetString("SelectSkin")=="Penguin"){
			gameObject.GetComponent<Image>().sprite = penguin_sprite;
		}
		else{
			gameObject.GetComponent<Image>().sprite = green_sprite;
		}
	}

	public void GreenBtnOnClick(){
		gameObject.GetComponent<Image>().sprite = green_sprite;
		PlayerPrefs.SetString ("SelectSkin","Green");
		skinName.GetComponent<Text> ().text = "基礎飛行器";
		skinIntod.GetComponent<Text> ().text = "蜂鳥送給我的第一個飛行器，據說托巴斯的孩子們都用它當玩具。";
	}

	public void MoonBtnOnClick(){
		gameObject.GetComponent<Image>().sprite = moon_sprite;
		PlayerPrefs.SetString ("SelectSkin","Moon");
		skinName.GetComponent<Text> ().text = "月亮";
		skinIntod.GetComponent<Text> ().text = "比一般飛行器堅固，可以抵禦一次傷害。";
	}

	public void PenguinBtnOnClick(){
		gameObject.GetComponent<Image>().sprite = penguin_sprite;
		PlayerPrefs.SetString ("SelectSkin","Penguin");
		skinName.GetComponent<Text> ().text = "企鵝冰塊";
		skinIntod.GetComponent<Text> ().text = "摸起來滑滑的，感覺隨時會溜走。摩擦力較低。";
	}


	public void ChangeOnClick(){
		skinlist.SetActive (true);
	}

	public void CloseSkinOnClick(){
		gameObject.transform.parent.gameObject.SetActive (false);
	}
}
