using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    private Player player;

    public int Life_Counter;
    public Sprite[] vidas;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Life_Counter = 6;
    }
    
    void Update()
    {
        GetComponent<Image>().sprite = vidas[Life_Counter];

        if (player.herido == true)
        {
            StartCoroutine(delaybyHit());
        }
    }

    IEnumerator delaybyHit()
    {
        Life_Counter--;
        player.herido = false;
        yield return new WaitForSeconds(1f);
        player.inmunity = false;
    }
}
