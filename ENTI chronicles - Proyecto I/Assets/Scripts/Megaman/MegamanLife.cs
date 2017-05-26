using UnityEngine;
using System.Collections;

public class MegamanLife : MonoBehaviour
{
    private MegamanIA Megaman;
    private Player player;

    public int counter;
    Animator Life;



    void Start()
    {
        Megaman = FindObjectOfType<MegamanIA>();
        Life = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        counter = 6;
        Life.SetInteger("vida", counter);
    }

    void Update()
    {
        Life.SetInteger("vida", counter);
        if (Megaman.herido == true)
        {
            StartCoroutine(delaybyHit());
        }
    }
    IEnumerator delaybyHit()
    {
        counter--;
        Megaman.herido = false;
        Megaman.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(1f);
        Megaman.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Megaman.inmunity = false;
    }

}
