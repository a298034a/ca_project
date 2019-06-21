using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ListBoardCtrl : MonoBehaviour {
	
	public Sprite Anno_sprite;
	public Sprite test_sprite;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("kind") == "公告") {
			gameObject.GetComponent<Image> ().sprite = Anno_sprite;
		}
		else if (PlayerPrefs.GetString ("kind") == "提問") {
			gameObject.GetComponent<Image> ().sprite = test_sprite;
		}
	}

}
