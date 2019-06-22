using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public void ChangeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void Setkind(string kind){
		PlayerPrefs.SetString ("kind",kind);
	}
}
