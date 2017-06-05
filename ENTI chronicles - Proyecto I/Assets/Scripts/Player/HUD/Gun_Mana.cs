using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_Mana : MonoBehaviour {

    private Player player;

    public int balas;
    public Sprite[] Mana;

    void Start()
    {
        player = FindObjectOfType<Player>();
        balas = 10;
    }

    void Update()
    {
        GetComponent<Image>().sprite = Mana[balas];
    }
}
