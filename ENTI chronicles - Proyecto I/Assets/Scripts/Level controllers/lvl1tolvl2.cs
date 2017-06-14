using UnityEngine;
using System.Collections;

public class lvl1tolvl2 : MonoBehaviour {

    public string mainmenu;

    private Player player;
    private LifeManager Plife;
    private BulletGen bullet;

    private MarioIA mario;
    private MarioLife Mlife;
    private FireBall fireball;
    private MovimientoFireBall movfb;

    private TakePowerUp gun;

    //Encontrar contacto con el jugador
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;
    public string level2;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
        Plife = FindObjectOfType<LifeManager>();
        bullet = FindObjectOfType<BulletGen>();
        mario = FindObjectOfType<MarioIA>();
        Mlife = FindObjectOfType<MarioLife>();
        fireball = FindObjectOfType<FireBall>();
        movfb = FindObjectOfType<MovimientoFireBall>();
        gun = FindObjectOfType<TakePowerUp>();

        GameData gameData = GameData.GetInstance();
        gameData.GetValue("player");
        gameData.GetValue("life");
        gameData.GetValue("bullet");
        gameData.GetValue("gun");
        player.marioskin = true;
        player.guntaken = true;
        bullet.balas = PlayerPrefs.GetInt("balas");
        Plife.Life_Counter = PlayerPrefs.GetInt("vida");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(mainmenu);
        }
        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        if (Herocontact)
        {
            Application.LoadLevel(level2);
        }
    }
}
