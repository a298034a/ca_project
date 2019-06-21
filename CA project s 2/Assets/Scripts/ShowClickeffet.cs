using UnityEngine;
using System.Collections;

public class ShowClickeffet : MonoBehaviour {
	
	public GameObject copyeff;
	public GameObject canv;
	public GameObject childeff;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnMouseDown(){
		childeff = Instantiate (copyeff);
		childeff.transform.SetParent(canv.transform);
		childeff.transform.localPosition = Vector3.zero;
	}
}
