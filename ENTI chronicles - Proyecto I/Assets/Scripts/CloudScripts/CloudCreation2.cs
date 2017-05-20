using UnityEngine;
using System.Collections;

public class CloudCreation2 : MonoBehaviour
{


    public Transform CloudSpawn;
    public GameObject CloudPrefab;



    private bool ActiveCloud = true;
    private int counter = 600;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CreateCloud();

    }

    public void CreateCloud()
    {
        if (ActiveCloud == true && counter % 600 == 0)
        {
            Instantiate(CloudPrefab, CloudSpawn.position, CloudSpawn.rotation);
        }
        counter += 1;
        if (counter == 1201)
        {
            counter = 0;
        }
    }
}
