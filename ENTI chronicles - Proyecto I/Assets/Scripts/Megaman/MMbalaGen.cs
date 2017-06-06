using UnityEngine;
using System.Collections;

public class MMbalaGen : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public Transform FireBallSpawner;
    private MegamanIA Megaman;
    public bool bulletnow;

    void Start()
    {
        bulletnow = false;
        Megaman = FindObjectOfType<MegamanIA>();
    }

    void Update()
    {
        MarioAttack();
    }

    public void MarioAttack()
    {
        if (Megaman.counter >= 1f && Megaman.ataque == true && bulletnow == false)
        {
            Instantiate(FireBallPrefab, FireBallSpawner.position, FireBallSpawner.rotation);
            bulletnow = true;
            Megaman.ataque = false;
        }
    }
}
