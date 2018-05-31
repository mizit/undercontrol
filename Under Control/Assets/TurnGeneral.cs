using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGeneral : MonoBehaviour {

	private Button btn_Next;
	// Use this for initialization
	void Start () {
		btn_Next = new Button();
		btn_Next.Rect = new Rect(200, 200, 100, 50);
		btn_Next.text = "Next";
		btn_Next.Clicked += TurnSignal;
		btn_Next.DnD_allowed = false;
	}
	
	// Update is called once per frame
	void Update () {
		btn_Next.Processing();
	}

	public void OnGUI()
	{
		btn_Next.Draw();
	}

	void TurnSignal()
	{
		Debug.Log("Turn");
	}
}
