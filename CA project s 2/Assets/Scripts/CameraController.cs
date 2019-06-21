using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;

	void Start () {
		moveSpeed=1.0f;
	}
		
	void Update () {
		targetPos = new Vector3 (0, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}

}
