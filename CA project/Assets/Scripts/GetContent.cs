using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetContent : MonoBehaviour {

	public GameObject title;
	//public GameObject teacher;
	public GameObject limit;
	public GameObject con;

	public GameObject copytxt;
	public GameObject grid;
	public GameObject childtxt;

	public string[] Cons;
	string ConURL = "http://54.191.78.109/collage_adventure/ShowContent_t.php";

	public string[] Ans;
	string AnsURL = "http://54.191.78.109/collage_adventure/ShowStudentAns.php";

	int ansquantity;

	IEnumerator Start () {
		WWWForm form = new WWWForm();
		form.AddField ("No", PlayerPrefs.GetString("Q_no"));

		WWW ConData = new WWW (ConURL,form);
		yield return ConData;
		string ConDataString = ConData.text;

		Cons = ConDataString.Split(';');
		title.GetComponent<Text> ().text = GetDataValue(Cons[0], "CT_title:");
		//teacher.GetComponent<Text> ().text = teacher.GetComponent<Text> ().text + GetDataValue(Cons[0], "T_name:");
		limit.GetComponent<Text> ().text = limit.GetComponent<Text> ().text + GetDataValue(Cons[0], "time_limit:");
		con.GetComponent<Text> ().text = GetDataValue(Cons[0], "content:");

		//---------------------------------------------

		form.AddField ("Q_no", PlayerPrefs.GetString("Q_no"));
		WWW AnsData = new WWW (AnsURL,form);
		yield return AnsData;
		Debug.Log (AnsData.text);

		Ans = AnsData.text.Split(';');
		for(ansquantity = 0 ; ansquantity < Ans.Length-1; ansquantity++){
			childtxt = Instantiate (copytxt);

			childtxt.transform.SetParent(grid.transform);
			childtxt.transform.localPosition = Vector3.zero;
			childtxt.transform.localScale = new Vector2(1.0f,1.0f);
			childtxt.name = "ans" + ansquantity;
			childtxt.GetComponent<Text>().text = GetDataValue(Ans[ansquantity], "S_name:") + "  " + GetDataValue(Ans[ansquantity], "S_ans:");
		}

	}

	string GetDataValue(string data, string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf("|"));
		return value;
	}
}
