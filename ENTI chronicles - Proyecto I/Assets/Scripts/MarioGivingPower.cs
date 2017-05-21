using UnityEngine;
using System.Collections;

public class MarioGivingPower : MonoBehaviour
{

    public GameObject player;
    public GameObject mario;
    public float wait;
    public float sec;
    public float counterM;
    public float counterP;
    public float cameralight;

    // Use this for initialization
    void Start()
    {
        GetComponent<Camera>().backgroundColor = new Color(0f, 0f, 0f, 0f);
        player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        player = GameObject.Find("Getting Power");
        mario.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        mario = GameObject.Find("Mario Giving Power");
    }

    // Update is called once per frame
    void Update()
    {
        wait += Time.deltaTime;
        if (wait >= 3)
        {
            GetComponent<Camera>().backgroundColor = new Color(1f, 1f, 1f, 1f);
            sec += Time.deltaTime;
        }
        if (sec >= 0.5f)
        {
            cameralight -= Time.deltaTime / 5;
            GetComponent<Camera>().backgroundColor = new Color(cameralight, cameralight, cameralight, 1f);
            counterM -= Time.deltaTime / 1.5f;
            mario.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, counterM);
            counterP += Time.deltaTime / 1.5f;
            player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, counterP);
        }
    }
}
