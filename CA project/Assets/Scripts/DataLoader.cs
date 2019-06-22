using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {

	public string[] users;

	IEnumerator Start () {
		WWW UserData = new WWW ("http://54.191.78.109/collage_adventure/member.php");
		yield return UserData;
		string UserDataString = UserData.text;
		print (UserDataString);
		users = UserDataString.Split(';');
		print(GetDataValue(users[0], "Name:"));
	}

	string GetDataValue(string data, string index){
		string value = data.Substring (data.IndexOf (index) + index.Length);
		if(value.Contains("|"))value = value.Remove (value.IndexOf("|"));
		return value;
	}

}
