using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NewQuest : MonoBehaviour {

	private string inputClass;
	private string inputKind;
	private string inputYear;
	private string inputMonth;
	private string inputDate;
	private string inputHour;
	private string inputMin;
	private string inputContent;
	private string limit;

	private string a;
	private string b;
	private string c;
	private string d;

	public Toggle t_a;
	public Toggle t_b;
	public Toggle t_c;
	public Toggle t_d;
	private string cor;

	string InsertQuestURL = "http://54.191.78.109/collage_adventure/InsertQuest.php";

	void Start () {

	}

	void Update () {
		
		inputKind =  GameObject.Find ("Canvas/KindDropdown/Label").GetComponent<Text> ().text;

		if (inputKind == "公告" || inputKind == "提問") {
			inputClass = GameObject.Find ("Canvas/ClassDropdown/Label").GetComponent<Text> ().text;
			inputKind =  GameObject.Find ("Canvas/KindDropdown/Label").GetComponent<Text> ().text;
			inputYear =  GameObject.Find ("Canvas/YearDropdown/Label").GetComponent<Text> ().text;
			inputMonth =  GameObject.Find ("Canvas/MonthDropdown/Label").GetComponent<Text> ().text;
			inputDate =  GameObject.Find ("Canvas/DateDropdown/Label").GetComponent<Text> ().text;
			inputHour =  GameObject.Find ("Canvas/HourDropdown/Label").GetComponent<Text> ().text;
			inputMin =  GameObject.Find ("Canvas/MinDropdown/Label").GetComponent<Text> ().text;
			inputContent =  GameObject.Find ("Canvas/InputContent/ContentText").GetComponent<Text> ().text;

			if (inputMonth.Length == 1) {
				inputMonth = "0" + inputMonth;
			}
			if (inputDate.Length == 1) {
				inputDate = "0" + inputDate;
			}
			if (inputHour.Length == 1) {
				inputHour = "0" + inputHour;
			}
			if (inputMin.Length == 1) {
				inputMin = "0" + inputMin;
			}
		}

		if(inputKind=="點名"){
			inputClass = GameObject.Find ("Canvas/ClassDropdown/Label").GetComponent<Text> ().text;
			inputKind =  GameObject.Find ("Canvas/KindDropdown/Label").GetComponent<Text> ().text;
			inputYear = DateTime.Now.Year.ToString ();
			inputMonth = DateTime.Now.Month.ToString ();
			inputDate = DateTime.Now.Day.ToString ();
			inputHour = DateTime.Now.Hour.ToString ();
			inputMin = (int.Parse (DateTime.Now.Minute.ToString ())+5).ToString();
			inputContent = "請盡速簽到";

			if(int.Parse (inputMin)>=60){
				inputHour =(int.Parse (inputHour)+1).ToString();
				inputMin = (int.Parse (DateTime.Now.Minute.ToString ())-60).ToString();
			}

			//print (inputMin);
		}

		limit = inputYear+"-"+inputMonth+"-"+inputDate+" "+inputHour+":"+inputMin+":00";
		//print (limit);

	}

	IEnumerator createAnnouncement_a(){
		WWWForm form = new WWWForm();
		form.AddField ("T_no", PlayerPrefs.GetString ("T_no"));
		form.AddField ("choosingClass", inputClass);
		form.AddField ("choosingKind", inputKind);
		form.AddField ("contentPost", inputContent);
		form.AddField ("correctAns", "OK");
		form.AddField ("ansA", "OK");
		form.AddField ("timeLimit", limit);

		WWW www = new WWW (InsertQuestURL, form);
		yield return www;
		Debug.Log(www.text);

		SceneManager.LoadScene ("teacher");

	}

	IEnumerator createAnnouncement_t(){
		a = GameObject.Find ("Canvas/Input_A/Text").GetComponent<Text> ().text;
		b = GameObject.Find ("Canvas/Input_B/Text").GetComponent<Text> ().text;
		c = GameObject.Find ("Canvas/Input_C/Text").GetComponent<Text> ().text;
		d = GameObject.Find ("Canvas/Input_D/Text").GetComponent<Text> ().text;

		if(t_a.isOn){
			cor = a;
		}
		if(t_b.isOn){
			cor = b;
		}
		if(t_c.isOn){
			cor = c;
		}
		if(t_d.isOn){
			cor = d;
		}

		WWWForm form = new WWWForm();
		form.AddField ("T_no", PlayerPrefs.GetString ("T_no"));
		form.AddField ("choosingClass", inputClass);
		form.AddField ("choosingKind", inputKind);
		form.AddField ("contentPost", inputContent);
		form.AddField ("correctAns", cor);
		form.AddField ("ansA", a);
		form.AddField ("ansB", b);
		form.AddField ("ansC", c);
		form.AddField ("ansD", d);

		form.AddField ("timeLimit", limit);

		WWW www = new WWW (InsertQuestURL, form);
		yield return www;
		Debug.Log(www.text);

		SceneManager.LoadScene ("teacher");

	}

	public void OkBtnOnclick(){
		print ("click");
		if(inputKind=="公告" || inputKind=="點名"){
			StartCoroutine (createAnnouncement_a());
		}

		if(inputKind=="提問"){
			StartCoroutine (createAnnouncement_t());
		}
	}
}
