using UnityEngine;
using System.Collections;

public class MovimientoPlataforma : MonoBehaviour {

    private Player player;
    public GameObject camara;

    public float platformspeed;
    private bool IsGoingRight;

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

        if (Herocontact)
        {
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
            camara.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
        }
        else
        {
            player.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    void movimiento()
    {
        if (IsGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, platformspeed * Time.deltaTime);

            if (transform.position == EndPoint.transform.position)
            {
                IsGoingRight = false;
            }
        }

        if (!IsGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPoint.transform.position, platformspeed * Time.deltaTime);
            if (transform.position == StartPoint.transform.position)
            {
                IsGoingRight = true;
            }
        }
    }
}
