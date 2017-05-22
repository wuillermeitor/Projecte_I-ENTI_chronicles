using UnityEngine;
using System.Collections;

public class CaidaPlataforma : MonoBehaviour {

    private Player player;
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
  
    }
	
	// Update is called once per frame
	void Update ()
    {
        HerocontactUp = Physics2D.OverlapCircle(HerocontactcheckUp.position, HerocontactcheckRadius, whatisHerocontact);

        if (HerocontactUp == true)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, velocityCaida);
        }
        if (player.outoflimit == true)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().position = (checkpoint.transform.position);
        }
    }
}
