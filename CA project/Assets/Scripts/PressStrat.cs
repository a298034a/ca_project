using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressStrat : MonoBehaviour {

	public GameObject inacc;
	public GameObject inpass;
	public GameObject logbtn;

	public Button starbtn;

	void Start () {

		starbtn.onClick.AddListener (OnClickPress);

		inacc.transform.position = new Vector2 (-500.0f,-500.0f);
		inpass.transform.position = new Vector2 (-500.0f,-500.0f);
		logbtn.transform.position = new Vector2 (-500.0f,-500.0f);
	}

	void Update () {
	
	}

	void OnClickPress(){

		inacc.transform.position = new Vector2 (540.0f,850.0f);
		inpass.transform.position = new Vector2 (540.0f,748.3f);
		logbtn.transform.position = new Vector2 (540.0f,646.7f);

		Destroy (this.gameObject);
	}
}
