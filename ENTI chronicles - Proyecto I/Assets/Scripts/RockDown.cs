using UnityEngine;
using System.Collections;

public class RockDown : MonoBehaviour {

    private Player player;
    private TakePowerUp gun;
    private float PosY;
    private bool hapasado;
    // Use this for initialization
    void Start ()
    {
        hapasado = false;
        player = FindObjectOfType<Player>();
        gun = FindObjectOfType<TakePowerUp>();
    }
	
	// Update is called once per frame
	void Update () {
        PosY = GetComponent<Transform>().position.y;
        if (gun.taken == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
        }

        if (PosY <= -9.75)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (player.GetComponent<Transform>().position.x >= 165)
        {
            hapasado = true;
        }

        if (hapasado == true)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            if (PosY < 0.8)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
