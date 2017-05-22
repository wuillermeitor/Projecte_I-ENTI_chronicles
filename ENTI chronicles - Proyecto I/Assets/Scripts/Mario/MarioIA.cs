using UnityEngine;
using System.Collections;

public class MarioIA : MonoBehaviour
{

    private MarioLife life;
    private FireBall fireball;
    private Player player;
    private BulletGen bullet;
    private Movimiento_balas balas;
    public GameObject vida;
    private LevelManager lvlman;

    //Variables
    public float velocityMove;
    public float VelRight;
    public float VelLeft;
    private float playerPosX;
    private float MarioPosX;
    public float stopDistance;
    public float FireballTime;
    public float salto;
    public bool der;
    public bool iz;
    public bool herido;
    public bool inmunity;
    public bool touched;
    public bool dead;
    public float counter = 0f;
    public bool ataque;
    public bool bossScene;

    public bool hit;
    private bool IsAlife;
    Animator run;
    Animator attack;
    Animator jump;
    Animator death;

    //Encontrar al player
    public Transform Herocheck;
    public float HeroVisioncheckRange;
    public LayerMask whatisHeroVision;
    private bool HeroVisualContact;

    //Encontrar el suelo
    public Transform groundcheck;
    public Transform groundcheck2;
    public float groundcheckRadius;
    public LayerMask whatisground;
    private bool grounded;
    private bool grounded2;

    //Encontrar ataque
    public Transform punchedcheck;
    public float punchedcheckRadius;
    public LayerMask whatispunch;
    private bool Punched;

    //Encontrar Límite del mapa
    public Transform limitscheck;
    public float limitscheckRadius;
    public LayerMask whatislimit;
    public bool outoflimit;
    public bool punchcheck;

    void Start()
    {
        lvlman = FindObjectOfType<LevelManager>();
        balas = FindObjectOfType<Movimiento_balas>();
        bullet = FindObjectOfType<BulletGen>();
        fireball = FindObjectOfType<FireBall>();
        life = FindObjectOfType<MarioLife>();
        player = FindObjectOfType<Player>();
        run = GetComponent<Animator>();
        attack = GetComponent<Animator>();
        jump = GetComponent<Animator>();
        death = GetComponent<Animator>();
        herido = false;
        inmunity = false;
        touched = false;
        dead = false;
        bossScene = false;

    }

    void Update()
    {
        outoflimit = Physics2D.OverlapCircle(limitscheck.position, limitscheckRadius, whatislimit);
        if (dead == false)
        {
            grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisground);
            grounded2 = Physics2D.OverlapCircle(groundcheck2.position, groundcheckRadius, whatisground);
            Punched = Physics2D.OverlapCircle(punchedcheck.position, punchedcheckRadius, whatispunch);
            HeroVisualContact = Physics2D.OverlapCircle(Herocheck.position, HeroVisioncheckRange, whatisHeroVision);
            playerPosX = player.GetComponent<Transform>().position.x;
            MarioPosX = GetComponent<Transform>().position.x;
            run.SetFloat("velocity", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
            jump.SetBool("jump", false);
            death.SetBool("death", false);
            hit = false;
            ataque = false;
            movement();
            damage();

            if (grounded == false && grounded2 == false)
            {
                jump.SetBool("jump", true);
            }

            if (player.punchcheck == true || bullet.balaexistiendo == true)
            {
                saltar();
            }
            counter += Time.deltaTime;

            if (HeroVisualContact == true)
            {
                bossScene = true;
            }
        }
        muerte();

        if (outoflimit == true)
        {
            Destroy(gameObject);
        }

    }

    void movement()
    {
        velocityMove = 0f;

        if (Mathf.Abs(MarioPosX - playerPosX) == stopDistance)
        {
            velocityMove = 0f;
            if (playerPosX < MarioPosX)
            {
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
                vida.GetComponent<SpriteRenderer>().flipX = false;
                der = false;
                iz = true;
            }
            else
            {
                GetComponent<Transform>().localScale = new Vector2(1, 1);
                vida.GetComponent<SpriteRenderer>().flipX = true;
                der = true;
                iz = false;
            }
        }

        else if(Mathf.Abs(MarioPosX - playerPosX) <= stopDistance - 0.5)
        {
            if (HeroVisualContact == true && playerPosX < MarioPosX)
            {
                GetComponent<Transform>().localScale = new Vector2(1, 1);
                der = true;
                iz = false;
                velocityMove = VelRight;
            }
            else if (HeroVisualContact == true && playerPosX > MarioPosX)
            {
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
                der = false;
                iz = true;
                velocityMove = VelLeft;
            }
        }

        else if(Mathf.Abs(MarioPosX - playerPosX) > stopDistance)
        {
            if (HeroVisualContact == true && playerPosX < MarioPosX)
            {
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
                der = false;
                iz = true;
                velocityMove = VelLeft;
            }
            else if (HeroVisualContact == true && playerPosX > MarioPosX)
            {
                GetComponent<Transform>().localScale = new Vector2(1, 1);
                der = true;
                iz = false;
                velocityMove = VelRight;
            }
        }

        if (Mathf.Abs(MarioPosX - playerPosX) < stopDistance)
        {
            atacar();
        }
        if (playerPosX < MarioPosX)
        {
            GetComponent<Transform>().localScale = new Vector2(-1, 1);
            vida.GetComponent<SpriteRenderer>().flipX = false;
            der = false;
            iz = true;
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector2(1, 1);
            vida.GetComponent<SpriteRenderer>().flipX = true;
            der = true;
            iz = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityMove, GetComponent<Rigidbody2D>().velocity.y);
    }

    IEnumerator delayattack()
    {
        attack.SetBool("attack", true);
        ataque = true;
        hit = !hit;
        yield return new WaitForSeconds(0.001f);
        fireball.fireballnow = false;
        attack.SetBool("attack", false);
        counter = 0;
    }

    void atacar()
    {
        if (counter >= 1f)
        {
            StartCoroutine(delayattack());
        }
    }

    void saltar()
    {
        if (grounded == true || grounded2 == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, salto);
            jump.SetBool("jump", false);
        }
    }

    void damage()
    {
        if (Punched == true && (player.punchcheck == true || bullet.balaexistiendo == true))
        {
            touched = true;
            bullet.balaexistiendo = false;
            lvlman.enemyTouched = true;
        }
        if (touched == true && inmunity == false && life.counter != 0)
        {
            touched = false;
            herido = true;
            inmunity = true;
        }
    }

    IEnumerator delaydeath()
    {
        death.SetBool("death", true);
        yield return new WaitForSeconds(0.2f);
        life.counter--;
        GetComponent<Rigidbody2D>().isKinematic = true;
        yield return new WaitForSeconds(0.8f);
        grounded = true;
        saltar();
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void muerte()
    {
        if (life.counter == 0)
        {
            dead = true;
            player.marioskin = true;
            StartCoroutine(delaydeath());
        }
    }
}
