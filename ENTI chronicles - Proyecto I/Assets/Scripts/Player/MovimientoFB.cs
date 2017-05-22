using UnityEngine;
using System.Collections;

public class MovimientoFB : MonoBehaviour {

    public Rigidbody2D FBRG;
    private Player player;
    private GameObject Player;
    private LevelManager lvlman;

    public float FBMovement;
    private float FBSpeed;
    public float FBLife;

    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask whatisground;
    private bool grounded;
    public float salto;


    private void Awake()
    {
        lvlman = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
        FBRG = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
    }
    // Use this for initialization
    void Start ()
    {
        if (player.girado == false)
        {
            FBSpeed = FBMovement;
        }
        else
        {
            FBSpeed = -FBMovement;
        }
        FBRG.velocity = new Vector2(FBSpeed, FBRG.velocity.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (lvlman.enemyTouched == true)
        {
            Destroy(gameObject);
            lvlman.enemyTouched = false;
        }
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisground);
        Destroy(gameObject, FBLife);
        saltar();
    }

    void saltar()
    {
        if (grounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(FBSpeed, salto);
        }
    }
}
