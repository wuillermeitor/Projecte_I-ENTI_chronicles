using UnityEngine;
using System.Collections;

public class Movimiento_balas : MonoBehaviour
{
    public Rigidbody2D BulletRG;
    private Player player;
    private GameObject Player;

    public float bulletMovement;
    private float BulletSpeed;
    public float BulletLife;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        BulletRG = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        if (player.girado == false) 
        {
            BulletSpeed = bulletMovement;
        }
        else
        {
            BulletSpeed = -bulletMovement;
        }
        BulletRG.velocity = new Vector2(BulletSpeed, BulletRG.velocity.y);
    }
    
    void Update()
    {
        Destroy(gameObject, BulletLife);
    }
}