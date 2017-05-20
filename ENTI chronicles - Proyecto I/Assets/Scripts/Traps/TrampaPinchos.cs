using UnityEngine;
using System.Collections;

public class TrampaPinchos : MonoBehaviour
{
    private Player player;
    public Transform HerocontactcheckLeft;
    public Transform HerocontactcheckRight;
    public Transform HerocontactcheckUp;
    public Transform HerocontactcheckUpRight;
    public Transform HerocontactcheckUpLeft;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool HerocontactLeft;
    private bool HerocontactRight;
    private bool HerocontactUp;
    public bool touched;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }


    void Update()
    {
        HerocontactRight = Physics2D.OverlapCircle(HerocontactcheckLeft.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactLeft = Physics2D.OverlapCircle(HerocontactcheckRight.position, HerocontactcheckRadius, whatisHerocontact);
        HerocontactUp = Physics2D.OverlapCircle(HerocontactcheckUp.position, HerocontactcheckRadius, whatisHerocontact);

        if (player.inmunity == false)
        {
            if (HerocontactLeft == true)
            {
                player.touched = true;
            }
            else if (HerocontactRight == true)
            {
                player.touched = true;
            }
            else if (HerocontactUp == true)
            {
                player.touched = true;
            }
        }
    }
}