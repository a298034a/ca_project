using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Getheart : MonoBehaviour {
	
	public GameObject gameover_txt;
	public GameObject player;
	public GameObject camer;

	public GetPlayerSelectSkin other;

	void OnTriggerEnter2D(Collider2D Coll)
	{
		other.life -= 1;

		if (other.life == 0) {
			gameover_txt.SetActive (true);
			player.GetComponent<Rigidbody2D> ().isKinematic = true;
			Destroy (camer.GetComponent<playercontroller_r> ());
			player.transform.position = player.transform.position;
		}
		else {
			for(int i=0; i<=10; i++){
				player.transform.position = new Vector2(player.transform.position.x,player.transform.position.y + 0.2f);
			}
		}

	}
}
