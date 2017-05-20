using UnityEngine;
using System.Collections;

public class recarga : MonoBehaviour {

    private MarioIA mario;
    public Transform RecargaSpawner;
    public GameObject RecargaPrefab;
    private bool aparisao;

    void Start ()
    {
        aparisao = false;
        mario = FindObjectOfType<MarioIA>();
    }
	
	void Update ()
    {
        aparicion();
    }

    public void aparicion()
    {
        if (mario.counter == 2)
        {
            aparisao = true;
        }
        if (aparisao == true)
        {
            Instantiate(RecargaPrefab, RecargaSpawner.position, RecargaSpawner.rotation);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 5);
        }
    }
}
