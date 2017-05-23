using UnityEngine;
using System.Collections;

public class ClosingDoor : MonoBehaviour {

    private Level2Manager lvl;
    public Animator Door;
    // Use this for initialization
    void Start ()
    {
        Door.SetBool("IsClosed", false);
        lvl = FindObjectOfType<Level2Manager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (lvl.close)
        {
            Door.SetBool("IsClosed", true);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
	}
}
