using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaderIA : MonoBehaviour
{

    public float enemyspeed;
    private bool IsGoingRight;

    public GameObject StartPoint;
    public GameObject EndPoint;
    private Player player;
    private BulletGen bullet;

    Animator IsDead;

    //Encontrar ataque
    public Transform punchedcheck;
    public float punchedcheckRadius;
    public LayerMask whatispunch;
    private bool Punched;
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
        player = FindObjectOfType<Player>();
        IsDead = GetComponent<Animator>();
        bullet = FindObjectOfType<BulletGen>();
        Punched= false;
        dead = false;
        IsDead.SetBool("IsDead", false);

        if (IsGoingRight)
        {
            transform.position = StartPoint.transform.position;
        }
        else
        {
            transform.position = EndPoint.transform.position;
        }
    }


    void Update()
    {
        Punched = Physics2D.OverlapCircle(punchedcheck.position, punchedcheckRadius, whatispunch);
        HerocontactRight = Physics2D.OverlapCircle(HerocontactcheckLeft.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactLeft = Physics2D.OverlapCircle(HerocontactcheckRight.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactUp = Physics2D.OverlapCircle(HerocontactcheckUp.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactDown = Physics2D.OverlapCircle(HerocontactcheckDown.position, HerocontactcheckRadius, whatisHerocontact);

        if (dead == false)
        {
            if (IsGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, enemyspeed * Time.deltaTime);

                if (transform.position == EndPoint.transform.position)
                {
                    IsGoingRight = false;
                }
            }

            if (!IsGoingRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, StartPoint.transform.position, enemyspeed * Time.deltaTime);
                if (transform.position == StartPoint.transform.position)
                {
                    IsGoingRight = true;
                }
            }
            if (player.inmunity == false)
            {
                //CONTACTO
                if (Punched == true && (player.punchcheck == true || bullet.balaexistiendo == true))
                {
                    dead = true;
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
        else
        {
            //MUERTE
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            IsDead.SetBool("IsDead", true);
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}