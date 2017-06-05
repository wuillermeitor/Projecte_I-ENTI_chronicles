using UnityEngine;
using System.Collections;

public class FBGen : MonoBehaviour {

    public GameObject FBPrefab;
    public Transform FBSpawner;
    private Player player;
    private HeroPower_Mana mana;
    public int FB = 10;
    public bool FBexistiendo;


    void Start ()
    {
        mana = FindObjectOfType<HeroPower_Mana>();
        player = FindObjectOfType<Player>();
        FBexistiendo = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        mana.Mana_Counter = FB;
        if (player.mustRecharge == false && FB > 0)
        {
            PlayerShooting();
        }
    }
    
    IEnumerator delay()
    {
        FBexistiendo = true;
        player.mustRecharge = true;
        Instantiate(FBPrefab, FBSpawner.position, FBSpawner.rotation);
        FB--;
        yield return new WaitForSeconds(0.6f);
        player.mustRecharge = false;
        FBexistiendo = false;
    }

    public void PlayerShooting()
    {
        if (Input.GetKey(KeyCode.Space) && player.PlayerMario == true)
        {
            StartCoroutine(delay());
        }
    }
}
