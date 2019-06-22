using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalTrigger : MonoBehaviour {

	public Text fin;
	public GameObject player;
	public GameObject camer;

	void OnTriggerEnter2D(Collider2D Coll)
	{
		fin.GetComponent<Text> ().text = "Finish!";
		player.GetComponent<Rigidbody2D>().isKinematic = true;
		Destroy(camer.GetComponent<playercontroller_r> ());
		player.transform.position = player.transform.position;
	}
}
