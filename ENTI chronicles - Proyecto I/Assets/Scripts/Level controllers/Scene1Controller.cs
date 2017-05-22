using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
		GameData gameData = GameData.GetInstance ();
		gameData.AddValue ("welcome","ola ke ase");

		SceneManager.LoadScene ("Scene2");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
