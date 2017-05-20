using UnityEngine;
using System.Collections;

public class MovementCloud : MonoBehaviour {
    public Rigidbody2D CloudRG;

    public float CloudSpeed;

    public float CloudLife;

    private void Awake()
    {
        CloudRG = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start ()
    {
        CloudRG.velocity = new Vector2(CloudSpeed, CloudRG.velocity.y);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, CloudLife);
	}
}
