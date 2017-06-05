using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //scripts
    private TakePowerUp gun;
    private LifeManager life;
    private MarioIA mario;
    private Gun_Mana balas;
    private HeroPower_Mana Powermana;

    //variables
    public float move;
    private float moveVelocity;
    public float salto;
    private bool wait;
    public bool girado;
    public Vector2 PlayerPosition;
    public bool touched;
    public bool mustRecharge;
    public bool herido;
    public bool inmunity;
    public bool dead;
    public bool marioskin;
    public bool PlayerGun;
    public bool PlayerMario;
    public bool guntaken;

    //Game Objects
    public GameObject Dying;
    public GameObject JumpCollider;

    //Animaciones
    public Animator idle_normal;
    public Animator run;
    public Animator attack;
    public Animator jump;
    public Animator idle_gun;
    public Animator idle_mario;

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
        balas = FindObjectOfType<Gun_Mana>();
        balas.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        Powermana = FindObjectOfType<HeroPower_Mana>();
        Powermana.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        idle_normal = GetComponent<Animator>();
        run = GetComponent<Animator>();
        attack = GetComponent<Animator>();
        jump = GetComponent<Animator>();
        idle_gun = GetComponent<Animator>();
        idle_mario = GetComponent<Animator>();
        idle_normal.SetBool("idle_normal", true); //Para que el jugador empiece con el sprite normal
        PlayerGun = false;
        PlayerMario = false;
        wait = false;
        girado = false;
        mustRecharge = false;
        touched = false;
        herido = false;
        inmunity = false;
        dead = false;
        marioskin = false;
        guntaken = false;
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
        idle_mario.SetBool("idle_Mario", false);
        JumpCollider.GetComponent<BoxCollider2D>().isTrigger = true;

        caminar();
        saltar();
        atacar();
        damage();
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
        //PEGAR
        if (Input.GetKey(KeyCode.Space) && moveVelocity == 0)
        {
            attack.SetBool("attack", true);
            punchcheck = true;
        }

        //POWER-UP: GUN
        PowerUpGun();

        //MARIO SKIN
        MarioSkin();

        if (Input.GetKey("1") && moveVelocity == 0 && (grounded == true || grounded2 == true))
        {
            balas.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            Powermana.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            idle_normal.SetBool("idle_normal", true);
            idle_gun.SetBool("idle_gun", false);
            idle_mario.SetBool("idle_Mario", false);
            PlayerGun = false;
            PlayerMario = false;
        }
    }

    void PowerUpGun()
    {
        if (guntaken == true)
        {
            if (Input.GetKey("2") && moveVelocity == 0 && (grounded == true || grounded2 == true))
            {
                balas.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                Powermana.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                idle_gun.SetBool("idle_gun", true);
                PlayerGun = true;
                PlayerMario = false;
                idle_normal.SetBool("idle_normal", false);
                idle_mario.SetBool("idle_Mario", false);
            }
        }
    }

    void MarioSkin()
    {
        if (marioskin == true)
        {
            if(Input.GetKey("3") && moveVelocity == 0 && (grounded == true || grounded2 == true))
            {
                Powermana.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                balas.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
                idle_normal.SetBool("idle_normal", false);
                idle_gun.SetBool("idle_gun", false);
                idle_mario.SetBool("idle_Mario", true);
                PlayerMario = true;
                PlayerGun = false;
            }
        }
    }

    //DAÑO
    void damage()
    {
        if (touched == true && inmunity == false && life.Life_Counter != 0)
        {
            StartCoroutine(delaybyHit());
            touched = false;
            herido = true;
            inmunity = true;
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
