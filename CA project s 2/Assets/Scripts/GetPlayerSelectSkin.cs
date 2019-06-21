using UnityEngine;
using System.Collections;

public class GetPlayerSelectSkin : MonoBehaviour {

	public Sprite green_sprite;
	public Sprite moon_sprite;
	public Sprite penguin_sprite;

	public int life;

	// Use this for initialization
	void Start () {
		life = 1;

		if(PlayerPrefs.GetString("SelectSkin")=="Moon"){
			Moon ();
		}
		else if(PlayerPrefs.GetString("SelectSkin")=="Penguin"){
			Penguin ();
		}
		else{
			Green();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Green(){
		gameObject.GetComponent<SpriteRenderer>().sprite = green_sprite;
	}

	public void Moon(){
		gameObject.GetComponent<SpriteRenderer>().sprite = moon_sprite;
		life = 2;
	}

	public void Penguin(){
		gameObject.GetComponent<SpriteRenderer>().sprite = penguin_sprite;
		gameObject.GetComponent<Rigidbody2D> ().drag = 0;
		//gameObject.GetComponent<Rigidbody2D> ().angularDrag = 0.01f;
	}

}
