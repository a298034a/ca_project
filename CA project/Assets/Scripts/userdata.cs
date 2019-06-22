using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class userdata : MonoBehaviour {

	public GameObject NameText;
	public GameObject LvText;
	public GameObject ExpText;
	public GameObject bg;
	public GameObject black;
	public GameObject sta;

	public Button status_btn;
	public Button close_btn;

	string UserURL = "http://54.191.78.109/collage_adventure/userdata_t.php";

	IEnumerator Start () {
		WWWForm form = new WWWForm();
		form.AddField ("T_no", PlayerPrefs.GetString ("T_no"));

		WWW www = new WWW (UserURL, form);
		yield return www;
		Debug.Log(www.text);

		PlayerPrefs.SetString ("name",GetDataValue(www.text, "Name:"));
		PlayerPrefs.SetString ("lv",GetDataValue(www.text, "Lv:"));
		PlayerPrefs.SetString ("exp",GetDataValue(www.text, "exp:"));
	}

	void Update () {
		status_btn.onClick.AddListener (OnClickstatus);
		close_btn.onClick.AddListener (OnClickClose);
	}

	void OnClickstatus(){
		NameText.GetComponent<Text>().text = PlayerPrefs.GetString ("name");
		LvText.GetComponent<Text>().text = "LV:"+PlayerPrefs.GetString ("lv");
		ExpText.GetComponent<Text>().text = "Exp:"+PlayerPrefs.GetString ("exp");

		sta.SetActive (true);
	}

	void OnClickClose(){
		sta.SetActive (false);
	}

	string GetDataValue(string data, string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf("|"));
		if(value.Contains(";"))value = value.Remove (value.IndexOf(";"));
		return value;
	}
}
