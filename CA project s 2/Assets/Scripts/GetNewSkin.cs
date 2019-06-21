using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GetNewSkin : MonoBehaviour {
	
	int [] array = new int[]{0,1};
	List<int>list = new List<int>();

	public Button moon_btn;
	public Button penguin_btn;

	public Button penguin_btn1;
	public Button penguin_btn2;
	public Button penguin_btn3;
	public Button penguin_btn4;
	public Button penguin_btn5;
	public Button penguin_btn6;

	public Sprite moon_sprite;
	public Sprite penguin_sprite;

	public Image gotskin;
	// Use this for initialization
	void Start () {
		gotskin = gameObject.GetComponent<Image> ();

		moon_btn.interactable = false;
		penguin_btn.interactable = false;

		penguin_btn1.interactable = false;
		penguin_btn2.interactable = false;
		penguin_btn3.interactable = false;
		penguin_btn4.interactable = false;
		penguin_btn5.interactable = false;
		penguin_btn6.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int GetUniqueRandom(bool reloadEmptyList){
		if(list.Count == 0 ){
			if(reloadEmptyList){
				list.AddRange(array); 
			}
			else{
				return -1;
			}
		}
		int rand = UnityEngine.Random.Range(0, list.Count-1);
		int value = list[rand];
		list.RemoveAt(rand);
		return value;
	}

	public void GetNewskin(){
		int i = GetUniqueRandom(true);
		if(i==0){

			moon_btn.interactable = true;
			gameObject.GetComponent<Image>().sprite = moon_sprite;
		}
		if(i==1){

			penguin_btn.interactable = true;
			gameObject.GetComponent<Image>().sprite = penguin_sprite;
		}

	}
}
