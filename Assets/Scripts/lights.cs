using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Rotate(0, -5*Time.deltaTime, 0);

        gameObject.transform.position += new Vector3(0, Mathf.Sin(Time.time) * Time.deltaTime * 10, 0);
        
    }
}
