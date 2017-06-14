using UnityEngine;
using System.Collections;

public class Level2Manager : MonoBehaviour
{

    public string mainmenu;

    private Player player;
    private LifeManager Plife;
    private BulletGen bullet;

    private MarioIA mario;
    private MarioLife Mlife;
    private FireBall fireball;
    private MovimientoFireBall movfb;

    private MegamanIA megaman;
    private MegamanLife MMlife;
    private MMbalaGen MMbullet;
    private MovimientoBalaMM movb;

    private TakePowerUp gun;



    public GameObject checkpoint;
    public GameObject camara;

    //Hero contact
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;

    public bool active;
    public bool close;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Plife = FindObjectOfType<LifeManager>();
        bullet = FindObjectOfType<BulletGen>();
        mario = FindObjectOfType<MarioIA>();
        Mlife = FindObjectOfType<MarioLife>();
        fireball = FindObjectOfType<FireBall>();
        movfb = FindObjectOfType<MovimientoFireBall>();

        megaman = FindObjectOfType<MegamanIA>();
        MMlife = FindObjectOfType<MegamanLife>();
        MMbullet = FindObjectOfType<MMbalaGen>();
        movb = FindObjectOfType<MovimientoBalaMM>();

        GameData gameData = GameData.GetInstance();
        gameData.GetValue("player");
        gameData.GetValue("life");
        gameData.GetValue("bullet");
        gameData.GetValue("gun");
        player.marioskin = true;
        player.guntaken = true;
        bullet.balas = PlayerPrefs.GetInt("balas");
        Plife.Life_Counter = PlayerPrefs.GetInt("vida");
        close = false;


    }

    void Update()
    {

        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        respawn();
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(mainmenu);
        }
        if (player.dead == true)
        {
            active = true;
            Plife.Life_Counter = 6;
            MMlife.counter = 6;
            megaman.GetComponent<Rigidbody2D>().position = new Vector2(-36, -28);
            player.dead = false;
        }

        if (player.GetComponent<Transform>().position.x >= 76)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(79, -4);
        }
        if (player.GetComponent<Transform>().position.y <= -28 && player.GetComponent<Transform>().position.x <= -11)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(-11, -24);
        }

        if (Herocontact)
        {
            LockCamera();
        }
    }


    void respawn()
    {
        //Condición que moverá al player al último check point si se sale del mapa.
        if (player.outoflimit == true)
        {
            player.dead = true;
            Instantiate(player.Dying, checkpoint.transform.position, transform.rotation);
            player.GetComponent<Rigidbody2D>().position = (checkpoint.transform.position);
        }
        if (Plife.Life_Counter == 0)
        {
            player.dead = true;
            player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Instantiate(player.Dying, checkpoint.transform.position, transform.rotation);
            player.GetComponent<Rigidbody2D>().position = (checkpoint.transform.position);
            Plife.Life_Counter = 6;
        }
    }

    void LockCamera()
    {
        camara.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        camara.GetComponent<Camera>().backgroundColor = new Color(0f, 0f, 0f, 1f);
        close = true;
    }
}
