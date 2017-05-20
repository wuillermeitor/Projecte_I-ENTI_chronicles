using UnityEngine;
using System.Collections;

public class MarioLife : MonoBehaviour
{
    private MarioIA mario;
    private Player player;

    public int counter;
    Animator Life;



    void Start()
    {
        mario = FindObjectOfType<MarioIA>();
        Life = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        counter = 4;
        Life.SetInteger("vida", counter);
    }

    void Update()
    {
        Life.SetInteger("vida", counter);
        if (mario.herido == true)
        {
            StartCoroutine(delaybyHit());
        }
    }
    IEnumerator delaybyHit()
    {
        counter--;
        mario.herido = false;
        mario.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(1f);
        mario.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        mario.inmunity = false;
    }

}
