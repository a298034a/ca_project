using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainRollCall : MonoBehaviour {

	public Sprite btnglow;
	public Sprite btndark;

	public string S_ans;

	string ListURL = "http://54.191.78.109/collage_adventure/ShowAnnounce_s.php";
	string deletURL = "http://54.191.78.109/collage_adventure/Datetime_compare.php";
	string InsertOKURL = "http://54.191.78.109/collage_adventure/InsertOK.php";

	// Use this for initialization
	void Start () {

		StartCoroutine(RollCallSearch());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RollCallSearch () {

		for(int i = 0; i < 5; i++){
			WWW CompareData = new WWW (deletURL);
			yield return CompareData;
		}

		WWWForm form = new WWWForm();
		form.AddField ("kind", "點名");
		form.AddField ("S_no", PlayerPrefs.GetString("S_no"));

		WWW AnnoData = new WWW (ListURL,form);
		yield return AnnoData;
		string AnnoDataString = AnnoData.text;
		print (AnnoDataString);

		if (AnnoDataString != null) {
			gameObject.GetComponent<Image> ().sprite = btnglow;
		}
		else {
			gameObject.GetComponent<Image> ().sprite = btndark;
		}
	}

	public void OKBtnOnclick(){
		S_ans = "OK";
		StartCoroutine(Ans());
	}

	IEnumerator Ans(){
		WWWForm form = new WWWForm();
		form.AddField ("Q_no", PlayerPrefs.GetString("Q_no"));
		form.AddField ("S_no", PlayerPrefs.GetString("S_no"));
		form.AddField ("S_ans", S_ans);

		WWW ansData = new WWW (InsertOKURL,form);
		yield return ansData;

		gameObject.GetComponent<Image> ().sprite = btndark;
	}
}