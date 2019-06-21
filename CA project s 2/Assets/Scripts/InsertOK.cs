using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsertOK : MonoBehaviour {


	public Button A_btn;
	public Button B_btn;
	public Button C_btn;
	public Button D_btn;

	public Button Okbtn;
	public GameObject already;

	public string S_ans;
	public string kind;

	string InsertOKURL = "http://54.191.78.109/collage_adventure/InsertOK.php";

	void Start () {
		Okbtn.onClick.AddListener (OKBtnOnclick);
		A_btn.onClick.AddListener (A_btnBtnOnclick);
		B_btn.onClick.AddListener (B_btnBtnOnclick);
		C_btn.onClick.AddListener (C_btnBtnOnclick);
		D_btn.onClick.AddListener (D_btnBtnOnclick);

		kind = PlayerPrefs.GetString ("kind");

		if(kind=="公告"){
			A_btn.transform.position = new Vector2 (-200.0f,-500.0f);
			B_btn.transform.position = new Vector2 (-200.0f,-500.0f);
			C_btn.transform.position = new Vector2 (-200.0f,-500.0f);
			D_btn.transform.position = new Vector2 (-200.0f,-500.0f);
		}
		else if(kind=="提問"){
			Okbtn.transform.position = new Vector2 (-200.0f,-500.0f);
		}
	}

	void Update () {
		
	}

	void A_btnBtnOnclick(){
		S_ans = A_btn.GetComponentInChildren<Text>().text;
		StartCoroutine(Ans());
	}

	void B_btnBtnOnclick(){
		S_ans = B_btn.GetComponentInChildren<Text>().text;
		StartCoroutine(Ans());
	}

	void C_btnBtnOnclick(){
		S_ans = C_btn.GetComponentInChildren<Text>().text;
		StartCoroutine(Ans());
	}

	void D_btnBtnOnclick(){
		S_ans = D_btn.GetComponentInChildren<Text>().text;
		StartCoroutine(Ans());
	}

	void OKBtnOnclick(){
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

		if (ansData.text == "Already answered.") {
			already.SetActive (true);
			yield return new WaitForSeconds (2);
			SceneManager.LoadScene ("questlist");
		}
		else {
			SceneManager.LoadScene ("questlist");
		}

	}
}
