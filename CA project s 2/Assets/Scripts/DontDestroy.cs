using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public GameObject donde;

	void Start () {
		DontDestroyOnLoad (donde);
	}

	void Update () {
	
	}
}
