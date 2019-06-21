using UnityEngine;
using System.Collections;

public class Getkind : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void OnclickKind(string kind){

		PlayerPrefs.SetString ("kind",kind);
	}

}
