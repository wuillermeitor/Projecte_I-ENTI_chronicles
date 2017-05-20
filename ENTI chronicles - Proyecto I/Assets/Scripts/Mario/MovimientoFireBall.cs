using UnityEngine;
using System.Collections;

public class MovimientoFireBall : MonoBehaviour {

    public Rigidbody2D FBRG;
    private MarioIA mario;
    private Player player;
    private GameObject Mario;

    public float FBMovement;
    private float FBSpeed;
    public float FBLife;

    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask whatisground;
    private bool grounded;
    public float salto;

    //Encontrar contacto con el jugador
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;

    private void Awake()
    {
        mario = FindObjectOfType<MarioIA>();
        player = FindObjectOfType<Player>();
        FBRG = GetComponent<Rigidbody2D>();
        Mario = GameObject.FindWithTag("Mario");
    }

    void Start ()
    {
        if (mario.der == true)
        {
            FBSpeed = FBMovement;
        }
        else if (mario.iz == true)
        {
            FBSpeed = -FBMovement;
        }
        FBRG.velocity = new Vector2(FBSpeed, FBRG.velocity.y);
    }
	
	void Update ()
    {
        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisground);
        if (player.inmunity == false && Herocontact == true)
        {
                player.touched = true;
        }
        saltar();
        Destroy(gameObject, FBLife);
        if (player.dead == true)
        {
            Destroy(gameObject);
        }
    }

    void saltar()
    {             
        if (grounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(FBSpeed, salto);
        }
    }
}