using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private Player player;
    private LifeManager Plife;
    private BulletGen bullet;

    private MarioIA mario;
    private MarioLife Mlife;
    private FireBall fireball;
    private MovimientoFireBall movfb;

    private TakePowerUp gun;

    public bool active;
    float counter;
    public string cinematic;

    public GameObject checkpoint;

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
        active = false;
        counter = 0;
    }

    void Update()
    {
        respawn();

        if (player.dead == true)
        {
            active = true;
            Plife.Life_Counter = 6;
            bullet.balas = 10;
            Mlife.counter = 4;
            mario.GetComponent<Rigidbody2D>().position = new Vector2(191, 0.5f);
            player.dead = false;
        }

        if (mario.dead == true)
        {
            passScene();
        }
    }

    void passScene()
    {
        counter += Time.deltaTime;
        if (counter >= 3)
        {
            PlayerPrefs.SetInt("balas", bullet.balas);
            PlayerPrefs.SetInt("vida", Plife.Life_Counter);
            GameData gameData = GameData.GetInstance();
            gameData.AddValue("mario", mario);
            gameData.AddValue("player", player);
            gameData.AddValue("life", Plife);
            gameData.AddValue("bullet", bullet);
            gameData.AddValue("gun", gun);
            Application.LoadLevel(cinematic);
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
        if (player.PlayerPosition.x >= 67)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(67, 3);
        }
        if (player.PlayerPosition.x >= 124)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(124, 3);
        }
        if (player.PlayerPosition.x >= 157)
        {
            checkpoint.GetComponent<Transform>().position = new Vector2(160, 3);
        }
    }
}
