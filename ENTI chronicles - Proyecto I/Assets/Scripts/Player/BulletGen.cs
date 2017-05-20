using UnityEngine;
using System.Collections;

public class BulletGen : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform BulletSpawner;
    private Player player;
    public Animator mana;
    public int balas = 10;
    public bool balaexistiendo;

    void Start ()
    {
        mana = GameObject.Find("FullMana").GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        balaexistiendo = false;
    }
    void Update()
    {
        mana.SetInteger("balas", balas);
        if (player.mustRecharge == false && balas > 0)
        {
            PlayerShooting();
        }
    }

    IEnumerator delay()
    {
        balaexistiendo = true;
        player.mustRecharge = true;
        Instantiate(BulletPrefab, BulletSpawner.position, BulletSpawner.rotation);
        balas--;
        yield return new WaitForSeconds(0.6f);
        player.mustRecharge = false;
        balaexistiendo = false;
    }

    public void PlayerShooting()
    {
        if (Input.GetKey(KeyCode.Space) && player.PlayerGun == true)
        {
            StartCoroutine(delay());
        }
    }

}
