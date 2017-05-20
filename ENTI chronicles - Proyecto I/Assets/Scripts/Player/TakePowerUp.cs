using UnityEngine;
using System.Collections;

public class TakePowerUp : MonoBehaviour
{
    private Player player;
    public Transform Herocontactcheck;
    public float HerocontactcheckRadius;
    public LayerMask whatisHerocontact;
    private bool Herocontact;
    public Transform HeroSpawnercontactcheck;
    public float HeroSpawnercontactcheckRadius;
    public LayerMask whatisHeroSpawnercontact;
    private bool HeroSpawnerContact;
    public bool taken;
    public bool SpawnerTouched;
    public Transform EnemiesContainer;
    public Transform HitBox;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        taken = false;
    }

    // Update is called once per frame
    void Update()
    {
        Herocontact = Physics2D.OverlapCircle(Herocontactcheck.position, HerocontactcheckRadius, whatisHerocontact);
        if (Herocontact == true)
        {
            taken = true;
        }
        if (taken == true)
        {
            Destroy(gameObject);
        }
    }
}
