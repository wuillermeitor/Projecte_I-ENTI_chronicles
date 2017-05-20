using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //scripts
    private TakePowerUp gun;
    private LifeManager life;
    private MarioIA mario;

    //variables
    public float move;
    private float moveVelocity;
    public float salto;
    private bool wait;
    public bool girado;
    private Vector2 PlayerPosition;
    public bool touched;
    public bool mustRecharge;
    public bool herido;
    public bool inmunity;
    public bool dead;



    //Game Objects
    public GameObject checkpoint;
    public GameObject Dying;
    public GameObject JumpCollider;
    public GameObject mana;

    //Animaciones
    Animator idle_normal;
    Animator run;
    public Animator attack;
    public Animator jump;
    public Animator idle_gun;
    public bool PlayerGun;

    //Encontrar el suelo
    public Transform groundcheck;
    public Transform groundcheck2;
    public float groundcheckRadius;
    public LayerMask whatisground;
    private bool grounded;
    private bool grounded2;

    //Encontrar Límite del mapa
    public Transform limitscheck;
    public float limitscheckRadius;
    public LayerMask whatislimit;
    public bool outoflimit;
    public bool punchcheck;

    //START
    void Start()
    {
        gun = FindObjectOfType<TakePowerUp>();
        life = FindObjectOfType<LifeManager>();
        mario = FindObjectOfType<MarioIA>();
        mana.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        mana = GameObject.Find("FullMana");
        idle_normal = GetComponent<Animator>();
        run = GetComponent<Animator>();
        attack = GetComponent<Animator>();
        jump = GetComponent<Animator>();
        idle_gun = GetComponent<Animator>();
        idle_normal.SetBool("idle_normal", true); //Para que el jugador empiece con el sprite normal
        PlayerGun = false;
        wait = false;
        girado = false;
        mustRecharge = false;
        touched = false;
        herido = false;
        inmunity = false;
        dead = false;
    }    
    
    //UPDATE
    void Update()
    {
        //Comprobante de la situación actual del jugador
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisground);
        grounded2 = Physics2D.OverlapCircle(groundcheck2.position, groundcheckRadius, whatisground);
        outoflimit = Physics2D.OverlapCircle(limitscheck.position, limitscheckRadius, whatislimit);
        PlayerPosition = GetComponent<Rigidbody2D>().position;

        //inicialización de las animaciones del jugador
        punchcheck = false;
        run.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        attack.SetBool("attack", false);
        jump.SetBool("jump", false);
        idle_gun.SetBool("idle_gun", false);
        JumpCollider.GetComponent<BoxCollider2D>().isTrigger = true;

        caminar();
        saltar();
        atacar();
        damage();
        respawn();
    }

    //CAMINAR
    void caminar()
    {
        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().localScale = new Vector2(1, 1);
            moveVelocity = move;
            girado = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().localScale = new Vector2(-1, 1);
            moveVelocity = -move;
            girado = true;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    //SALTAR
    void saltar()
    {
        if (grounded == false && grounded2 == false)
        {
            jump.SetBool("jump", true);
            JumpCollider.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && (grounded == true || grounded2 == true))
        {
            jump.SetBool("jump", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, salto);
            JumpCollider.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    //ATACAR
    void atacar()
    {
        if (mario.inmunity == false)
        {
            //PEGAR
            if (Input.GetKey(KeyCode.Space) && moveVelocity == 0)
            {
                attack.SetBool("attack", true);
                punchcheck = true;
            }

            //POWER-UP: GUN
            if (gun.taken == true)
            {
                if (Input.GetKey("1") && moveVelocity == 0)
                {
                    mana.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                    idle_gun.SetBool("idle_gun", false);
                    idle_normal.SetBool("idle_normal", true);
                    PlayerGun = false;
                }
                if (Input.GetKey("2") && moveVelocity == 0 && (grounded == true || grounded2 == true))
                {
                    mana.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    idle_normal.SetBool("idle_normal", false);
                    idle_gun.SetBool("idle_gun", true);
                    PlayerGun = true;
                }
            }
        }
    }

    //DAÑO
    void damage()
    {
        if (touched == true && inmunity == false && life.counter != 0)
        {
            StartCoroutine(delaybyHit());
            touched = false;
            herido = true;
            inmunity = true;
        }
    }

    //RESPAWN
    void respawn()
    {
        //Condición que moverá al player al último check point si se sale del mapa.
        if (outoflimit == true)
        {
            dead = true;
            Instantiate(Dying, checkpoint.transform.position, transform.rotation);
            GetComponent<Rigidbody2D>().position = (checkpoint.transform.position);
        }
        if (life.counter == 0)
        {
            dead = true;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Instantiate(Dying, checkpoint.transform.position, transform.rotation);
            GetComponent<Rigidbody2D>().position = (checkpoint.transform.position);
            life.counter = 6;
        }
        if (PlayerPosition.x >= 67)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(67, 3);
        }
        if (PlayerPosition.x >= 124)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(124, 3);
        }
        if (PlayerPosition.x >= 157)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(160, 3);
        }
    }

    //DELAYS
    IEnumerator delaybyHit()
    {
        if (girado == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move, salto);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-move, salto);
        }
        GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

}
