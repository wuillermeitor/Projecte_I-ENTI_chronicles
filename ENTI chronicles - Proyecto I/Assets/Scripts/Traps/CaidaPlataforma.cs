using UnityEngine;
using System.Collections;

public class CaidaPlataforma : MonoBehaviour {

    private Player player;
    private LifeManager life;
    public Transform HerocontactcheckUp;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool HerocontactUp;
    public float velocityCaida;
    public GameObject checkpoint;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
        life = FindObjectOfType<LifeManager>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        HerocontactUp = Physics2D.OverlapCircle(HerocontactcheckUp.position, HerocontactcheckRadius, whatisHerocontact);

        if (HerocontactUp == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocityCaida);
        }
        if (player.outoflimit || life.Life_Counter == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().position = (checkpoint.transform.position);
        }
    }
}
