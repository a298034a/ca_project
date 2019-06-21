using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageUnlock : MonoBehaviour {

	public Button stage1_2;
	public Button stage1_3;
	public Button stage1_4;
	// Use this for initialization
	void Start () {
		stage1_3.interactable = false;
		stage1_4.interactable = false;
	}
	

}
