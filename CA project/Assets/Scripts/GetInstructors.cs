using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetInstructors : MonoBehaviour {
	
	public string[] classes;
	public Dropdown ClassDpn;

	public GameObject questkind;
	public GameObject A;
	public GameObject B;
	public GameObject C;
	public GameObject D;

	public GameObject tog;

	public GameObject okbtn;
	public GameObject backbtn;
	public GameObject con;
	public GameObject con_t;

	public GameObject y_dp;
	public GameObject mon_dp;
	public GameObject d_dp;
	public GameObject h_dp;
	public GameObject min_dp;

	public bool anno;
	public bool test;
	public bool rollcall;

	string GIURL = "http://54.191.78.109/collage_adventure/GetInstructors.php";

	IEnumerator Start () {

		A.SetActive (false);
		B.SetActive (false);
		C.SetActive (false);
		D.SetActive (false);
		tog.SetActive (false);

		anno = false;
		test = true;
		rollcall = true;

		string TeacherNum = PlayerPrefs.GetString ("T_no");

		WWWForm form = new WWWForm();
		form.AddField ("T_no", TeacherNum);

		WWW ClassTitle = new WWW (GIURL,form);
		yield return ClassTitle;
		string ClassTitleString = ClassTitle.text;
		print (ClassTitleString);

		classes = ClassTitleString.Split(';');
		ClassDpn.ClearOptions();

		for(int i=0; i<classes.Length; i+=1){
			ClassDpn.options.Add (new Dropdown.OptionData(classes[i]));
		}

		ClassDpn.value = 1;

		questkind.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString("kind");
	}

	void Update(){
		
		if(questkind.GetComponentInChildren<Text> ().text=="提問" && test == true){
			A.SetActive (true);
			B.SetActive (true);
			C.SetActive (true);
			D.SetActive (true);
			tog.SetActive (true);

			y_dp.transform.position = new Vector2 (254.0f , 1410.0f);
			mon_dp.transform.position = new Vector2 (445.0f , 1410.0f);
			d_dp.transform.position = new Vector2 (632.0f , 1410.0f);
			h_dp.transform.position = new Vector2 (254.0f , 1310.0f);
			min_dp.transform.position = new Vector2 (445.0f , 1310.0f);

			con.transform.position = new Vector2 (540.0f , 943.0f);
			con_t.transform.position = new Vector2 (240.0f , 1226.0f);
			okbtn.transform.position = new Vector2 (357.0f , 150.0f);
			backbtn.transform.position = new Vector2 (711.0f , 150.0f);

			test = false;
			anno = true;
			rollcall = true;
		}

		if(questkind.GetComponentInChildren<Text> ().text=="公告" && anno == true){
			A.SetActive (false);
			B.SetActive (false);
			C.SetActive (false);
			D.SetActive (false);
			tog.SetActive (false);

			y_dp.transform.position = new Vector2 (254.0f , 1459.0f);
			mon_dp.transform.position = new Vector2 (445.0f , 1459.0f);
			d_dp.transform.position = new Vector2 (632.0f , 1459.0f);
			h_dp.transform.position = new Vector2 (254.0f , 1357.0f);
			min_dp.transform.position = new Vector2 (445.0f , 1357.0f);

			con.transform.position = new Vector2 (540.0f , 943.0f);
			con_t.transform.position = new Vector2 (240.0f , 1226.0f);
			okbtn.transform.position = new Vector2 (357.0f , 589.0f);
			backbtn.transform.position = new Vector2 (711.0f , 589.0f);

			test = true;
			anno = false;
			rollcall = true;
		}
			
		if(questkind.GetComponentInChildren<Text> ().text=="點名" && rollcall == true){
			A.SetActive (false);
			B.SetActive (false);
			C.SetActive (false);
			D.SetActive (false);
			tog.SetActive (false);

			y_dp.transform.position = new Vector2 (254.0f , -1459.0f);
			mon_dp.transform.position = new Vector2 (445.0f , -1459.0f);
			d_dp.transform.position = new Vector2 (632.0f , -1459.0f);
			h_dp.transform.position = new Vector2 (254.0f , -1357.0f);
			min_dp.transform.position = new Vector2 (445.0f , -1357.0f);

			con.transform.position = new Vector2 (540.0f , -943.0f);
			con_t.transform.position = new Vector2 (240.0f , -1226.0f);
			okbtn.transform.position = new Vector2 (357.0f , 1189.0f);
			backbtn.transform.position = new Vector2 (711.0f , 1189.0f);

			test = true;
			anno = true;
			rollcall = false;

		}

	}

}
