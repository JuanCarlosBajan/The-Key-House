using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterConfigurations : MonoBehaviour
{
    public GameObject[] spawns;
    public AudioSource [] bu;
    // Start is called before the first frame update
    void Start()
    {
        bu = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemie"))
        {
            bu[1].Play();
            gameObject.transform.position = spawns[Random.Range(0, 3)].transform.position;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light")) {

            gameObject.tag = "onLight";
        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {

            gameObject.tag = "notOnLight";
        }
    }
}
