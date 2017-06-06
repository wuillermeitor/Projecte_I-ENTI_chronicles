using UnityEngine;
using System.Collections;

public class FBGen : MonoBehaviour {

    public GameObject FBPrefab;
    public Transform FBSpawner;
    private Player player;
    private HeroPower_Mana mana;
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
        if (player.mustRecharge == false && mana.Mana_Counter > 0)
        {
            PlayerShooting();
        }
    }
    
    IEnumerator delay()
    {
        FBexistiendo = true;
        player.mustRecharge = true;
        Instantiate(FBPrefab, FBSpawner.position, FBSpawner.rotation);
        mana.Mana_Counter--;
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
