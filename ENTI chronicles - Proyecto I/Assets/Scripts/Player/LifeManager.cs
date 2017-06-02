using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private Player player;

    public int counter;
    Animator Life;
    public Sprite[] vidas;


    void Start()
    {
        player = FindObjectOfType<Player>();
        counter = 6;
    }
    
    void Update()
    {
        GetComponent<Image>().sprite = vidas[counter];

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
