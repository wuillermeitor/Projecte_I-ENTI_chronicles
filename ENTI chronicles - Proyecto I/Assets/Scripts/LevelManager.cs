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

    public bool active;
    float counter;
    public string cinematic;

    void Start ()
    {
        player = FindObjectOfType<Player>();
        Plife = FindObjectOfType<LifeManager>();
        bullet = FindObjectOfType<BulletGen>();
        mario = FindObjectOfType<MarioIA>();
        Mlife = FindObjectOfType<MarioLife>();
        fireball = FindObjectOfType<FireBall>();
        movfb = FindObjectOfType<MovimientoFireBall>();
        active = false;
        counter = 0;
    }
	
	void Update () {
        if (player.dead == true)
        {
            active = true;
            Plife.counter = 6;
            bullet.balas = 10;
            Mlife.counter = 4;
            mario.GetComponent<Rigidbody2D>().position = new Vector2(191, 0.5f);
            player.dead = false;
        }

        if (mario.dead == true)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                Application.LoadLevel(cinematic);
            }
        }
	}
}
