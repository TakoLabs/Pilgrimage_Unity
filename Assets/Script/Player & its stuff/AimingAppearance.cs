using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//<>
public class AimingAppearance : MonoBehaviour {

	#region Parameters
	public float TimeBeforeFading = 5f;
	public float TimeToFade = 1f;
	private float PresentTime;
	private bool count;
	public GameObject Aim;

//	public Image image;
//	public Color imageColor;
	#endregion

	#region What To Display
	public bool DebugMode = false;
	#endregion


	void Start () {
		count = false;
		Aim.SetActive (false);
//		imageColor = image.Color;
		//image = GetComponent<SpriteRenderer>();
	}

	void Update () {
//		for(int j = 0; j = TimeToFade; j++) { 
//			imageColor.a = 0;
//		}

		if (Mathf.Abs(Input.GetAxisRaw ("RightHorizontal")) <0.2 && Mathf.Abs(Input.GetAxisRaw ("RightVertical")) <0.2) {
			if (count == false) {
				PresentTime = Time.time;
				count = true;
			}
			if ((TimeBeforeFading + PresentTime) - Time.time <= 0) {
				if (DebugMode == true) {Debug.Log ("C'est sensé disparaître");}
				Aim.SetActive (false);
			}
		} else if (Mathf.Abs(Input.GetAxisRaw("RightHorizontal"))>0.2 || Mathf.Abs(Input.GetAxisRaw("RightVertical")) >0.2){
			if (DebugMode == true) {Debug.Log ("C'est sensé APPARAITRE");}
			Aim.SetActive (true);
			count = false;
		}
	}
}
