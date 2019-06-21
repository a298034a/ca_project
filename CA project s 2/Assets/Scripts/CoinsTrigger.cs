using UnityEngine;
using System.Collections;

public class CoinsTrigger : MonoBehaviour {

	public GameObject player;
	string GetMoneyURL = "http://54.191.78.109/collage_adventure/GetMoney.php";

	void OnTriggerEnter2D(Collider2D Coll)
	{
		Destroy(gameObject);
		StartCoroutine(GetCoins ());
	}

	IEnumerator GetCoins(){
		WWWForm form = new WWWForm ();
		form.AddField ("S_no", PlayerPrefs.GetString ("S_no"));

		WWW Gotit = new WWW (GetMoneyURL,form);
		yield return Gotit;
	}
}
