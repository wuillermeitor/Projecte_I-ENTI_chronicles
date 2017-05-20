using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour
{
    private Player player;

    public int counter;
    Animator Life;
    


    void Start()
    {
        player = FindObjectOfType<Player>();
        Life = GetComponent<Animator>();
        counter = 6;
        Life.SetInteger("Life", counter);
    }
    
    void Update()
    {
        Life.SetInteger("Life", counter);
        if (player.herido == true)
        {
            StartCoroutine(delaybyHit());
        }
    }
    IEnumerator delaybyHit()
    {
        counter--;
        player.herido = false;
        yield return new WaitForSeconds(1f);
        player.inmunity = false;
    }

}
