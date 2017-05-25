using UnityEngine;
using System.Collections;

public class MovimientoPlataforma : MonoBehaviour {

    private Player player;
    public GameObject camara;

    public float platformspeed;
    private bool IsGoingRight;
    public float speed;

    public GameObject StartPoint;
    public GameObject EndPoint;

    //Encontrar contacto con el jugador
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();

        if (IsGoingRight)
        {
            transform.position = StartPoint.transform.position;
        }
        else
        {
            transform.position = EndPoint.transform.position;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        movimiento();
    }

    void movimiento()
    {
        if (IsGoingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

            if (GetComponent<Transform>().position.x >= EndPoint.GetComponent<Transform>().position.x-1)
            {
                IsGoingRight = false;
            }
        }

        if (!IsGoingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            if (GetComponent<Transform>().position.x <= StartPoint.GetComponent<Transform>().position.x+1)
            {
                IsGoingRight = true;
            }
        }
    }
}
