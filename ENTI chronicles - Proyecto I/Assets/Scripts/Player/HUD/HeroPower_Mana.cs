using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPower_Mana : MonoBehaviour {

    private Player player;

    public int Mana_Counter;
    public Sprite[] Mana;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Mana_Counter = 10;
    }

    void Update()
    {
        GetComponent<Image>().sprite = Mana[Mana_Counter];
        
    }
}
