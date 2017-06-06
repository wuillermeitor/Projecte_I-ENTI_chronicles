using UnityEngine;
using System.Collections;

public class MovimientoBalaMM : MonoBehaviour
{

    public Rigidbody2D BulletRG;
    private MegamanIA Megaman;
    private Player player;
    private Level2Manager level2;
    private GameObject Mario;

    public float BulletMovement;
    private float BulletSpeed;
    public float BulletLife;

    //Encontrar contacto con el jugador
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;

    private void Awake()
    {
        Megaman = FindObjectOfType<MegamanIA>();
        level2 = FindObjectOfType<Level2Manager>();
        player = FindObjectOfType<Player>();
        BulletRG = GetComponent<Rigidbody2D>();
        Mario = GameObject.FindWithTag("Mario");
    }

    void Start()
    {
        level2.active = false;
        if (Megaman.der == true)
        {
            BulletSpeed = BulletMovement;
        }
        else if (Megaman.iz == true)
        {
            BulletSpeed = -BulletMovement;
        }
        BulletRG.velocity = new Vector2(BulletSpeed, BulletRG.velocity.y);
    }

    void Update()
    {
        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        
        Destroy(gameObject, BulletLife);

        if (player.inmunity == false && Herocontact == true)
        {
            player.touched = true;
        }

        if (level2.active == true)
        {
            Destroy(gameObject);
        }
    }
}