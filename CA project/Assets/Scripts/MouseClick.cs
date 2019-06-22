using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {
	
	public float Distance = 10;
	private Animator ani;
	private bool mclick;

	void Start () {
		ani = GetComponent<Animator> ();
	}

	void Update(){
		Ray effect_ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 pos = effect_ray.GetPoint (Distance);
		transform.position = pos;
	}

	void OnMouseDown(){
		mclick = true;
		ani.SetBool ("mclick",mclick);
	}

	void OnMouseUp(){
		mclick = false;
		ani.SetBool ("mclick",mclick);
	}
}
