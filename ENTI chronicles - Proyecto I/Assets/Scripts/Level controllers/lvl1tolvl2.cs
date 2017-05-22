using UnityEngine;
using System.Collections;

public class lvl1tolvl2 : MonoBehaviour {

    //Encontrar contacto con el jugador
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;
    public string level2;
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        if (Herocontact)
        {
            Application.LoadLevel(level2);
        }
    }
}
