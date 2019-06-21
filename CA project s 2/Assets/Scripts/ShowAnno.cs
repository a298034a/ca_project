using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class ShowAnno : MonoBehaviour {

	int btnquantity;
	int questquantity;
	public GameObject copybtn;
	public GameObject grid;
	public GameObject childbtn;

	public string kind;

	public string[] Anno;

	string ListURL = "http://54.191.78.109/collage_adventure/ShowAnnounce_s.php";

	string deletURL = "http://54.191.78.109/collage_adventure/Datetime_compare.php";

	void Start () {
		kind = PlayerPrefs.GetString("kind");
		print (kind);
		StartCoroutine(questsearch());
	}

	void Update () {

	}

	string GetDataValue(string data, string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf("|"));
		return value;
	}

	IEnumerator questsearch () {
		for(int i = 0; i < 5; i++){
			WWW CompareData = new WWW (deletURL);
			yield return CompareData;
		}

		WWWForm form = new WWWForm();
		form.AddField ("kind", kind);
		form.AddField ("S_no", PlayerPrefs.GetString("S_no"));

		WWW AnnoData = new WWW (ListURL,form);
		yield return AnnoData;
		string AnnoDataString = AnnoData.text;
		print (AnnoDataString);
		Anno = AnnoDataString.Split(';');
		print(GetDataValue(Anno[0], "CT_title:"));
		for(int i = 0;i<grid.transform.childCount;i++){
			GameObject go = grid.transform.GetChild(i).gameObject;
			Destroy(go);
		}
		print (Anno.Length);
		for(btnquantity = 0 ; btnquantity < Anno.Length-1; btnquantity++){

			childbtn = Instantiate (copybtn);

			childbtn.transform.SetParent(grid.transform);
			childbtn.transform.localPosition = Vector3.zero;
			childbtn.transform.localScale = new Vector2 (1.0f,1.0f);
			childbtn.name = "Button" + btnquantity;
			childbtn.GetComponentInChildren<Text>().text = "【"+ GetDataValue(Anno[btnquantity], "CT_title:") +"】" + GetDataValue(Anno[btnquantity], "content:").Substring(0,5) + "...";
			childbtn.transform.Find("q_no").GetComponent<Text>().text = GetDataValue(Anno[btnquantity], "Q_no:");
		}

	}

}
