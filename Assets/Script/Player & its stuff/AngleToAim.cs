using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//<>
public class AngleToAim : MonoBehaviour {

	#region Parameters
	private float DirX;
	private float DirY;
	public float AngleXY;
	public GameObject goPlayer; //Access to the Player GameObject

	#endregion

	#region What To Display
	public bool DebugMode = false; //Need to be true if we want to know the value of the angle made by the rightstick
	#endregion

	void Start () {
		AngleXY = 90f;}
	
	void Update () {
		RightStickAngle ();
		//make the Position to the Aim equal to the one of the Player's
		transform.position = goPlayer.transform.position;

		//float x1 = gameObject.transform.position.x;
		//float y1 = gameObject.transform.position.y;
		//x1 = goPlayer.transform.position.x;
		//y1 = goPlayer.transform.position.y;
		//x1 = x2; 
		//y1 = y2;

	}

	void RightStickAngle() { // Translate the -1/1 value of the XY axis of the rigthstick to the angle create this way
		DirX = Input.GetAxis ("RightHorizontal");
		DirY = Input.GetAxis ("RightVertical");
		if (DirX != 0.0f || DirY != 0.0f) {
			AngleXY = Mathf.Atan2(DirX, DirY) * Mathf.Rad2Deg;
		}
		transform.eulerAngles = new Vector3(0, 0, AngleXY-90);

		//		Visée.transform.Rotate = Vector3(0,0,AngleXY);
		if (DebugMode == true){Debug.Log (AngleXY);}

	}
}
