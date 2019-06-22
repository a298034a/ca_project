using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class login : MonoBehaviour {

	private string inputAccount;
	private string inputPassword;

	public Button loginBtn;

	//string LoginURL = "caproject.webutu.com/login_t.php";
	string LoginURL = "http://54.191.78.109/collage_adventure/login_t.php";
	public bool go;

	void Start () {
		go = true;
	}

	void Update () {
		if(go == true){
			loginBtn.onClick.AddListener (loginBtnOnclick);
			go = false;
		}
	}

	IEnumerator LoginToDB(string account, string password){
		WWWForm form = new WWWForm();
		form.AddField ("usernamePost", account);
		form.AddField ("passwordPost", password);

		WWW www = new WWW (LoginURL, form);
		yield return www;
		Debug.Log(www.text);

		PlayerPrefs.SetString ("T_no",GetDataValue(www.text, "ID:"));
		PlayerPrefs.SetString ("name",GetDataValue(www.text, "Name:"));
		/*PlayerPrefs.SetString ("lv",GetDataValue(www.text, "Lv:"));
		PlayerPrefs.SetString ("exp",GetDataValue(www.text, "exp:"));*/

		SceneManager.LoadScene ("teacher");

	}

	string GetDataValue(string data, string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf("|"));
		if(value.Contains(";"))value = value.Remove (value.IndexOf(";"));
		return value;
	}

	void loginBtnOnclick(){
		
		inputAccount = GameObject.Find ("Canvas/InputAccount/AccountText").GetComponent<Text> ().text;
		inputPassword = GameObject.Find ("Canvas/InputPassword/PasswordText").GetComponent<Text> ().text;
		StartCoroutine (LoginToDB (inputAccount, inputPassword));

	}
}
