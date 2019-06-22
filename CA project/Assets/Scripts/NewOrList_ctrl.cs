using UnityEngine;
using System.Collections;

public class NewOrList_ctrl : MonoBehaviour {

	public GameObject list_UI;
	public GameObject listbtn;
	public GameObject sinbtn;
	
	// Use this for initialization
	void Start () {
		listbtn.SetActive (false);
	}
	
	public void newbtnOnclick(){
		list_UI.SetActive (false);
		sinbtn.SetActive (false);
		listbtn.SetActive (true);
	}

	public void listbtnOnclick(){
		list_UI.SetActive (true);
		sinbtn.SetActive (true);
		listbtn.SetActive (false);
	}
}
