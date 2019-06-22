using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowQusetContent : MonoBehaviour{

	public void BtnOnclick(string sceneName){
		PlayerPrefs.SetString ("Q_no",this.gameObject.transform.FindChild ("q_no").GetComponent<Text> ().text);
		SceneManager.LoadScene (sceneName);
	}
}
