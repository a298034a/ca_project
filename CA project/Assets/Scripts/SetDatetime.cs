using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetDatetime : MonoBehaviour {

	public Dropdown YDpn;
	public Dropdown MDpn;
	public Dropdown DDpn;
	public Dropdown HDpn;
	public Dropdown MinDpn;

	public bool Lit;
	public bool Feb;
	public bool Big;
	public bool Leap;

	void Start () {
		
		Lit = true;
		Feb = true;
		Big = true;
		Leap = true;

		HDpn.ClearOptions();
		for (int i = 0; i <= 23; i += 1) {
			HDpn.options.Add (new Dropdown.OptionData (i.ToString ()));
		}
		HDpn.value = 1;

		MinDpn.ClearOptions ();
		for (int i = 0; i <= 59; i += 1) {
			MinDpn.options.Add (new Dropdown.OptionData (i.ToString ()));
		}
		MinDpn.value = 1;

	}
		
	void Update () {
		//leapyear
		int ydata = int.Parse(YDpn.options[YDpn.value].text);
		int mdata = int.Parse (MDpn.options[MDpn.value].text);

		if (ydata % 4 == 0 && mdata == 2 && Feb == true && Leap == true) {
			Leap = false;
			Big = true;
			Lit = true;
			Feb = false;

			DDpn.ClearOptions();
			for (int i = 1; i <= 29; i += 1) {
				DDpn.options.Add (new Dropdown.OptionData (i.ToString ()));

			}
		}
		//February
		else if (mdata == 2 && Feb == true) {
			Leap = true;
			Lit = true;
			Feb = false;
			Big = true;

			DDpn.ClearOptions();
			for (int i = 1; i <= 28; i += 1) {
				DDpn.options.Add (new Dropdown.OptionData (i.ToString ()));
			}

		} else if ((mdata == 1 || mdata == 3 || mdata == 5 || mdata == 7 || mdata == 8 || mdata == 10 || mdata == 12) && Big == true) {
			Leap = true;
			Lit = true;
			Feb = true;
			Big = false;

			DDpn.ClearOptions();
			for (int i = 1; i <= 31; i += 1) {
				DDpn.options.Add (new Dropdown.OptionData (i.ToString ()));
			}


		} else if((mdata == 4 || mdata == 6 || mdata == 9 || mdata == 11) && Lit == true){
			Leap = true;
			Lit = false;
			Feb = true;
			Big = true;

			DDpn.ClearOptions();
			for (int i = 1; i <= 30; i += 1) {
				DDpn.options.Add (new Dropdown.OptionData (i.ToString ()));
			}

		}
	}

}
