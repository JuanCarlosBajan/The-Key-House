using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider objeto;
    Vector3 oriPos;
    public int velocidad, x, y, z, alcance;

    // Start is called before the first frame update
    void Start()
    {
        objeto = GetComponent<BoxCollider>();
        oriPos = objeto.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        objeto.transform.position = oriPos + new Vector3(x * alcance * Mathf.Sin(velocidad * Time.time), y * alcance * Mathf.Sin(velocidad * Time.time), z * alcance * Mathf.Sin(velocidad * Time.time));
    }
}
