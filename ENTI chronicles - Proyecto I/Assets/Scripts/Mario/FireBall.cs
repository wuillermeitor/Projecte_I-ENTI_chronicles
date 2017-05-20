using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public Transform FireBallSpawner;
    private MarioIA mario;
    public bool fireballnow;
    
    void Start ()
    {
        fireballnow = false;
        mario = FindObjectOfType<MarioIA>();
    }
	
	void Update ()
    {
        MarioAttack();
    }
    
    public void MarioAttack()
    {
        if (mario.counter >= 1f && mario.ataque == true && fireballnow == false)
        {
            Instantiate(FireBallPrefab, FireBallSpawner.position, FireBallSpawner.rotation);
            fireballnow = true;
            mario.ataque = false;
        }
    }
}
