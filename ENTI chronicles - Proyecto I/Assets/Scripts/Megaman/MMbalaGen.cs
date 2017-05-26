using UnityEngine;
using System.Collections;

public class MMbalaGen : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public Transform FireBallSpawner;
    private MegamanIA Megaman;
    public bool fireballnow;

    void Start()
    {
        fireballnow = false;
        Megaman = FindObjectOfType<MegamanIA>();
    }

    void Update()
    {
        MarioAttack();
    }

    public void MarioAttack()
    {
        if (Megaman.counter >= 1f && Megaman.ataque == true && fireballnow == false)
        {
            Instantiate(FireBallPrefab, FireBallSpawner.position, FireBallSpawner.rotation);
            fireballnow = true;
            Megaman.ataque = false;
        }
    }
}
