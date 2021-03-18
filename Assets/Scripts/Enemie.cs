using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{

    NavMeshAgent nma;
    Vector3 spawn;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

        nma = GetComponent<NavMeshAgent>();
        spawn = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (target.CompareTag("notOnLight")) {

            nma.SetDestination(target.GetComponent<Rigidbody>().position);

        }

        if (target.CompareTag("onLight")) { nma.destination = gameObject.transform.position; }

    }

   

}
