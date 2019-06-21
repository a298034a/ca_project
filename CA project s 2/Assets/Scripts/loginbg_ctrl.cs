using UnityEngine;
using System.Collections;

public class loginbg_ctrl : MonoBehaviour {
	
	private Animator ani;
	private bool go;

	void Start () {
		ani = GetComponent<Animator> ();
	}
	

	void Update () {
		if (!GameObject.Find ("Canvas/PressStartBtn")) {
			go = true;
			ani.SetBool ("go",go);
		}
	}
}
