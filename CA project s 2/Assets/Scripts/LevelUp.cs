using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {

	public int currentLevel;
	public int currentExp;

	string LeveluURL = "http://54.191.78.109/collage_adventure/LevelUp.php";
	public int[] toLevelup;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		currentLevel = int.Parse(PlayerPrefs.GetString ("lv"));
		currentExp = int.Parse(PlayerPrefs.GetString ("exp"));

		if(currentExp >= toLevelup[currentLevel]){
			currentLevel++;
			PlayerPrefs.SetString ("lv",currentLevel.ToString());
			StartCoroutine(LvUp ());
		}
	}

	IEnumerator LvUp(){
		WWWForm form = new WWWForm();
		form.AddField ("S_no", PlayerPrefs.GetString("S_no"));

		WWW LvUpData = new WWW (LeveluURL, form);
		yield return LvUpData;

		print ("lvup");
	}
}
