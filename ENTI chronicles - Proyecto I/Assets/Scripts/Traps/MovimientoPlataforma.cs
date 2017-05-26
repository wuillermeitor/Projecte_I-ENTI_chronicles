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
        if (Herocontact && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Vector2 temp;
            temp = player.GetComponent<Rigidbody2D>().velocity;
            temp.x = speed;

            player.GetComponent<Rigidbody2D>().velocity = temp; 
        }
    }

    void movimiento()
    {
        if (GetComponent<Transform>().position.x >= EndPoint.GetComponent<Transform>().position.x)
        {
            speed *= -1;
        }

        if (GetComponent<Transform>().position.x <= StartPoint.GetComponent<Transform>().position.x)
        {
            speed *= -1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
}
