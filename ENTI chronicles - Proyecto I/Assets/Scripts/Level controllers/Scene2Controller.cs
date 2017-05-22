using UnityEngine;
using System.Collections;

public class Scene2Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Debug.Log ("In Scene 2");
		GameData gameData = GameData.GetInstance ();
		Debug.Log ("Welcome Message: " + gameData.GetValue("welcome"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
