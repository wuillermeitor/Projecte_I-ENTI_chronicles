using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichoMegaman : MonoBehaviour {
    public float enemyspeed;
    private bool IsGoingDown;

    public GameObject StartPoint;
    public GameObject EndPoint;
    private Player player;
    private BulletGen bullet;
    private FBGen fireball;
    
    //Encontrar contacto con el jugador
    public Transform HerocontactCkeck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;
    

    void Start()
    {
        player = FindObjectOfType<Player>();
        bullet = FindObjectOfType<BulletGen>();
        fireball = FindObjectOfType<FBGen>();

        if (IsGoingDown)
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
        Herocontact = Physics2D.OverlapCircle(HerocontactCkeck.position, HerocontactcheckRadius, whatisHerocontact);
        
        movimiento();
        contacto();
    }

    void movimiento()
    {
        if (IsGoingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, enemyspeed * Time.deltaTime);

            if (transform.position == EndPoint.transform.position)
            {
                IsGoingDown = false;
            }
        }

        if (!IsGoingDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPoint.transform.position, enemyspeed * Time.deltaTime);
            if (transform.position == StartPoint.transform.position)
            {
                IsGoingDown = true;
            }
        }
    }

    void contacto()
    {
        if (player.inmunity == false)
        {
            //CONTACTO
            if (Herocontact == true)
            {
                player.touched = true;
            }
        }
    }
}
