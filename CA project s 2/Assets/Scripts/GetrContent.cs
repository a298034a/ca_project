using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetrContent : MonoBehaviour {

	public GameObject title;
	public GameObject teacher;
	public GameObject limit;
	public GameObject con;

	public Button A_btn;
	public Button B_btn;
	public Button C_btn;
	public Button D_btn;

	public string kind;

	public string[] Cons;
	string ConURL = "http://54.191.78.109/collage_adventure/ShowContent.php";

	IEnumerator Start () {
		kind = PlayerPrefs.GetString ("kind");
		print (kind);

		if(kind=="公告" || kind=="點名"){
			A_btn.transform.position = new Vector2 (-200.0f,-500.0f);
			B_btn.transform.position = new Vector2 (-200.0f,-500.0f);
			C_btn.transform.position = new Vector2 (-200.0f,-500.0f);
			D_btn.transform.position = new Vector2 (-200.0f,-500.0f);
		}

		WWWForm form = new WWWForm();
		form.AddField ("No", PlayerPrefs.GetString("Q_no"));

		WWW ConData = new WWW (ConURL,form);
		yield return ConData;
		string ConDataString = ConData.text;
		//print (ConDataString);

		Cons = ConDataString.Split(';');
		title.GetComponent<Text> ().text = GetDataValue(Cons[0], "CT_title:");
		teacher.GetComponent<Text> ().text = teacher.GetComponent<Text> ().text + GetDataValue(Cons[0], "T_name:");
		limit.GetComponent<Text> ().text = limit.GetComponent<Text> ().text + GetDataValue(Cons[0], "time_limit:");
		con.GetComponent<Text> ().text = GetDataValue(Cons[0], "content:");

		A_btn.GetComponentInChildren<Text>().text = GetDataValue(Cons[0], "ans_a:");
		B_btn.GetComponentInChildren<Text>().text = GetDataValue(Cons[0], "ans_b:");
		C_btn.GetComponentInChildren<Text>().text = GetDataValue(Cons[0], "ans_c:");
		D_btn.GetComponentInChildren<Text>().text = GetDataValue(Cons[0], "ans_d:");

	}

	string GetDataValue(string data, string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf("|"));
		return value;
	}
}
