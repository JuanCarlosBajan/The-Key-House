using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    Rigidbody doorRB;

    
    bool openDoor=false;    
    GameObject PossessionKey;
    AudioSource [] CharacterSounds;
    public GameObject PauseMenu;
    
    int abrir;

    // Start is called before the first frame update
    void Start()
    {
        CharacterSounds = GetComponents<AudioSource>();
        PauseMenu.SetActive(false);
        abrir = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.activeSelf == false)
        {
            //Rayo de colisión
            Ray myray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            Debug.DrawRay(myray.origin,myray.direction*5,Color.red);
            RaycastHit hitinfo;
            //Recoger llaves incorrectas
            if (Physics.Raycast(myray, out hitinfo,5f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("FakeKey"))
            {
                CharacterSounds[1].Play();
                if (PossessionKey)
                {
                    PossessionKey.SetActive(true);
                }
                PossessionKey = hitinfo.collider.gameObject;
                PossessionKey.SetActive(false);
                openDoor = false;
            }
            //Regocer llave correcta
            else if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("TheKey"))
            {
                
                CharacterSounds[1].Play();
                if (PossessionKey)
                {
                    PossessionKey.SetActive(true);
                }
                PossessionKey = hitinfo.collider.gameObject;
                PossessionKey.SetActive(false);
                openDoor = true;
            }


            //Abrir puerta nivel 1
            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("Door") && openDoor)
            {
                
                if (abrir < 1)
                {
                    CharacterSounds[2].Play();
                    abrir = 1;
                }

                doorRB = hitinfo.collider.gameObject.GetComponentInParent<Rigidbody>();
                                
                bool open = true;              
                if (doorRB.transform.eulerAngles.y < 110 && open)
                { 
                    doorRB.transform.Rotate(0, 30 * Time.deltaTime, 0); 
                }                   
                else
                {
                    open = false;                    
                }         
            }
            else if(Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("Door") && openDoor==false)
            {
                CharacterSounds[0].Play();
            }

            //Abrir trampilla
            if (Physics.Raycast(myray, out hitinfo, 20f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("Trampilla"))
            {
                if (abrir < 1)
                {
                    CharacterSounds[2].Play();
                    abrir = 1;
                }

                doorRB = hitinfo.collider.gameObject.GetComponentInParent<Rigidbody>();

                bool open = true;
                if (doorRB.transform.eulerAngles.z > -110 && open)
                {
                    doorRB.transform.Rotate(0,0, -50*Time.deltaTime);
                }
                else
                {
                    print("PORQUE NOFunciona");
                    open = false;
                }
            }

            //Abrir trampilla
            if (Physics.Raycast(myray, out hitinfo, 20f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("Trampilla"))
            {

                doorRB = hitinfo.collider.gameObject.GetComponentInParent<Rigidbody>();

                bool open = true;
                if (doorRB.transform.eulerAngles.z > -110 && open)
                {
                    doorRB.transform.Rotate(0, 0, -50 * Time.deltaTime);
                }
                else
                {
                    print("PORQUE NOFunciona");
                    open = false;
                }
            }







        }
    }
}
