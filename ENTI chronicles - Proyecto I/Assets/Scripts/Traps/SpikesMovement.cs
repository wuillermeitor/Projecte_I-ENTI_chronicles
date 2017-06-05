using UnityEngine;
using System.Collections;

public class SpikesMovement : MonoBehaviour {

    //Contacto Player
    private Player player;
    private LifeManager life;
    public Transform HerocontactcheckLeft;
    public Transform HerocontactcheckRight;
    public Transform HerocontactcheckUp;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool HerocontactLeft;
    private bool HerocontactRight;
    private bool HerocontactUp;
    public bool touched;
    public float count;
    public float Upspeed;
    public float Downspeed;
    public float supPos;
    public float infPos;

    void Start ()
    {
        life = FindObjectOfType<LifeManager>();
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        count += Time.deltaTime;
        HerocontactRight = Physics2D.OverlapCircle(HerocontactcheckLeft.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactLeft = Physics2D.OverlapCircle(HerocontactcheckRight.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactUp = Physics2D.OverlapCircle(HerocontactcheckUp.position, HerocontactcheckRadius, whatisHerocontact);
        movimiento();
        if (player.inmunity == false)
        {
            if (HerocontactRight || HerocontactLeft || HerocontactUp)
            {
                life.Life_Counter = 0;
            }
        }
    }

    void movimiento()
    {
        if (count >= 2f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Upspeed);
            if (GetComponent<Transform>().position.y >= supPos)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        if (count >= 5f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Downspeed);
            if (GetComponent<Transform>().position.y <= infPos)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                count = 0;
            }
        }
    }
}
