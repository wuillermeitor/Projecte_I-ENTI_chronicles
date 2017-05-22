using UnityEngine;
using System.Collections;

public class GoombaIA : MonoBehaviour
{
    private Player player;
    private BulletGen bullet;
    private FBGen fireball;
    private LevelManager lvlman;

    Animator IsDead;
    public float moveVelocity;
    public float moveRight;
    public float moveLeft;
    //Encontrar el suelo
    public Transform groundcheck;
    public float groundcheckRadius;
    public LayerMask whatisground;
    private bool grounded;
    //Encontrar colisiones
    public Transform collisioncheckLeft;
    public Transform collisioncheckRight;
    public float collisioncheckRadius;
    public LayerMask whatiscollision;
    private bool collisionedLeft;
    private bool collisionedRight;
    //Encontrar ataque
    public Transform punchedcheckLeft;
    public Transform punchedcheckRight;
    public float punchedcheckRadius;
    public LayerMask whatispunch;
    private bool PunchedLeft;
    private bool PunchedRight;
    private bool dead;
    //Encontrar contacto con el jugador
    public Transform HerocontactcheckLeft;
    public Transform HerocontactcheckRight;
    public Transform HerocontactcheckUp;
    public Transform HerocontactcheckDown;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool HerocontactLeft;
    private bool HerocontactRight;
    private bool HerocontactUp;
    private bool HerocontactDown;

    void Start()
    {
        lvlman = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Player>();
        bullet = FindObjectOfType<BulletGen>();
        fireball = FindObjectOfType<FBGen>();
        IsDead = GetComponent<Animator>();
        PunchedLeft = false;
        PunchedRight = false;
        dead = false;
        IsDead.SetBool("IsDead", false);
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisground);
        collisionedLeft = Physics2D.OverlapCircle(collisioncheckLeft.position, collisioncheckRadius, whatiscollision);
        collisionedRight = Physics2D.OverlapCircle(collisioncheckRight.position, collisioncheckRadius, whatiscollision);
        PunchedLeft = Physics2D.OverlapCircle(punchedcheckLeft.position, punchedcheckRadius, whatispunch);
        PunchedRight = Physics2D.OverlapCircle(punchedcheckRight.position, punchedcheckRadius, whatispunch);
        HerocontactRight = Physics2D.OverlapCircle(HerocontactcheckLeft.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactLeft = Physics2D.OverlapCircle(HerocontactcheckRight.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactUp = Physics2D.OverlapCircle(HerocontactcheckUp.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactDown = Physics2D.OverlapCircle(HerocontactcheckDown.position, HerocontactcheckRadius, whatisHerocontact);

        if (dead == false)
        {
            movimiento();
            contacto();           
        }
        else
        {
            //MUERTE
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            IsDead.SetBool("IsDead", true);
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void movimiento()
    {
        //MOVIMIENTO
        if (collisionedLeft == true && grounded == true)
        {
            moveVelocity = moveRight;
        }
        else if (collisionedRight == true && grounded == true)
        {
            moveVelocity = moveLeft;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, 0);
    }

    void contacto()
    {
        if (player.inmunity == false)
        {
            //CONTACTO
            if (PunchedLeft == true && (player.punchcheck == true || bullet.balaexistiendo == true || fireball.FBexistiendo == true))
            {
                dead = true;
                lvlman.enemyTouched = true;
            }
            else if (PunchedRight == true && (player.punchcheck == true || bullet.balaexistiendo == true || fireball.FBexistiendo == true))
            {
                dead = true;
                lvlman.enemyTouched = true;
                GetComponent<Transform>().localScale = new Vector2(-1, 1);
            }
            else if (HerocontactLeft == true && player.punchcheck == false)
            {
                player.touched = true;
            }
            else if (HerocontactRight == true && player.punchcheck == false)
            {
                player.touched = true;
            }
            else if (HerocontactUp == true)
            {
                player.touched = true;
            }
            else if (HerocontactDown == true)
            {
                player.touched = true;
            }
        }
    }
}