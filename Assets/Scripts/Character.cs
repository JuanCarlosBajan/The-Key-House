using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    Rigidbody doorRB;
    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {

        Ray myray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hitinfo;
        if (Physics.Raycast(myray, out hitinfo) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.CompareTag("Door"))
        {
            print("holis");

            doorRB = hitinfo.collider.gameObject.GetComponent<Rigidbody>();

            if (doorRB.rotation.eulerAngles.x < 90)
                doorRB.transform.Rotate(0, 30 * Time.deltaTime, 0);

        }

    }
}
