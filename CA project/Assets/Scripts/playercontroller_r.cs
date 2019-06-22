using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playercontroller_r : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;

	public GameObject player;
	public Button r_btn;
	public Button l_btn;

	void Start () {
		moveSpeed = 2.5f;
		myRigidbody = player.GetComponent<Rigidbody2D> ();
	}


	void Update () {
		r_btn.onClick.AddListener (R_OnClisk);
		l_btn.onClick.AddListener (L_OnClisk);
	}

	void R_OnClisk(){
		myRigidbody.velocity = new Vector2(0.7f  * moveSpeed, myRigidbody.velocity.y);
		myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.7f* moveSpeed);
	}

	void L_OnClisk(){
		myRigidbody.velocity = new Vector2(-0.7f  * moveSpeed, myRigidbody.velocity.y);
		myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.7f* moveSpeed);
	}
		
}
