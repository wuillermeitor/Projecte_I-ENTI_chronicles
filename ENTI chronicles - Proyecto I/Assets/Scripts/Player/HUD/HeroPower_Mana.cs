using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPower_Mana : MonoBehaviour {

    private Player player;

    public int Mana_Counter;
    public Sprite[] Mana;
    public float cooldown;
    public float cooldowncounter;

    void Start()
    {
        cooldowncounter = 0;
        player = FindObjectOfType<Player>();
        Mana_Counter = 10;
    }

    void Update()
    {
        GetComponent<Image>().sprite = Mana[Mana_Counter];
        if (Mana_Counter < 10)
        {
            cooldowncounter += Time.deltaTime;
            if (cooldowncounter >= cooldown)
            {
                Mana_Counter += 1;
                cooldowncounter = 0;
            }
        }
    }
}
