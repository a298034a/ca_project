using UnityEngine;
using System.Collections;

public class CameraStartMove : MonoBehaviour {

	public GameObject player;
	public GameObject camer;

	void OnTriggerEnter2D(Collider2D Coll)
	{
		camer.GetComponent<CameraController> ().enabled =true;
	}
}
